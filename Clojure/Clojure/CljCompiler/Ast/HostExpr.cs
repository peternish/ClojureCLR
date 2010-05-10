﻿/**
 *   Copyright (c) Rich Hickey. All rights reserved.
 *   The use and distribution terms for this software are covered by the
 *   Eclipse Public License 1.0 (http://opensource.org/licenses/eclipse-1.0.php)
 *   which can be found in the file epl-v10.html at the root of this distribution.
 *   By using this software in any fashion, you are agreeing to be bound by
 * 	 the terms of this license.
 *   You must not remove this notice, or any other, from this software.
 **/

/**
 *   Author: David Miller
 **/

extern alias MSC;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
#if CLR2
using Microsoft.Scripting.Ast;
#else
using System.Linq.Expressions;
#endif
using Microsoft.Scripting;

using clojure.runtime;
using System.IO;
using System.Dynamic;
using Microsoft.Scripting.Actions.Calls;
using Microsoft.Scripting.Actions;
using Microsoft.Scripting.Runtime;
using System.Runtime.CompilerServices;

namespace clojure.lang.CljCompiler.Ast
{
    abstract class HostExpr : Expr, MaybePrimitiveExpr
    {
        #region Symbols

        public static readonly Symbol REFPARAM = Symbol.create("refparam");
        public static readonly Symbol OUTPARAM = Symbol.create("outparam");

        #endregion

        #region Parsing

        public sealed class Parser : IParser
        {
            public Expr Parse(object frm, ParserContext pcon)
            {
                ISeq form = (ISeq)frm;

                // form is one of:
                //  (. x fieldname-sym)
                //  (. x 0-ary-method)
                //  (. x propertyname-sym)
                //  (. x methodname-sym args)+
                //  (. x (methodname-sym args?))

                if (RT.Length(form) < 3)
                    throw new ArgumentException("Malformed member expression, expecting (. target member ... )");

                string source = (string)Compiler.SOURCE.deref();
                IPersistentMap spanMap = (IPersistentMap)Compiler.SOURCE_SPAN.deref();  // Compiler.GetSourceSpanMap(form);

                Symbol tag = Compiler.TagOf(form);

                // determine static or instance
                // static target must be symbol, either fully.qualified.Typename or Typename that has been imported
                 
                Type t = HostExpr.MaybeType(RT.second(form), false);
                // at this point, t will be non-null if static

                Expr instance = null;
                if (t == null)
                    instance = Compiler.GenerateAST(RT.second(form),new ParserContext(false,false));

                bool isZeroArityCall = RT.Length(form) == 3 && RT.third(form) is Symbol;

                if (isZeroArityCall)
                {
                    PropertyInfo pinfo = null;
                    FieldInfo finfo = null;
                    MethodInfo minfo = null;

                    Symbol sym = (Symbol)RT.third(form);
                    string fieldName = Compiler.munge(sym.Name);
                    // The JVM version does not have to worry about Properties.  It captures 0-arity methods under fields.
                    // We have to put in special checks here for this.
                    // Also, when reflection is required, we have to capture 0-arity methods under the calls that
                    //   are generated by StaticFieldExpr and InstanceFieldExpr.
                    if (t != null)
                    {
                        if ((finfo = Reflector.GetField(t, fieldName, true)) != null)
                            return new StaticFieldExpr(source, spanMap, tag, t, fieldName, finfo);
                        if ((pinfo = Reflector.GetProperty(t, fieldName, true)) != null)
                            return new StaticPropertyExpr(source, spanMap, tag, t, fieldName, pinfo);
                        if ((minfo = Reflector.GetArityZeroMethod(t, fieldName, true)) != null)
                            return new StaticMethodExpr(source, spanMap, tag, t, fieldName, new List<HostArg>());
                        throw new MissingMemberException(t.Name, fieldName);
                    }
                    else if (instance != null && instance.HasClrType && instance.ClrType != null)
                    {
                        Type instanceType = instance.ClrType;
                        if ((finfo = Reflector.GetField(instanceType, fieldName, false)) != null)
                            return new InstanceFieldExpr(source, spanMap, tag, instance, fieldName, finfo);
                        if ((pinfo = Reflector.GetProperty(instanceType, fieldName, false)) != null)
                            return new InstancePropertyExpr(source, spanMap, tag, instance, fieldName, pinfo);
                        if ((minfo = Reflector.GetArityZeroMethod(instanceType, fieldName, false)) != null)
                            return new InstanceMethodExpr(source, spanMap, tag, instance, fieldName, new List<HostArg>());
                        if (pcon.IsAssignContext)
                            return new InstanceFieldExpr(source, spanMap, tag, instance, fieldName, null); // same as InstancePropertyExpr when last arg is null
                        else
                            return new InstanceZeroArityCallExpr(source, spanMap, tag, instance, fieldName);
                    }
                    else
                    {
                        //  t is null, so we know this is not a static call
                        //  If instance is null, we are screwed anyway.
                        //  If instance is not null, then we don't have a type.
                        //  So we must be in an instance call to a property, field, or 0-arity method.
                        //  The code generated by InstanceFieldExpr/InstancePropertyExpr with a null FieldInfo/PropertyInfo
                        //     will generate code to do a runtime call to a Reflector method that will check all three.
                        //return new InstanceFieldExpr(source, spanMap, tag, instance, fieldName, null); // same as InstancePropertyExpr when last arg is null
                        //return new InstanceZeroArityCallExpr(source, spanMap, tag, instance, fieldName); 
                        if (pcon.IsAssignContext)
                            return new InstanceFieldExpr(source, spanMap, tag, instance, fieldName, null); // same as InstancePropertyExpr when last arg is null
                        else
                            return new InstanceZeroArityCallExpr(source, spanMap, tag, instance, fieldName); 

                    }
                }
 

                ISeq call = RT.third(form) is ISeq ? (ISeq)RT.third(form) : RT.next(RT.next(form));

                if (!(RT.first(call) is Symbol))
                    throw new ArgumentException("Malformed member exception");

                string methodName = Compiler.munge(((Symbol)RT.first(call)).Name);

                List<HostArg> args = ParseArgs(RT.next(call));

                return t != null
                    ? (MethodExpr)(new StaticMethodExpr(source, spanMap, tag, t, methodName, args))
                    : (MethodExpr)(new InstanceMethodExpr(source, spanMap, tag, instance, methodName, args));
            }
        }


