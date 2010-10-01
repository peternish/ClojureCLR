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
    class EmptyExpr : Expr
    {
        #region Data

        readonly object _coll;

        #endregion

        #region Ctors

        public EmptyExpr(object coll)
        {
            _coll = coll;
        }

        #endregion

        #region Type mangling

        public bool HasClrType
        {
            get { return true; }
        }

        public Type ClrType
        {
            get {
                if (_coll is IPersistentList)
                    return typeof(IPersistentList);
                else if (_coll is IPersistentVector)
                    return typeof(IPersistentVector);
                else if (_coll is IPersistentMap)
                    return typeof(IPersistentMap);
                else if (_coll is IPersistentSet)
                    return typeof(IPersistentSet);
                else
                    throw new InvalidOperationException("Unknown Collection type.");
            }
        }

        #endregion

        #region eval

        public object Eval()
        {
            return _coll;
        }

        #endregion

        #region Code generation

        public Expression GenCode(RHC rhc, ObjExpr objx, GenContext context)
        {
            Type collType;

            if (_coll is IPersistentList)
                collType = typeof(PersistentList);
            else if (_coll is IPersistentVector)
                collType = typeof(PersistentVector);
            else if (_coll is IPersistentMap)
                collType = typeof(PersistentArrayMap);
            else if (_coll is IPersistentSet)
                collType = typeof(PersistentHashSet);
            else
                throw new InvalidOperationException("Unknown collection type.");

            return Expression.Field(null, collType, "EMPTY");
        }

        #endregion
    }
}
