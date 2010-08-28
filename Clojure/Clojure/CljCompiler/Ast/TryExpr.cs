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

using System;

#if CLR2
using Microsoft.Scripting.Ast;
#else
using System.Linq.Expressions;
#endif


namespace clojure.lang.CljCompiler.Ast
{
    class TryExpr : Expr
    {
        #region Nested classes

        public sealed class CatchClause
        {
            readonly Type _type;
            public Type Type
            {
              get { return _type; }  
            } 

            readonly LocalBinding _lb;
            internal LocalBinding Lb
            {
              get { return _lb; }  
            } 

            readonly Expr _handler;
            internal Expr Handler
            {
              get { return _handler; }  
            } 


            public CatchClause(Type type, LocalBinding lb, Expr handler)
            {
                _type = type;
                _lb = lb;
                _handler = handler;
            }
        }

        #endregion

        #region Data

        readonly Expr _tryExpr;
        readonly Expr _finallyExpr;
        readonly IPersistentVector _catchExprs;
        readonly int _retLocal;
        readonly int _finallyLocal;

        #endregion

        #region Ctors

        public TryExpr(Expr tryExpr, IPersistentVector catchExprs, Expr finallyExpr, int retLocal, int finallyLocal)
        {
            _tryExpr = tryExpr;
            _catchExprs = catchExprs;
            _finallyExpr = finallyExpr;
            _retLocal = retLocal;
            _finallyLocal = finallyLocal;
        }

        #endregion

        #region Type mangling

        public override bool HasClrType
        {
            get { return _tryExpr.HasClrType; }
        }

        public override Type ClrType
        {
            get { return _tryExpr.ClrType; }
        }

        #endregion

        #region Parsing

        public sealed class Parser : IParser
        {
            public Expr Parse(object frm, ParserContext pcon)
            {
                ISeq form = (ISeq)frm;

                // (try try-expr* catch-expr* finally-expr?)
                // catch-expr: (catch class sym expr*)
                // finally-expr: (finally expr*)

                IPersistentVector body = PersistentVector.EMPTY;
                IPersistentVector catches = PersistentVector.EMPTY;
                Expr bodyExpr = null;
                Expr finallyExpr = null;
                bool caught = false;

                int retLocal = Compiler.GetAndIncLocalNum();
                int finallyLocal = Compiler.GetAndIncLocalNum();

                for (ISeq fs = form.next(); fs != null; fs = fs.next())
                {
                    object f = fs.first();
                    object op = (f is ISeq) ? ((ISeq)f).first() : null;
                    if (!Util.equals(op, Compiler.CATCH) && !Util.equals(op, Compiler.FINALLY))
                    {
                        if (caught)
                            throw new Exception("Only catch or finally clause can follow catch in try expression");
                        body = body.cons(f);
                    }
                    else
                    {
                        if (bodyExpr == null)
                            bodyExpr = new BodyExpr.Parser().Parse(RT.seq(body), pcon.SetAssign(false));
                        if (Util.equals(op, Compiler.CATCH))
                        {
                            Type t = HostExpr.MaybeType(RT.second(f), false);
                            if (t == null)
                                throw new ArgumentException("Unable to resolve classname: " + RT.second(f));
                            if (!(RT.third(f) is Symbol))
                                throw new ArgumentException("Bad binding form, expected symbol, got: " + RT.third(f));
                            Symbol sym = (Symbol)RT.third(f);
                            if (sym.Namespace != null)
                                throw new Exception("Can't bind qualified name: " + sym);

                            IPersistentMap dynamicBindings = RT.map(
                                Compiler.LOCAL_ENV, Compiler.LOCAL_ENV.deref(),
                                Compiler.NEXT_LOCAL_NUM, Compiler.NEXT_LOCAL_NUM.deref(),
                                //Compiler.IN_CATCH_FINALLY, RT.T);
                                Compiler.IN_CATCH_FINALLY, true);

                            try
                            {
                                Var.pushThreadBindings(dynamicBindings);
                                LocalBinding lb = Compiler.RegisterLocal(sym,
                                    (Symbol)(RT.second(f) is Symbol ? RT.second(f) : null),
                                    null,false);
                                Expr handler = (new BodyExpr.Parser()).Parse(RT.next(RT.next(RT.next(f))), pcon.SetAssign(false));
                                catches = catches.cons(new CatchClause(t, lb, handler)); ;
                            }
                            finally
                            {
                                Var.popThreadBindings();
                            }
                            caught = true;
                        }
                        else // finally
                        {
                            if (fs.next() != null)
                                throw new Exception("finally clause must be last in try expression");
                            try
                            {
                                //Var.pushThreadBindings(RT.map(Compiler.IN_CATCH_FINALLY, RT.T));
                                Var.pushThreadBindings(RT.map(Compiler.IN_CATCH_FINALLY, true));
                                finallyExpr = (new BodyExpr.Parser()).Parse(RT.next(f), pcon.SetRecur(false).SetAssign(false));
                            }
                            finally
                            {
                                Var.popThreadBindings();
                            }
                        }
                    }
                }

                if ( bodyExpr == null )
                    bodyExpr = (new BodyExpr.Parser()).Parse(RT.seq(body), pcon.SetAssign(false));
                return new TryExpr(bodyExpr, catches, finallyExpr, retLocal, finallyLocal);
              }
        }

        #endregion

        #region Code generation

        public override Expression GenDlr(GenContext context)
        {
            Expression basicBody = _tryExpr.GenDlr(context);
            if (basicBody.Type == typeof(void))
                basicBody = Expression.Block(basicBody, Expression.Default(typeof(object)));
            Expression tryBody = Expression.Convert(basicBody,typeof(object));

            CatchBlock[] catches = new CatchBlock[_catchExprs.count()];
            for ( int i=0; i<_catchExprs.count(); i++ )
            {
                CatchClause clause = (CatchClause) _catchExprs.nth(i);
                ParameterExpression parmExpr = Expression.Parameter(clause.Type, clause.Lb.Name);
                clause.Lb.ParamExpression = parmExpr;
                catches[i] = Expression.Catch(parmExpr, Expression.Convert(clause.Handler.GenDlr(context), typeof(object)));
            }

            TryExpression tryStmt = _finallyExpr == null
                ? Expression.TryCatch(tryBody, catches)
                : Expression.TryCatchFinally(tryBody, _finallyExpr.GenDlr(context), catches);

            return tryStmt;
        }

        #endregion
    }
}