        internal static List<HostArg> ParseArgs(ISeq argSeq)
        {
            List<HostArg> args = new List<HostArg>();

            for (ISeq s = argSeq; s != null; s = s.next())
            {
                object arg = s.first();

                HostArg.ParameterType paramType = HostArg.ParameterType.Standard;
                LocalBinding lb = null;

                if (arg is ISeq)
                {
                    Symbol op = RT.first(arg) as Symbol;
                    if (op != null && (op.Equals(OUTPARAM) || op.Equals(REFPARAM)))
                    {
                        if (RT.Length((ISeq)arg) != 2)
                            throw new ArgumentException("Wrong number of arguments to {0}", ((Symbol)op).Name);

                        object localArg = RT.second(arg);
                        if (!(localArg is Symbol) || (lb = Compiler.ReferenceLocal((Symbol)localArg)) == null)
                            throw new ArgumentException("Argument to {0} must be a local variable.", ((Symbol)op).Name);

                        if (op.Equals(OUTPARAM))
                            paramType = HostArg.ParameterType.Out;
                        else
                            paramType = HostArg.ParameterType.Ref;

                        arg = localArg;
                    }
                }

                Expr expr = Compiler.GenerateAST(arg, new ParserContext(false,false));

                args.Add(new HostArg(paramType, expr, lb));
            }

            return args;

        }

        #endregion

        #region Code generation

        public abstract bool CanEmitPrimitive { get; }
        public abstract Expression GenDlrUnboxed(GenContext context);

