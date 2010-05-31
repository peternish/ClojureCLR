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
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if CLR2
using Microsoft.Scripting.Ast;
#else
using System.Linq.Expressions;
#endif


namespace clojure.lang.CljCompiler.Ast
{
    sealed class LocalBinding
    {
        #region Data

        private readonly Symbol _sym;
        public Symbol Symbol
        {
            get { return _sym; }
        }

        private readonly Symbol _tag;
        public Symbol Tag
        {
            get { return _tag; }
        }

        private Expr _init;
        public Expr Init
        {
            get { return _init; }
            set { _init = value; }
        }

        private readonly String _name;
        public String Name
        {
            get { return _name; }
        }

        private readonly int _index;
        public int Index
        {
            get { return _index; }
        }

        private Expression _paramExpression;
        public Expression ParamExpression
        {
            get { return _paramExpression; }
            set { _paramExpression = value; }
        }

        readonly bool _isArg;
        public bool IsArg
        {
            get { return _isArg; }
        }

        readonly bool _isByRef;

        public bool IsByRef
        {
            get { return _isByRef; }
        } 




        #endregion

        #region C-tors

        public LocalBinding(int index, Symbol sym, Symbol tag, Expr init, bool isArg, bool isByRef)
        {
            if (Compiler.MaybePrimitiveType(init) != null && tag != null)
                throw new InvalidOperationException("Can't type hint a local with a primitive initializer");

            _index = index;
            _sym = sym;
            _tag = tag;
            _init = init;
            _name = Compiler.munge(sym.Name);
            _isArg = isArg;
            _isByRef = isByRef;
        }

        #endregion

        #region Type mangling

        public bool HasClrType
        {
            get
            {
                if (_init != null
                    && Init.HasClrType
                    && Util.IsPrimitive(_init.ClrType)
                    && !(_init is MaybePrimitiveExpr))
                    return false;

                return _tag != null || (_init != null && _init.HasClrType);
            }
        }

        public Type ClrType
        {
            get
            {
                return _tag != null
                    ? HostExpr.TagToType(_tag)
                    : _init != null
                    ? _init.ClrType
                    : null;
            }
        }

        public Type PrimitiveType
        {
            get { return Compiler.MaybePrimitiveType(_init); }
        }

        #endregion
    }
}
