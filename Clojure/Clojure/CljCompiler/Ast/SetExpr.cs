﻿/**
 *   Copyright (c) David Miller. All rights reserved.
 *   The use and distribution terms for this software are covered by the
 *   Eclipse Public License 1.0 (http://opensource.org/licenses/eclipse-1.0.php)
 *   which can be found in the file epl-v10.html at the root of this distribution.
 *   By using this software in any fashion, you are agreeing to be bound by
 * 	 the terms of this license.
 *   You must not remove this notice, or any other, from this software.
 **/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Linq.Expressions;

namespace clojure.lang.CljCompiler.Ast
{
    class SetExpr : Expr
    {
        #region Data

        readonly IPersistentVector _keys;

        #endregion

        #region Ctors

        public SetExpr(IPersistentVector keys)
        {
            _keys = keys;
        }

        #endregion

        #region Type mangling

        public override bool HasClrType
        {
            get { return true; }
        }

        public override Type ClrType
        {
            get { return typeof(IPersistentSet); }
        }

        #endregion
        
        #region Parsing

        public static Expr Parse(IPersistentSet form)
        {
            IPersistentVector keys = PersistentVector.EMPTY;
            for (ISeq s = RT.seq(form); s != null; s = s.next())
            {
                object e = s.first();
                keys = (IPersistentVector)keys.cons(Compiler.GenerateAST(e,false));
            }
            Expr ret = new SetExpr(keys);
            return Compiler.OptionallyGenerateMetaInit(form, ret);
        }

        #endregion

        #region Code generation

        public override Expression GenDlr(GenContext context)
        {
            Expression argArray = Compiler.GenArgArray(context, _keys);
            Expression ret = Expression.Call(Compiler.Method_RT_set, argArray);
            return ret;
        }

        #endregion
    }
}