        #endregion

        #region Reflection helpers

        protected static MethodInfo GetMatchingMethod(IPersistentMap spanMap, Type targetType, List<HostArg> args, string methodName)
        {
            List<MethodBase> methods = HostExpr.GetMethods(targetType, args.Count, methodName, true);

            MethodBase method = GetMatchingMethodAux(targetType, args, methods, methodName, true);
            MaybeReflectionWarn(spanMap, method, methodName);
            return (MethodInfo) method;
        }

        protected static MethodInfo GetMatchingMethod(IPersistentMap spanMap, Expr target, List<HostArg> args, string methodName)
        {
            MethodBase method = null;
            if (target.HasClrType)
            {
                Type targetType = target.ClrType;
                List<MethodBase> methods = HostExpr.GetMethods(targetType, args.Count, methodName, false);
                method = GetMatchingMethodAux(targetType, args, methods, methodName, false);
            }

            MaybeReflectionWarn(spanMap, method, methodName);
            return (MethodInfo)method;
        }

        internal static ConstructorInfo GetMatchingConstructor(IPersistentMap spanMap, Type targetType, List<HostArg> args, out int ctorCount)
        {
            List<MethodBase> methods = HostExpr.GetConstructors(targetType, args.Count);
            ctorCount = methods.Count;

            MethodBase method = GetMatchingMethodAux(targetType, args, methods, "_ctor", true);
            // Because no-arg c-tors for value types are handled elsewhere, we defer the warning to there.
            return (ConstructorInfo)method;
        }

        private static MethodBase GetMatchingMethodAux(Type targetType, List<HostArg> args, List<MethodBase> methods, string methodName, bool isStatic)
        {
            int argCount = args.Count;

            if (methods.Count == 0)
                return null;

            IList<DynamicMetaObject> argsPlus = new List<DynamicMetaObject>(argCount + (isStatic ? 0 : 1));
            if (!isStatic)
                argsPlus.Add(new DynamicMetaObject(Expression.Default(targetType), BindingRestrictions.Empty));

            foreach (HostArg ha in args)
            {
                Expr e = ha.ArgExpr;
                Type argType = e.HasClrType ? (e.ClrType ?? typeof(object)) : typeof(Object);

                Type t;

                switch (ha.ParamType)
                {
                    case HostArg.ParameterType.Ref:
                    case HostArg.ParameterType.Out:
                        t = typeof(MSC::System.Runtime.CompilerServices.StrongBox<>).MakeGenericType(argType);
                        break;
                    case HostArg.ParameterType.Standard:
                        t = argType;
                        break;
                    default:
                        throw Util.UnreachableCode();
                }
                argsPlus.Add(new DynamicMetaObject(Expression.Default(t), BindingRestrictions.Empty));
            }

            OverloadResolverFactory factory = DefaultOverloadResolver.Factory;
            DefaultOverloadResolver res = factory.CreateOverloadResolver(argsPlus, new CallSignature(argCount), isStatic ? CallTypes.None : CallTypes.ImplicitInstance);

            BindingTarget bt = res.ResolveOverload(methodName, methods, NarrowingLevel.None, NarrowingLevel.All);
            if (bt.Success)
                return bt.Overload.ReflectionInfo;

            return null;
        }



        private static List<MethodBase> GetConstructors(Type targetType, int arity)
        {
            IEnumerable<ConstructorInfo> cinfos
                = targetType.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Where(info =>  info.GetParameters().Length == arity);

            List<MethodBase> infos = new List<MethodBase>();

            foreach (ConstructorInfo info in cinfos)
                infos.Add(info);

            return infos;
        }

        private static List<MethodBase> GetMethods(Type targetType, int arity, string methodName, bool getStatics)
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.InvokeMethod;
            flags |= getStatics ? BindingFlags.Static : BindingFlags.Instance;

            List<MethodBase> infos;

