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

namespace clojure.lang
{
    [Serializable]
    public abstract class RestFn : AFunction
    {
        #region Interface

        public abstract int getRequiredArity();

        #endregion

        #region Invokes with explicit rest arg

        protected virtual object doInvoke(object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object arg4, object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object arg4, object arg5, object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7,
                                  object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7,
                                  object arg8, object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7,
                                  object arg8, object arg9, object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7,
                                  object arg8, object arg9, object arg10, object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7,
                                  object arg8, object arg9, object arg10, object arg11, object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7,
                                  object arg8, object arg9, object arg10, object arg11, object arg12, object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7,
                                  object arg8, object arg9, object arg10, object arg11, object arg12, object arg13, object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7,
                                  object arg8, object arg9, object arg10, object arg11, object arg12, object arg13,
                                  object arg14, object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7,
                                  object arg8, object arg9, object arg10, object arg11, object arg12, object arg13,
                                  object arg14, object arg15, object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7,
                                  object arg8, object arg9, object arg10, object arg11, object arg12, object arg13,
                                  object arg14, object arg15, object arg16, object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7,
                                  object arg8, object arg9, object arg10, object arg11, object arg12, object arg13,
                                  object arg14, object arg15, object arg16, object arg17, object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7,
                                  object arg8, object arg9, object arg10, object arg11, object arg12, object arg13,
                                  object arg14, object arg15, object arg16, object arg17, object arg18, object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7,
                                  object arg8, object arg9, object arg10, object arg11, object arg12, object arg13,
                                  object arg14, object arg15, object arg16, object arg17, object arg18, object arg19,
                                  object args)
        {
            return null;
        }

        protected virtual object doInvoke(object arg1, object arg2, object arg3, object arg4, object arg5, object arg6, object arg7,
                                  object arg8, object arg9, object arg10, object arg11, object arg12, object arg13,
                                  object arg14, object arg15, object arg16, object arg17, object arg18, object arg19,
                                  object arg20, object args)
        {
            return null;
        }

        #endregion

        #region IFn members

