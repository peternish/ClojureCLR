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
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace clojure.lang
{
    /// <summary>
    /// Represents a keyword
    /// </summary>
    [Serializable]
    public sealed class Keyword: AFn, Named, IComparable, ISerializable // ??JAVA only used IFn, not AFn.  NOt sure why.
    {
        #region Data

        /// <summary>
        /// The symbol giving the namespace/name (without :) of the keyword.
        /// </summary>
        private readonly Symbol _sym;

        /// <summary>
        /// Caches the hash value for the keyword.
        /// </summary>
        readonly int _hash;

        /// <summary>
        /// Map from symbol to keyword to uniquify keywords.
        /// </summary>
        /// <remarks>Why introduce the JavaConcurrentDictionary?  
        /// We really only need a synchronized hash table with one operation: PutIfAbsent.</remarks>
        private static JavaConcurrentDictionary<Symbol,WeakReference> _symKeyMap
            = new JavaConcurrentDictionary<Symbol, WeakReference>();

        internal Symbol Symbol
        {
          get { return _sym; }
        }

        #endregion

        #region C-tors and factory methods

        /// <summary>
        /// Create (or find existing) keyword with given symbol's namespace/name.
        /// </summary>
        /// <param name="sym">The symbol giving the keyword's namespace/name.</param>
        /// <returns>A keyword</returns>
        public static Keyword intern(Symbol sym)
        {
            // TODO: Analyze this code for improvements
            Keyword k = new Keyword(sym);
            //Keyword existing = _symKeyMap.PutIfAbsent(sym, k);
            //return existing == null ? k : existing;
            WeakReference wr = new WeakReference(k);
            wr.Target = k;
            WeakReference existingRef = _symKeyMap.PutIfAbsent(sym, wr);
            if (existingRef == null)
                return k;
            Keyword existingk = (Keyword)existingRef.Target;
            if (existingk != null)
                return existingk;
            // entry died in the interim, do over
            // let's not get confused, remove it.  (else infinite loop).
            _symKeyMap.Remove(sym);
            return intern(sym);
        }

        /// <summary>
        /// Create (or find existing) keyword with given namespace/name.
        /// </summary>
        /// <param name="ns">The keyword's namespace name.</param>
        /// <param name="name">The keyword's name.</param>
        /// <returns>A keyword</returns>
        public static Keyword intern(string ns, string name)
        {
            return intern(Symbol.intern(ns, name));
        }

        /// <summary>
        /// Create (or find existing) keyword with the given name.
        /// </summary>
        /// <param name="nsname">The keyword's name</param>
        /// <returns>A keyword</returns>
        public static Keyword intern(String nsname)
        {
            return intern(Symbol.intern(nsname));
        }

        /// <summary>
        /// Construct a keyword based on a symbol.
        /// </summary>
        /// <param name="sym">A symbol giving namespace/name.</param>
        private Keyword(Symbol sym)
        {
            _sym = sym;
            _hash = (int)(_sym.GetHashCode() + 0x9e3779b9);
        }


        #endregion

        #region Object overrides

        /// <summary>
        /// Returns a string representing the keyword.
        /// </summary>
        /// <returns>A string representing the keyword.</returns>
        public override string ToString()
        {
            return ":" + _sym.ToString();
        }

        /// <summary>
        /// Determines if an object is equal to this keyword.  Value semantics.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns><value>true</value> if equal; <value>false</value> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if ( obj == this ) 
                return true;

            Keyword keyword = obj as Keyword;

            if (keyword == null)
                return false;

            return _sym.Equals(keyword.Symbol);
        }

        /// <summary>
        /// Gets a hash code for the keyword.
        /// </summary>
        /// <returns>A hash code.</returns>
        public override int GetHashCode()
        {
            return _hash;
        }

        #endregion

        #region Named Members

        //  I prefer to use the following internally.

        /// <summary>
        /// The namespace name.
        /// </summary>
        public string Namespace
        {
            get { return _sym.Namespace; }
        }

        /// <summary>
        /// The name.
        /// </summary>
        public string Name
        {
            get { return _sym.Name; }
        }

        // the following are in the interface


        /// <summary>
        /// Gets the namespace name.
        /// </summary>
        /// <returns>The namespace name.</returns>
        public string getNamespace()
        {
            return _sym.Namespace;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <returns>The name.</returns>
        public string getName()
        {
            return _sym.Name;
        }

        #endregion

        #region IFn Members

        /// <summary>
        /// (:keyword arg)  => (get arg :keyword)
        /// </summary>
        /// <param name="arg1">The object to access.</param>
        /// <returns>The value mapped to the keyword.</returns>
        public sealed override object invoke(object obj)
        {
            if (obj is ILookup)
                return ((ILookup)obj).valAt(this);
            return RT.get(obj, this);
        }


        /// <summary>
        /// (:keyword arg default) => (get arg :keyword default)
        /// </summary>
        /// <param name="arg1">The object to access.</param>
        /// <param name="arg2">Default value if not found.</param>
        /// <returns></returns>
        public sealed override object invoke(object obj, object notFound)
        {
            if (obj is ILookup)
                return ((ILookup)obj).valAt(this,notFound);
            return RT.get(obj, this, notFound);
        }


        #endregion

        #region IComparable Members

        /// <summary>
        /// Compare this to another object.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>neg,zero,pos for &lt; = &gt;</returns>
        public int CompareTo(object obj)
        {
            return _sym.CompareTo(((Keyword)obj)._sym);
        }

        #endregion

        #region ISerializable Members

        [SecurityPermissionAttribute(SecurityAction.LinkDemand,
            Flags = SecurityPermissionFlag.SerializationFormatter)]
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Instead of serializing the keyword,
            // serialize a KeywordSerializationHelper instead
            info.SetType(typeof(KeywordSerializationHelper));
            info.AddValue("_sym", _sym);
        }

        #endregion
    }

    [Serializable]
    sealed class KeywordSerializationHelper : IObjectReference
    {

        #region Data

        readonly Symbol _sym;

        #endregion

        #region c-tors

        KeywordSerializationHelper(SerializationInfo info, StreamingContext context)
        {
            _sym = (Symbol)info.GetValue("_sym", typeof(Symbol));
        }

        #endregion

        #region IObjectReference Members

        public object GetRealObject(StreamingContext context)
        {
            return Keyword.intern(_sym);
        }

        #endregion
    }
}