            if (targetType.IsInterface && ! getStatics)
                infos = GetInterfaceMethods(targetType,arity,methodName);
            else
            {
                IEnumerable<MethodInfo> einfos
                    = targetType.GetMethods(flags).Where(info => info.Name == methodName && info.GetParameters().Length == arity);
                infos = new List<MethodBase>();
                foreach (MethodInfo minfo in einfos)
                    infos.Add(minfo);
            }

            return infos;
        }

        private static List<MethodBase> GetInterfaceMethods(Type targetType, int arity, string methodName)
        {
            BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod;

            List<Type> interfaces = new List<Type>();
            interfaces.Add(targetType);
            interfaces.AddRange(targetType.GetInterfaces());

            List<MethodBase> infos = new List<MethodBase>();

            foreach ( Type type in interfaces )
            {
                MethodInfo[] methods = type.GetMethods();
                IEnumerable<MethodInfo> einfo
                     = type.GetMethods(flags).Where(info => info.Name == methodName && info.GetParameters().Length == arity);
                foreach (MethodInfo minfo in einfo)
                    infos.Add(minfo);
            }

            return infos;
        }


        private static void MaybeReflectionWarn(IPersistentMap spanMap, MethodBase method, string methodName)
        {
            if ( method == null && RT.booleanCast(RT.WARN_ON_REFLECTION.deref()) )
                ((TextWriter)RT.ERR.deref()).WriteLine(string.Format("Reflection warning, {0}:{1} - call to {2} can't be resolved.\n",
                    Compiler.SOURCE_PATH.deref(), spanMap != null ? (int)spanMap.valAt(RT.START_LINE_KEY, 0) : 0, methodName));
        }


        internal static Expression[] GenTypedArgs(GenContext context, ParameterInfo[] parms, List<HostArg> args)
        {
            Expression[] exprs = new Expression[parms.Length];
            for (int i = 0; i < parms.Length; i++)
                exprs[i] = GenTypedArg(context,parms[i].ParameterType, args[i].ArgExpr);
            return exprs;
        }

        internal static Expression GenTypedArg(GenContext context, Type type, Expr arg)
        {
            if (Compiler.MaybePrimitiveType(arg) == type)
                return ((MaybePrimitiveExpr)arg).GenDlrUnboxed(context);
            else
            {
                Expression argExpr = arg.GenDlr(context);
                return GenMaybeUnboxedArg(type, argExpr);
            }
        }

        internal static readonly MethodInfo Method_Util_ConvertToSByte = typeof(Util).GetMethod("ConvertToByte");
        internal static readonly MethodInfo Method_Util_ConvertToByte = typeof(Util).GetMethod("ConvertToByte");
        internal static readonly MethodInfo Method_Util_ConvertToShort = typeof(Util).GetMethod("ConvertToShort");
        internal static readonly MethodInfo Method_Util_ConvertToUShort = typeof(Util).GetMethod("ConvertToUShort");
        internal static readonly MethodInfo Method_Util_ConvertToInt = typeof(Util).GetMethod("ConvertToInt");
        internal static readonly MethodInfo Method_Util_ConvertToUInt = typeof(Util).GetMethod("ConvertToUInt");
        internal static readonly MethodInfo Method_Util_ConvertToLong = typeof(Util).GetMethod("ConvertToLong");
        internal static readonly MethodInfo Method_Util_ConvertToULong = typeof(Util).GetMethod("ConvertToULong");
        internal static readonly MethodInfo Method_Util_ConvertToFloat = typeof(Util).GetMethod("ConvertToFloat");
        internal static readonly MethodInfo Method_Util_ConvertToDouble = typeof(Util).GetMethod("ConvertToDouble");
        internal static readonly MethodInfo Method_Util_ConvertToChar = typeof(Util).GetMethod("ConvertToChar");
        internal static readonly MethodInfo Method_Util_ConvertToDecimal = typeof(Util).GetMethod("ConvertToDecimal");