        public override object applyTo(ISeq args)
        {
            int reqArity = getRequiredArity();

            if (RT.BoundedLength(args, reqArity) <= reqArity)
                return AFn.ApplyToHelper(this, Util.Ret1(args, args = null));

            switch (reqArity)
            {
                case 0:
                    return doInvoke(Util.Ret1(args, args = null));
                case 1:
                    return doInvoke(args.first()
                            , Util.Ret1(args.next(), args = null));
                case 2:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 3:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 4:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 5:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 6:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 7:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 8:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 9:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 10:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 11:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 12:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 13:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 14:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 15:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 16:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 17:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 18:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 19:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));
                case 20:
                    return doInvoke(args.first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , (args = args.next()).first()
                            , Util.Ret1(args.next(), args = null));

            }
            throw WrongArityException();
        }


        public override Object invoke()
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(ArraySeq.create(Util.Ret1(arg1,arg1=null)));
                case 1:
                    return doInvoke(Util.Ret1(arg1, arg1 = null), null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(   
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null),
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg4, arg4 = null)));
                case 4:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4, Object arg5)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null),
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null)));
                case 4:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg5, arg5 = null)));
                case 5:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4, Object arg5, Object arg6)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(    
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null)));
                case 4:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg5, arg5 = null),
                            Util.Ret1(arg6, arg6 = null)));
                case 5:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg6, arg6 = null)));
                case 6:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4, Object arg5, Object arg6, Object arg7)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null)));
                case 4:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null)));
                case 5:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        ArraySeq.create(    
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null)));
                case 6:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg7, arg7 = null)));
                case 7:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4, Object arg5, Object arg6, Object arg7,
                             Object arg8)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null)));
                case 4:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null)));
                case 5:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null)));
                case 6:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null)));
                case 7:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg8, arg8 = null)));
                case 8:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4, Object arg5, Object arg6, Object arg7,
                             Object arg8, Object arg9)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(
                            Util.Ret1(arg1, arg1 = null),
                            Util.Ret1(arg2, arg2 = null),
                            Util.Ret1(arg3, arg3 = null),
                            Util.Ret1(arg4, arg4 = null),
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null),
                        ArraySeq.create(
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null)));
                case 4:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null),
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null)));
                case 5:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null),
                        ArraySeq.create(
                            Util.Ret1(arg6, arg6 = null),
                            Util.Ret1(arg7, arg7 = null),
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null)));
                case 6:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg7, arg7 = null),
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null)));
                case 7:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        ArraySeq.create(
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null)));
                case 8:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        ArraySeq.create(
                            Util.Ret1(arg9, arg9 = null)));
                case 9:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4, Object arg5, Object arg6, Object arg7,
                             Object arg8, Object arg9, Object arg10)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null),
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null),
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null),
                            Util.Ret1(arg10, arg10 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null),
                            Util.Ret1(arg7, arg7 = null),
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null),
                            Util.Ret1(arg10, arg10 = null)));
                case 4:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        ArraySeq.create(
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null),
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null)));
                case 5:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null)));
                case 6:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null),
                            Util.Ret1(arg10, arg10 = null)));
                case 7:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null)));
                case 8:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null)));
                case 9:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null));
                case 10:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4, Object arg5, Object arg6, Object arg7,
                             Object arg8, Object arg9, Object arg10, Object arg11)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null),
                            Util.Ret1(arg6, arg6 = null),
                            Util.Ret1(arg7, arg7 = null),
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null),
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null),
                            Util.Ret1(arg4, arg4 = null),
                            Util.Ret1(arg5, arg5 = null),
                            Util.Ret1(arg6, arg6 = null),
                            Util.Ret1(arg7, arg7 = null),
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null),
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null)));
                case 4:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null)));
                case 5:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg6, arg6 = null),
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null),
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null)));
                case 6:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null),
                        ArraySeq.create(
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null)));
                case 7:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        ArraySeq.create(
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null)));
                case 8:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null),
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        ArraySeq.create(
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null)));
                case 9:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null)));
                case 10:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg11, arg11 = null)));
                case 11:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4, Object arg5, Object arg6, Object arg7,
                             Object arg8, Object arg9, Object arg10, Object arg11, Object arg12)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null),
                            Util.Ret1(arg6, arg6 = null),
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null),
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null),
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null),
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null)));
                case 4:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null),
                            Util.Ret1(arg7, arg7 = null),
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null),
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null)));
                case 5:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null)));
                case 6:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg7, arg7 = null),
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null),
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null)));
                case 7:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        ArraySeq.create(
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null)));
                case 8:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null)));
                case 9:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null)));
                case 10:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null)));
                case 11:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg12, arg12 = null)));
                case 12:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4, Object arg5, Object arg6, Object arg7,
                             Object arg8, Object arg9, Object arg10, Object arg11, Object arg12, Object arg13)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                            ArraySeq.create(
                                Util.Ret1(arg1, arg1 = null), 
                                Util.Ret1(arg2, arg2 = null), 
                                Util.Ret1(arg3, arg3 = null), 
                                Util.Ret1(arg4, arg4 = null), 
                                Util.Ret1(arg5, arg5 = null), 
                                Util.Ret1(arg6, arg6 = null), 
                                Util.Ret1(arg7, arg7 = null), 
                                Util.Ret1(arg8, arg8 = null), 
                                Util.Ret1(arg9, arg9 = null), 
                                Util.Ret1(arg10, arg10 = null), 
                                Util.Ret1(arg11, arg11 = null), 
                                Util.Ret1(arg12, arg12 = null), 
                                Util.Ret1(arg13, arg13 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null),
                        ArraySeq.create(
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null),
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null)));
                case 4:
                    return doInvoke(
                            Util.Ret1(arg1, arg1 = null),
                            Util.Ret1(arg2, arg2 = null),
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null),
                            ArraySeq.create(
                                Util.Ret1(arg5, arg5 = null),
                                Util.Ret1(arg6, arg6 = null),
                                Util.Ret1(arg7, arg7 = null), 
                                Util.Ret1(arg8, arg8 = null), 
                                Util.Ret1(arg9, arg9 = null),
                                Util.Ret1(arg10, arg10 = null),
                                Util.Ret1(arg11, arg11 = null),
                                Util.Ret1(arg12, arg12 = null), 
                                Util.Ret1(arg13, arg13 = null)));
                case 5:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        ArraySeq.create(
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null),
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null)));
                case 6:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null),
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        ArraySeq.create(
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null)));
                case 7:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null),
                        ArraySeq.create(
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null)));
                case 8:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null),
                        ArraySeq.create(
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null)));
                case 9:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null),
                        ArraySeq.create(
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null)));
                case 10:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null),
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null),
                        ArraySeq.create(
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null)));
                case 11:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        ArraySeq.create(
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null)));
                case 12:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg13, arg13 = null)));
                case 13:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4, Object arg5, Object arg6, Object arg7,
                             Object arg8, Object arg9, Object arg10, Object arg11, Object arg12, Object arg13, Object arg14)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null),
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null),
                        ArraySeq.create(
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null)));
                case 4:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        ArraySeq.create(
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null)));
                case 5:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        ArraySeq.create(
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null),
                            Util.Ret1(arg14, arg14 = null)));
                case 6:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        ArraySeq.create(
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null)));
                case 7:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null),
                        ArraySeq.create(
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null)));
                case 8:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        ArraySeq.create(
                            Util.Ret1(arg9, arg9 = null),
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null)));
                case 9:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null),
                        ArraySeq.create(
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null)));
                case 10:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        ArraySeq.create(
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null)));
                case 11:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null),
                        ArraySeq.create(
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null)));
                case 12:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null),
                        ArraySeq.create(
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null)));
                case 13:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null),
                        Util.Ret1(arg13, arg13 = null),
                        ArraySeq.create(
                            Util.Ret1(arg14, arg14 = null)));
                case 14:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4, Object arg5, Object arg6, Object arg7,
                             Object arg8, Object arg9, Object arg10, Object arg11, Object arg12, Object arg13, Object arg14,
                             Object arg15)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null),
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null),
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null),
                            Util.Ret1(arg14, arg14 = null),
                            Util.Ret1(arg15, arg15 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null),
                            Util.Ret1(arg5, arg5 = null),
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null),
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null)));
                case 4:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        ArraySeq.create(
                            Util.Ret1(arg5, arg5 = null),
                            Util.Ret1(arg6, arg6 = null),
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null)));
                case 5:
                    return doInvoke(
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null),
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null),
                            Util.Ret1(arg5, arg5 = null),
                            ArraySeq.create(
                                Util.Ret1(arg6, arg6 = null), 
                                Util.Ret1(arg7, arg7 = null), 
                                Util.Ret1(arg8, arg8 = null), 
                                Util.Ret1(arg9, arg9 = null), 
                                Util.Ret1(arg10, arg10 = null),
                                Util.Ret1(arg11, arg11 = null),
                                Util.Ret1(arg12, arg12 = null), 
                                Util.Ret1(arg13, arg13 = null), 
                                Util.Ret1(arg14, arg14 = null),
                                Util.Ret1(arg15, arg15 = null)));
                case 6:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        ArraySeq.create(
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null),
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null)));
                case 7:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null),
                        ArraySeq.create(
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null)));
                case 8:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        ArraySeq.create(
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null),
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null)));
                case 9:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null),
                        ArraySeq.create(
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null)));
                case 10:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        ArraySeq.create(
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null)));
                case 11:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null),
                        ArraySeq.create(
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null)));
                case 12:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null),
                        ArraySeq.create(
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null)));
                case 13:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null),
                        ArraySeq.create(
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null)));
                case 14:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        ArraySeq.create(
                            Util.Ret1(arg15, arg15 = null)));
                case 15:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4, Object arg5, Object arg6, Object arg7,
                             Object arg8, Object arg9, Object arg10, Object arg11, Object arg12, Object arg13, Object arg14,
                             Object arg15, Object arg16)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null),
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null)));
                case 4:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null)));
                case 5:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        ArraySeq.create(
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null),
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null),
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null)));
                case 6:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null),
                        ArraySeq.create(
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null)));
                case 7:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null),
                        ArraySeq.create(
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null),
                            Util.Ret1(arg14, arg14 = null),
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null)));
                case 8:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null),
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null),
                        ArraySeq.create(
                            Util.Ret1(arg9, arg9 = null),
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null)));
                case 9:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null),
                        ArraySeq.create(
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null),
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null)));
                case 10:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        ArraySeq.create(
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null)));
                case 11:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        ArraySeq.create(
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null),
                            Util.Ret1(arg14, arg14 = null),
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null)));
                case 12:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null),
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null),
                        ArraySeq.create(
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null)));
                case 13:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null),
                        ArraySeq.create(
                            Util.Ret1(arg14, arg14 = null),
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null)));
                case 14:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        ArraySeq.create(
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null)));
                case 15:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg16, arg16 = null)));
                case 16:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        Util.Ret1(arg16, arg16 = null),
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4, Object arg5, Object arg6, Object arg7,
                             Object arg8, Object arg9, Object arg10, Object arg11, Object arg12, Object arg13, Object arg14,
                             Object arg15, Object arg16, Object arg17)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null),
                            Util.Ret1(arg3, arg3 = null),
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null),
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null),
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),                                                          
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null)));
                case 4:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null),
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null)));
                case 5:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null)));
                case 6:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        ArraySeq.create(
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null)));
                case 7:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        ArraySeq.create(
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null)));
                case 8:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        ArraySeq.create(
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null)));
                case 9:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null),
                        ArraySeq.create(
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null),
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null)));
                case 10:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null),
                        ArraySeq.create(
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null),
                            Util.Ret1(arg17, arg17 = null)));
                case 11:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        ArraySeq.create(
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null)));
                case 12:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null),
                        ArraySeq.create(
                            Util.Ret1(arg13, arg13 = null),
                            Util.Ret1(arg14, arg14 = null),
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null),
                            Util.Ret1(arg17, arg17 = null)));
                case 13:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null),
                        Util.Ret1(arg13, arg13 = null),                                
                        ArraySeq.create(
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null),
                            Util.Ret1(arg17, arg17 = null)));
                case 14:
                    return doInvoke(
                    Util.Ret1(arg1, arg1 = null),
                    Util.Ret1(arg2, arg2 = null),
                    Util.Ret1(arg3, arg3 = null),
                    Util.Ret1(arg4, arg4 = null),
                    Util.Ret1(arg5, arg5 = null),
                    Util.Ret1(arg6, arg6 = null),
                    Util.Ret1(arg7, arg7 = null),
                    Util.Ret1(arg8, arg8 = null),
                    Util.Ret1(arg9, arg9 = null),
                    Util.Ret1(arg10, arg10 = null),
                    Util.Ret1(arg11, arg11 = null), 
                    Util.Ret1(arg12, arg12 = null), 
                    Util.Ret1(arg13, arg13 = null),
                    Util.Ret1(arg14, arg14 = null),
                    ArraySeq.create(
                        Util.Ret1(arg15, arg15 = null), 
                        Util.Ret1(arg16, arg16 = null), 
                        Util.Ret1(arg17, arg17 = null)));
                case 15:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null),
                        Util.Ret1(arg13, arg13 = null),
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null),
                        ArraySeq.create(
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null)));
                case 16:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null),
                        Util.Ret1(arg13, arg13 = null),
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null),
                        Util.Ret1(arg16, arg16 = null),
                        ArraySeq.create(
                            Util.Ret1(arg17, arg17 = null)));
                case 17:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null),
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null),
                        Util.Ret1(arg16, arg16 = null),
                        Util.Ret1(arg17, arg17 = null),
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4, Object arg5, Object arg6, Object arg7,
                             Object arg8, Object arg9, Object arg10, Object arg11, Object arg12, Object arg13, Object arg14,
                             Object arg15, Object arg16, Object arg17, Object arg18)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(
                            Util.Ret1(arg1, arg1 = null), Util.Ret1(arg2, arg2 = null), Util.Ret1(arg3, arg3 = null), Util.Ret1(arg4, arg4 = null), Util.Ret1(arg5, arg5 = null), Util.Ret1(arg6, arg6 = null), Util.Ret1(arg7, arg7 = null), Util.Ret1(arg8, arg8 = null), Util.Ret1(arg9, arg9 = null), Util.Ret1(arg10, arg10 = null), Util.Ret1(arg11, arg11 = null), Util.Ret1(arg12, arg12 = null),
                                                    Util.Ret1(arg13, arg13 = null), Util.Ret1(arg14, arg14 = null), Util.Ret1(arg15, arg15 = null), Util.Ret1(arg16, arg16 = null), Util.Ret1(arg17, arg17 = null), Util.Ret1(arg18, arg18 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null),
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null),
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null),
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null)));
                case 4:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null)));
                case 5:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null),
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null),
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null)));
                case 6:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null),
                            Util.Ret1(arg14, arg14 = null),
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null),
                            Util.Ret1(arg18, arg18 = null)));
                case 7:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null),
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null),
                        ArraySeq.create(
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null)));
                case 8:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        ArraySeq.create(
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null)));
                case 9:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        ArraySeq.create(
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null)));
                case 10:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        ArraySeq.create(
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null)));
                case 11:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        ArraySeq.create(
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null)));
                case 12:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null),
                        ArraySeq.create(
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null)));
                case 13:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null),
                        Util.Ret1(arg13, arg13 = null),
                        ArraySeq.create(
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null),
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null)));
                case 14:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        ArraySeq.create(
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null),
                            Util.Ret1(arg18, arg18 = null)));
                case 15:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null)));
                case 16:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null),
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null),
                        Util.Ret1(arg16, arg16 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null)));
                case 17:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null),
                        Util.Ret1(arg13, arg13 = null),
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null),
                        Util.Ret1(arg16, arg16 = null), 
                        Util.Ret1(arg17, arg17 = null),
                        ArraySeq.create(
                            Util.Ret1(arg18, arg18 = null)));
                case 18:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null),
                        Util.Ret1(arg16, arg16 = null), 
                        Util.Ret1(arg17, arg17 = null),
                        Util.Ret1(arg18, arg18 = null),
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4, Object arg5, Object arg6, Object arg7,
                             Object arg8, Object arg9, Object arg10, Object arg11, Object arg12, Object arg13, Object arg14,
                             Object arg15, Object arg16, Object arg17, Object arg18, Object arg19)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null),
                            Util.Ret1(arg19, arg19 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null),
                            Util.Ret1(arg19, arg19 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null)));
                case 4:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null)));
                case 5:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null),
                            Util.Ret1(arg19, arg19 = null)));
                case 6:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null),
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null)));
                case 7:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null),
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null)));
                case 8:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null),
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null),
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null)));
                case 9:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null),
                        ArraySeq.create(
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null),
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null)));
                case 10:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        ArraySeq.create(
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null)));
                case 11:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        ArraySeq.create(
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null)));
                case 12:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null),
                        ArraySeq.create(
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null)));
                case 13:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null),
                        ArraySeq.create(
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null)));
                case 14:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null),
                        Util.Ret1(arg14, arg14 = null),
                        ArraySeq.create(
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null)));
                case 15:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null),
                        ArraySeq.create(
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null)));
                case 16:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null),
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        Util.Ret1(arg16, arg16 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null)));
                case 17:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null),
                        Util.Ret1(arg13, arg13 = null),
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        Util.Ret1(arg16, arg16 = null), 
                        Util.Ret1(arg17, arg17 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null)));
                case 18:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        Util.Ret1(arg16, arg16 = null),
                        Util.Ret1(arg17, arg17 = null), 
                        Util.Ret1(arg18, arg18 = null),
                        ArraySeq.create(
                            Util.Ret1(arg19, arg19 = null)));
                case 19:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        Util.Ret1(arg16, arg16 = null), 
                        Util.Ret1(arg17, arg17 = null), 
                        Util.Ret1(arg18, arg18 = null), 
                        Util.Ret1(arg19, arg19 = null), 
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4, Object arg5, Object arg6, Object arg7,
                             Object arg8, Object arg9, Object arg10, Object arg11, Object arg12, Object arg13, Object arg14,
                             Object arg15, Object arg16, Object arg17, Object arg18, Object arg19, Object arg20)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        ArraySeq.create(
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null),
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 4:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null),
                            Util.Ret1(arg20, arg20 = null)));
                case 5:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null),
                            Util.Ret1(arg19, arg19 = null),
                            Util.Ret1(arg20, arg20 = null)));
                case 6:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null),
                            Util.Ret1(arg17, arg17 = null),
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 7:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null),
                            Util.Ret1(arg14, arg14 = null),
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null),
                            Util.Ret1(arg17, arg17 = null),
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 8:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null),
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null),   
                            Util.Ret1(arg20, arg20 = null)));
                case 9:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null),
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 10:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        ArraySeq.create(
                            Util.Ret1(arg11, arg11 = null), 
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null),
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 11:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null),
                        ArraySeq.create(
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 12:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null),
                        ArraySeq.create(
                        Util.Ret1(arg13, arg13 = null),
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null),
                        Util.Ret1(arg16, arg16 = null),
                        Util.Ret1(arg17, arg17 = null),
                        Util.Ret1(arg18, arg18 = null),
                        Util.Ret1(arg19, arg19 = null),
                        Util.Ret1(arg20, arg20 = null)));
                case 13:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null),
                        ArraySeq.create(
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null),
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null),
                            Util.Ret1(arg20, arg20 = null)));
                case 14:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        ArraySeq.create(
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null),
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 15:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 16:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null),
                        Util.Ret1(arg13, arg13 = null),
                        Util.Ret1(arg14, arg14 = null),  
                        Util.Ret1(arg15, arg15 = null), 
                        Util.Ret1(arg16, arg16 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 17:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        Util.Ret1(arg16, arg16 = null), 
                        Util.Ret1(arg17, arg17 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 18:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        Util.Ret1(arg16, arg16 = null), 
                        Util.Ret1(arg17, arg17 = null), 
                        Util.Ret1(arg18, arg18 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 19:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null),
                        Util.Ret1(arg13, arg13 = null),
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        Util.Ret1(arg16, arg16 = null), 
                        Util.Ret1(arg17, arg17 = null),
                        Util.Ret1(arg18, arg18 = null), 
                        Util.Ret1(arg19, arg19 = null), 
                        ArraySeq.create(
                            Util.Ret1(arg20, arg20 = null)));
                case 20:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        Util.Ret1(arg16, arg16 = null), 
                        Util.Ret1(arg17, arg17 = null), 
                        Util.Ret1(arg18, arg18 = null), 
                        Util.Ret1(arg19, arg19 = null), 
                        Util.Ret1(arg20, arg20 = null), 
                        null);
                default:
                    throw WrongArityException();
            }

        }

        public override Object invoke(Object arg1, Object arg2, Object arg3, Object arg4, Object arg5, Object arg6, Object arg7,
                             Object arg8, Object arg9, Object arg10, Object arg11, Object arg12, Object arg13, Object arg14,
                             Object arg15, Object arg16, Object arg17, Object arg18, Object arg19, Object arg20, params object[] args)
        {
            switch (getRequiredArity())
            {
                case 0:
                    return doInvoke(
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg1, arg1 = null), 
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null),
                            Util.Ret1(arg5, arg5 = null),
                            Util.Ret1(arg6, arg6 = null),
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null),
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null),
                            Util.Ret1(arg19, arg19 = null),
                            Util.Ret1(arg20, arg20 = null)));
                case 1:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        OntoArrayPrepend(  
                            args, 
                            Util.Ret1(arg2, arg2 = null), 
                            Util.Ret1(arg3, arg3 = null),
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null),
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null),
                            Util.Ret1(arg14, arg14 = null),
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null),
                            Util.Ret1(arg17, arg17 = null),
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null),
                            Util.Ret1(arg20, arg20 = null)));
                case 2:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        OntoArrayPrepend(
                            args,
                            Util.Ret1(arg3, arg3 = null), 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null),
                            Util.Ret1(arg20, arg20 = null)));
                case 3:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null),
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg4, arg4 = null), 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null),
                            Util.Ret1(arg20, arg20 = null)));
                case 4:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg5, arg5 = null), 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null),
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 5:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null),
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg6, arg6 = null), 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null),
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 6:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null),
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg7, arg7 = null), 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null),
                            Util.Ret1(arg17, arg17 = null),
                            Util.Ret1(arg18, arg18 = null),
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 7:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null),
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg8, arg8 = null), 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null),
                            Util.Ret1(arg20, arg20 = null)));
                case 8:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg9, arg9 = null), 
                            Util.Ret1(arg10, arg10 = null),
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null),
                            Util.Ret1(arg20, arg20 = null)));
                case 9:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg10, arg10 = null), 
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null),
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null),
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null),
                            Util.Ret1(arg20, arg20 = null)));
                case 10:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg11, arg11 = null),
                            Util.Ret1(arg12, arg12 = null), 
                            Util.Ret1(arg13, arg13 = null),
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null),
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null),
                            Util.Ret1(arg18, arg18 = null),
                            Util.Ret1(arg19, arg19 = null),
                            Util.Ret1(arg20, arg20 = null)));
                case 11:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg12, arg12 = null),
                            Util.Ret1(arg13, arg13 = null),
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null),
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 12:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null),
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg13, arg13 = null), 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 13:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null),
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg14, arg14 = null), 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 14:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg15, arg15 = null), 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 15:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null),
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg16, arg16 = null), 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 16:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null),
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null),
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null),
                        Util.Ret1(arg9, arg9 = null),
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null),
                        Util.Ret1(arg16, arg16 = null), 
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg17, arg17 = null), 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 17:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null),
                        Util.Ret1(arg7, arg7 = null),
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        Util.Ret1(arg16, arg16 = null), 
                        Util.Ret1(arg17, arg17 = null), 
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg18, arg18 = null), 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 18:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null),
                        Util.Ret1(arg11, arg11 = null),
                        Util.Ret1(arg12, arg12 = null),
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        Util.Ret1(arg16, arg16 = null), 
                        Util.Ret1(arg17, arg17 = null), 
                        Util.Ret1(arg18, arg18 = null), 
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg19, arg19 = null), 
                            Util.Ret1(arg20, arg20 = null)));
                case 19:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        Util.Ret1(arg16, arg16 = null), 
                        Util.Ret1(arg17, arg17 = null), 
                        Util.Ret1(arg18, arg18 = null), 
                        Util.Ret1(arg19, arg19 = null), 
                        OntoArrayPrepend(
                            args, 
                            Util.Ret1(arg20, arg20 = null)));
                case 20:
                    return doInvoke(
                        Util.Ret1(arg1, arg1 = null), 
                        Util.Ret1(arg2, arg2 = null), 
                        Util.Ret1(arg3, arg3 = null), 
                        Util.Ret1(arg4, arg4 = null), 
                        Util.Ret1(arg5, arg5 = null), 
                        Util.Ret1(arg6, arg6 = null), 
                        Util.Ret1(arg7, arg7 = null), 
                        Util.Ret1(arg8, arg8 = null), 
                        Util.Ret1(arg9, arg9 = null), 
                        Util.Ret1(arg10, arg10 = null), 
                        Util.Ret1(arg11, arg11 = null), 
                        Util.Ret1(arg12, arg12 = null), 
                        Util.Ret1(arg13, arg13 = null), 
                        Util.Ret1(arg14, arg14 = null),
                        Util.Ret1(arg15, arg15 = null), 
                        Util.Ret1(arg16, arg16 = null),
                        Util.Ret1(arg17, arg17 = null),
                        Util.Ret1(arg18, arg18 = null), 
                        Util.Ret1(arg19, arg19 = null), 
                        Util.Ret1(arg20, arg20 = null), 
                        ArraySeq.create(args));
                default:
                    throw WrongArityException();
            }

        }


        protected static ISeq OntoArrayPrepend(object[] array, params object[] args)
        {
            ISeq ret = ArraySeq.create(array);
            for (int i = args.Length - 1; i >= 0; --i)
                ret = RT.cons(args[i], ret);
            return ret;
        }

        #endregion

        #region Misc

        // do we need this?
        protected static ISeq FindKey(object key, ISeq args)
        {
            while (args != null)
            {
                if (key == args.first())
                    return args.next();
                args = RT.next(args);
                args = RT.next(args);
            }
            return null;
        }

        #endregion
    }
}