        static Expression GenMaybeUnboxedArg(Type type, Expression argExpr)
        {
            Type argType = argExpr.Type;

            if (argType == type)
                return argExpr;

            if (type.IsAssignableFrom(argType))
                return argExpr;

            if (Util.IsPrimitiveNumeric(argType) && Util.IsPrimitiveNumeric(type))
                return argExpr;

            if (type == typeof(sbyte))
                return Expression.Call(null, Method_Util_ConvertToSByte, argExpr);
            else if ( type == typeof(byte))
                return Expression.Call(null, Method_Util_ConvertToByte, argExpr);
            else if (type == typeof(short))
                return Expression.Call(null, Method_Util_ConvertToShort, argExpr);
            else if (type == typeof(ushort))
                return Expression.Call(null, Method_Util_ConvertToUShort, argExpr);
            else if (type == typeof(int))
                return Expression.Call(null, Method_Util_ConvertToInt, argExpr);
            else if (type == typeof(uint))
                return Expression.Call(null, Method_Util_ConvertToUInt, argExpr);
            else if (type == typeof(long))
                return Expression.Call(null, Method_Util_ConvertToLong, argExpr);
            else if (type == typeof(ulong))
                return Expression.Call(null, Method_Util_ConvertToULong, argExpr);
            else if (type == typeof(float))
                return Expression.Call(null, Method_Util_ConvertToFloat, argExpr);
            else if (type == typeof(double))
                return Expression.Call(null, Method_Util_ConvertToDouble, argExpr);
            else if (type == typeof(char))
                return Expression.Call(null, Method_Util_ConvertToChar, argExpr);
            else if (type == typeof(decimal))
                return Expression.Call(null, Method_Util_ConvertToDecimal, argExpr);
            
            return argExpr;
        }

        #endregion

        #region Tags and types

        internal static Type MaybeType(object form, bool stringOk)
        {
            if (form is Type)
                return (Type)form;

            Type t = null;
            if (form is Symbol)
            {
                Symbol sym = (Symbol)form;
                if (sym.Namespace == null) // if ns-qualified, can't be classname
                {
                    if (Util.equals(sym, Compiler.COMPILE_STUB_SYM.get()))
                        return (Type)Compiler.COMPILE_STUB_CLASS.get();
                    // TODO:  This uses Java  [whatever  notation.  Figure out what to do here.
                    if (sym.Name.IndexOf('.') > 0 || sym.Name[sym.Name.Length-1] == ']')
                        t = RT.classForName(sym.Name);
                    else
                    {
                        object o = Compiler.CurrentNamespace.GetMapping(sym);
                        if (o is Type)
                            t = (Type)o;
                    }

                }
            }
            else if (stringOk && form is string)
                t = RT.classForName((string)form);

            return t;
        }

        internal static Type TagToType(object tag)
        {
            Type t = MaybeType(tag, true);
            if (tag is Symbol)
            {
                Symbol sym = (Symbol)tag;
                if (sym.Namespace == null) // if ns-qualified, can't be classname
                {
                    switch (sym.Name)
                    {
                        case "objects": t = typeof(object[]); break;
                        case "ints": t = typeof(int[]); break;
                        case "longs": t = typeof(long[]); break;
                        case "floats": t = typeof(float[]); break;
                        case "doubles": t = typeof(double[]); break;
                        case "chars": t = typeof(char[]); break;
                        case "shorts": t = typeof(short[]); break;
                        case "bytes": t = typeof(byte[]); break;
                        case "booleans":
                        case "bools": t = typeof(bool[]); break;
                        case "uints": t = typeof(uint[]); break;
                        case "ushorts": t = typeof(ushort[]); break;
                        case "ulongs": t = typeof(ulong[]); break;
                        case "sbytes": t = typeof(sbyte[]); break;
                    }
                }
            }
            else if (tag is String)
            {
                // TODO: This is no longer in the Java version.  SHould we get rid of?
                string strTag = (string)tag;
                t = Type.GetType(strTag);
            }

            if (t != null)
                return t;

            throw new ArgumentException("Unable to resolve typename: " + tag);
        }

        #endregion
    }
}
