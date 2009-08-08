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
using System.Threading;

namespace clojure.lang
{
    /// <summary>
    /// Implements a persistent vector using a specialized form of array-mapped hash trie.
    /// </summary>
    public class PersistentVector: APersistentVector, IEditableCollection
    {
        #region Node class

        class Node
        {
            #region Data

            readonly AtomicReference<Thread> _edit;

            public AtomicReference<Thread> Edit
            {
                get { return _edit; }
            } 

            readonly object[] _array;

            public object[] Array
            {
                get { return _array; }
            } 

            
            #endregion

            #region C-tors

            public Node(AtomicReference<Thread> edit, object[] array)
            {
                _edit = edit;
                _array = array;
            }

            public Node(AtomicReference<Thread> edit)
            {
                _edit = edit;
                _array = new object[32];
            }
        
            #endregion
        }

        #endregion

        #region Data

        static readonly AtomicReference<Thread> NOEDIT = new AtomicReference<Thread>(null);
        static readonly Node EMPTY_NODE = new Node(NOEDIT, new object[32]);

        readonly int _cnt;
        readonly int _shift;
        readonly Node _root;
        readonly object[] _tail;

        /// <summary>
        /// An empty <see cref="PersistentVector">PersistentVector</see>.
        /// </summary>
        static public readonly PersistentVector EMPTY = new PersistentVector(0,5,EMPTY_NODE, new object[0]);

        #endregion

        #region C-tors and factory methods

        /// <summary>
        /// Create a <see cref="PersistentVector">PersistentVector</see> from an <see cref="ISeq">ISeq</see>.
        /// </summary>
        /// <param name="items">A sequence of items.</param>
        /// <returns>An initialized vector.</returns>
        static public PersistentVector create(ISeq items)
        {
            IPersistentVector ret = EMPTY;
            for (; items != null; items = items.next())
                ret = ret.cons(items.first());
            return (PersistentVector)ret;
        }

        /// <summary>
        /// Create a <see cref="PersistentVector">PersistentVector</see> from an array of items.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        static public PersistentVector create(params object[] items)
        {
            IPersistentVector ret = EMPTY;
            foreach (object item in items)
                ret = ret.cons(item);
            return (PersistentVector)ret;
        }

        /// <summary>
        /// Initialize a <see cref="PersistentVector">PersistentVector</see> from basic components.
        /// </summary>
        /// <param name="cnt"></param>
        /// <param name="shift"></param>
        /// <param name="root"></param>
        /// <param name="tail"></param>
        PersistentVector(int cnt, int shift, Node root, object[] tail)
            : base(null)
        {
            _cnt = cnt;
            _shift = shift;
            _root = root;
            _tail = tail;
        }


        /// <summary>
        /// Initialize a <see cref="PersistentVector">PersistentVector</see> from given metadata and basic components.
        /// </summary>
        /// <param name="meta"></param>
        /// <param name="cnt"></param>
        /// <param name="shift"></param>
        /// <param name="root"></param>
        /// <param name="tail"></param>
        PersistentVector(IPersistentMap meta, int cnt, int shift, Node root, object[] tail)
            : base(meta)
        {
            _cnt = cnt;
            _shift = shift;
            _root = root;
            _tail = tail;
        }

        #endregion

        #region IObj members

        public override IObj withMeta(IPersistentMap meta)
        {
            // Java version does not do identity check
            return new PersistentVector(meta, _cnt, _shift, _root, _tail);
        }

        #endregion

        #region IPersistentVector members

        /// <summary>
        /// Gets the number of items in the vector.
        /// </summary>
        /// <returns>The number of items.</returns>
        /// <remarks>Not sure why you wouldn't use <c>count()</c> intead.</remarks>
        public override int length()
        {
            return count();
        }


        int tailoff()
        {
            if (_cnt < 32)
                return 0;
            return ((_cnt - 1) >> 5) << 5;
        }


        /// <summary>
        /// Get the i-th item in the vector.
        /// </summary>
        /// <param name="i">The index of the item to retrieve/</param>
        /// <returns>The i-th item</returns>
        /// <remarks>Throws an exception if the index <c>i</c> is not in the range of the vector's elements.</remarks>
        public override object nth(int i)
        {
            object[] node = ArrayFor(i);
            return node[i & 0x01f];
        }

        object[] ArrayFor(int i) 
        {
            if (i >= 0 && i < _cnt)
            {
                if (i >= tailoff())
                    return _tail;
                Node node = _root;
                for (int level = _shift; level > 0; level -= 5)
                    node = (Node)node.Array[(i >> level) & 0x01f];
                return node.Array;
            }
            throw new IndexOutOfRangeException();
        }


        /// <summary>
        /// Return a new vector with the i-th value set to <c>val</c>.
        /// </summary>
        /// <param name="i">The index of the item to set.</param>
        /// <param name="val">The new value</param>
        /// <returns>A new (immutable) vector v with v[i] == val.</returns>
        public override IPersistentVector assocN(int i, Object val)
        {
            if (i >= 0 && i < _cnt)
            {
                if (i >= tailoff())
                {
                    object[] newTail = new object[_tail.Length];
                    Array.Copy(_tail, newTail, _tail.Length);
                    newTail[i & 0x01f] = val;

                    return new PersistentVector(meta(), _cnt, _shift, _root, newTail);
                }

                return new PersistentVector(meta(), _cnt, _shift, doAssoc(_shift, _root, i, val), _tail);
            }
            if (i == _cnt)
                return cons(val);
            throw new IndexOutOfRangeException();
        }

        static private Node doAssoc(int level, Node node, int i, object val)
        {
            Node ret = new Node(node.Edit, (object[])node.Array.Clone());
            if (level == 0)
                ret.Array[i & 0x01f] = val;
            else
            {
                int subidx = ( i >> level ) & 0x01f;
                ret.Array[subidx] = doAssoc(level-5,(Node) node.Array[subidx], i, val);
            }
            return ret;
        }

        /// <summary>
        /// Creates a new vector with a new item at the end.
        /// </summary>
        /// <param name="o">The item to add to the vector.</param>
        /// <returns>A new (immutable) vector with the objected added at the end.</returns>
        /// <remarks>Overrides <c>cons</c> in <see cref="IPersistentCollection">IPersistentCollection</see> to specialize the return value.</remarks>
        public override IPersistentVector cons(object val)
        {
            //if (_tail.Length < 32)
            if ( _cnt - tailoff() < 32 )
            {
                object[] newTail = new object[_tail.Length + 1];
                Array.Copy(_tail, newTail, _tail.Length);
                newTail[_tail.Length] = val;
                return new PersistentVector(meta(), _cnt + 1, _shift, _root, newTail);
            }

            // full tail, push into tree
            Node newroot;
            Node tailnode = new Node(_root.Edit, _tail);
            int newshift = _shift;
            
            // overflow root?
            if ((_cnt >> 5) > (1 << _shift))
            {
                newroot = new Node(_root.Edit);
                newroot.Array[0] = _root;
                newroot.Array[1] = newPath(_root.Edit, _shift, tailnode);
                newshift += 5;
            }
            else
                newroot = pushTail(_shift, _root, tailnode);


            return new PersistentVector(meta(), _cnt + 1, newshift, newroot, new object[] { val });
        }

        private Node pushTail(int level, Node parent, Node tailnode)
        {
            // if parent is leaf, insert node,
            // else does it map to existing child?  -> nodeToInsert = pushNode one more level
            // else alloc new path
            // return nodeToInsert placed in copy of parent
            int subidx = ((_cnt - 1) >> level) & 0x01f;
            Node ret = new Node(parent.Edit, (object[])parent.Array.Clone());
            Node nodeToInsert;

            if (level == 5)
                nodeToInsert = tailnode;
            else
            {
                Node child = (Node)parent.Array[subidx];
                nodeToInsert = (child != null
                                 ? pushTail(level - 5, child, tailnode)
                                 : newPath(_root.Edit, level - 5, tailnode));
            }
            ret.Array[subidx] = nodeToInsert;
            return ret;
        }

        static Node newPath(AtomicReference<Thread> edit, int level, Node node)
        {
            if (level == 0)
                return node;

            Node ret = new Node(edit);
            ret.Array[0] = newPath(edit, level - 5, node);
            return ret;
        }
        
        #endregion

        #region IPersistentCollection members

        /// <summary>
        /// Gets the number of items in the collection.
        /// </summary>
        /// <returns>The number of items in the collection.</returns>
        public override int count()
        {
            return _cnt;
        }

        /// <summary>
        /// Gets an empty collection of the same type.
        /// </summary>
        /// <returns>An emtpy collection.</returns>
        public override IPersistentCollection empty()
        {
            return (IPersistentCollection)EMPTY.withMeta(meta());
        }
        
        #endregion

        #region IPersistentStack members

        /// <summary>
        /// Returns a new stack with the top element popped.
        /// </summary>
        /// <returns>The new stack.</returns>
        public override IPersistentStack pop()
        {
            if ( _cnt == 0 )
                throw new InvalidOperationException("Can't pop empty vector");
            if ( _cnt == 1)
                return (IPersistentStack)EMPTY.withMeta(meta());
            //if ( _tail.Length > 1 )
            if (_cnt - tailoff() > 1)
            {
                object[] newTail = new object[_tail.Length-1];
                Array.Copy(_tail,newTail,newTail.Length);
                return new PersistentVector(meta(),_cnt-1,_shift,_root,newTail);
            }
            object[] newtail = ArrayFor(_cnt - 2);

            Node newroot = popTail(_shift,_root);
            int newshift = _shift;
            if ( newroot == null )
                newroot = EMPTY_NODE;
            if ( _shift > 5 && newroot.Array[1] == null )
            {
                newroot = (Node)newroot.Array[0];
                newshift -= 5;
            }
            return new PersistentVector(meta(), _cnt - 1, newshift, newroot, newtail);
        }

        private Node popTail(int level, Node node)
        {
            int subidx = ((_cnt - 2) >> level) & 0x01f;
            if (level > 5)
            {
                Node newchild = popTail(level - 5, (Node)node.Array[subidx]);
                if (newchild == null && subidx == 0)
                    return null;
                else
                {
                    Node ret = new Node(_root.Edit, (object[])node.Array.Clone());
                    ret.Array[subidx] = newchild;
                    return ret;
                }
            }
            else if (subidx == 0)
                return null;
            else
            {
                Node ret = new Node(_root.Edit, (object[])node.Array.Clone());
                ret.Array[subidx] = null;
                return ret;
            }
        }


        #endregion

        #region IFn members



        #endregion

        #region Seqable members

        public override ISeq seq()
        {
            return chunkedSeq();
        }

        #endregion

        #region ChunkedSeq

        public IChunkedSeq chunkedSeq()
        {
            if (count() == 0)
                return null;
            return new ChunkedSeq(this, 0, 0);
        }

        sealed public class ChunkedSeq : ASeq, IChunkedSeq
        {
            #region Data

            readonly PersistentVector _vec;
            readonly object[] _node;
            readonly int _i;
            readonly int _offset;

            #endregion

            #region C-tors

            public ChunkedSeq(PersistentVector vec, int i, int offset)
            {
                _vec = vec;
                _i = i;
                _offset = offset;
                _node = vec.ArrayFor(i);
            }

            ChunkedSeq(IPersistentMap meta, PersistentVector vec, object[] node,  int i, int offset)
                : base(meta)
            {
                _vec = vec;
                _node = node;
                _i = i;
                _offset = offset;
            }

            public ChunkedSeq(PersistentVector vec, object[] node,  int i, int offset)
            {
                _vec = vec;
                _node = node;
                _i = i;
                _offset = offset;
            }

            #endregion

            #region IObj members


            public override IObj withMeta(IPersistentMap meta)
            {
                return (meta == _meta)
                    ? this
                    : new ChunkedSeq(meta, _vec, _node, _i, _offset);
            }

            #endregion

            #region IChunkedSeq Members

            public Indexed chunkedFirst()
            {
                return new ArrayChunk(_node, _offset);
            }

            public ISeq chunkedNext()
            {
                if (_i + _node.Length < _vec._cnt)
                    return new ChunkedSeq(_vec, _i + _node.Length, 0);
                return null;
            }

            public ISeq chunkedMore()
            {
                ISeq s = chunkedNext();
                if (s == null)
                    return PersistentList.EMPTY;
                return s;
            }

            #endregion

            #region IPersistentCollection Members


            //public new IPersistentCollection cons(object o)
            //{
            //    throw new NotImplementedException();
            //}

            #endregion

            public override object first()
            {
                return _node[_offset];
            }

            public override ISeq next()
            {
                if (_offset + 1 < _node.Length)
                    return new ChunkedSeq(_vec, _node, _i, _offset + 1);
                return chunkedNext();
            }

        }

        #endregion

        #region IEditableCollection Members

        public IMutableCollection mutable()
        {
            return new MutableVector(this);
        }

        #endregion

        #region Mutable class

        class MutableVector : IMutableVector, Counted
        {
            #region Data

            int _cnt;
	        int _shift;
	        Node _root;
            object[] _tail;

            #endregion

            #region Ctors

            MutableVector(int cnt, int shift, Node root, Object[] tail)
            {
                _cnt = cnt;
                _shift = shift;
                _root = root;
                _tail = tail;
            }

            public MutableVector(PersistentVector v)
                : this(v._cnt, v._shift, EditableRoot(v._root), EditableTail(v._tail))
            {
            }

            #endregion

            #region Counted Members

            public int count()
            {
                EnsureEditable();
                return _cnt;
            }

            #endregion

            #region Implementation

            void EnsureEditable()
            {
                Thread owner = _root.Edit.Get();
                if (owner == Thread.CurrentThread)
                    return;
                if (owner != null)
                    throw new InvalidOperationException("Mutable used by non-owner thread");
                throw new InvalidOperationException("Mutable used after immutable call");
            }


            Node EnsureEditable(Node node)
            {
                if (node.Edit == _root.Edit)
                    return node;
                return new Node(_root.Edit, (object[])node.Array.Clone());
            }

            static Node EditableRoot(Node node)
            {
                return new Node(new AtomicReference<Thread>(Thread.CurrentThread), (object[])node.Array.Clone());
            }

            static object[] EditableTail(object[] tl)
            {
                object[] ret = new object[32];
                Array.Copy(tl, ret, tl.Length);
                return ret;
            }

            Node PushTail(int level, Node parent, Node tailnode)
            {
                //if parent is leaf, insert node,
                // else does it map to an existing child? -> nodeToInsert = pushNode one more level
                // else alloc new path
                //return  nodeToInsert placed in copy of parent
                int subidx = ((_cnt - 1) >> level) & 0x01f;
                Node ret = new Node(parent.Edit, (object[])parent.Array.Clone());
                Node nodeToInsert;
                if (level == 5)
                {
                    nodeToInsert = tailnode;
                }
                else
                {
                    Node child = (Node)parent.Array[subidx];
                    nodeToInsert = (child != null)
                        ? PushTail(level - 5, child, tailnode)
                                                   : newPath(_root.Edit, level - 5, tailnode);
                }
                ret.Array[subidx] = nodeToInsert;
                return ret;
            }

            int Tailoff()
            {
                if (_cnt < 32)
                    return 0;
                return ((_cnt - 1) >> 5) << 5;
            }

            object[] ArrayFor(int i)
            {
                if (i >= 0 && i < _cnt)
                {
                    if (i >= Tailoff())
                        return _tail;
                    Node node = _root;
                    for (int level = _shift; level > 0; level -= 5)
                        node = (Node)node.Array[(i >> level) & 0x01f];
                    return node.Array;
                }
                throw new IndexOutOfRangeException();
            }

            #endregion

            #region IMutableVector Members

            public object nth(int i)
            {
                object[] node = ArrayFor(i);
                return node[i & 0x01f];
            }

            public IMutableVector assocN(int i, object val)
            {
                EnsureEditable();
                if (i >= 0 && i < _cnt)
                {
                    if (i >= Tailoff())
                    {
                        _tail[i & 0x01f] = val;
                        return this;
                    }

                    _root = doAssoc(_shift, _root, i, val);
                    return this;
                }
                if (i == _cnt)
                    return (IMutableVector)conj(val);
                throw new IndexOutOfRangeException();
            }

            Node doAssoc(int level, Node node, int i, Object val)
            {
                node = EnsureEditable(node);
                Node ret = new Node(node.Edit, (object[])node.Array.Clone());
                if (level == 0)
                {
                    ret.Array[i & 0x01f] = val;
                }
                else
                {
                    int subidx = (i >> level) & 0x01f;
                    ret.Array[subidx] = doAssoc(level - 5, (Node)node.Array[subidx], i, val);
                }
                return ret;
            }

            public IMutableVector pop()
            {
                EnsureEditable();
                if (_cnt == 0)
                    throw new InvalidOperationException("Can't pop empty vector");
                if (_cnt == 1)
                {
                    _cnt = 0;
                    return this;
                }
                int i = _cnt - 1;
                // pop in tail?
                if ((i & 0x01f) > 0)
                {
                    --_cnt;
                    return this;
                }
                object[] newtail = ArrayFor(_cnt - 2);

                Node newroot = PopTail(_shift, _root);
                int newshift = _shift;
                if (newroot == null)
                {
                    newroot = EMPTY_NODE;
                }
                if (_shift > 5 && newroot.Array[1] == null)
                {
                    newroot = (Node)newroot.Array[0];
                    newshift -= 5;
                }
                _root = newroot;
                _shift = newshift;
                --_cnt;
                _tail = newtail;
                return this;
            }


            private Node PopTail(int level, Node node)
            {
                node = EnsureEditable(node);
                int subidx = ((_cnt - 2) >> level) & 0x01f;
                if (level > 5)
                {
                    Node newchild = PopTail(level - 5, (Node)node.Array[subidx]);
                    if (newchild == null && subidx == 0)
                        return null;
                    else
                    {
                        Node ret = node;
                        ret.Array[subidx] = newchild;
                        return ret;
                    }
                }
                else if (subidx == 0)
                    return null;
                else
                {
                    Node ret = node;
                    ret.Array[subidx] = null;
                    return ret;
                }
            }

            #endregion

            #region IMutableAssociative Members

            public object valAt(object key)
            {
                if (Util.IsInteger(key.GetType()))
                {
                    int i = Util.ConvertToInt(key);
                    if (i >= 0 && i < count())
                        return nth(i);
                }
                return null;
            }

            public IMutableAssociative assoc(object key, object val)
            {
                if (Util.IsInteger(key.GetType()))
                {
                    int i = Util.ConvertToInt(key);
                    return assocN(i, val);
                }
                throw new ArgumentException("Key must be integer");
            }

            #endregion

            #region IMutableCollection Members

            public IMutableCollection conj(object val)
            {

                EnsureEditable();
                int i = _cnt;
                //room in tail?
                if (i - Tailoff() < 32)
                {
                    _tail[i & 0x01f] = val;
                    ++_cnt;
                    return this;
                }
                //full tail, push into tree
                Node newroot;
                Node tailnode = new Node(_root.Edit, _tail);
                _tail = new object[32];
                _tail[0] = val;
                int newshift = _shift;
                //overflow root?
                if ((_cnt >> 5) > (1 << _shift))
                {
                    newroot = new Node(_root.Edit);
                    newroot.Array[0] = _root;
                    newroot.Array[1] = newPath(_root.Edit, _shift, tailnode);
                    newshift += 5;
                }
                else
                    newroot = PushTail(_shift, _root, tailnode);
                _root = newroot;
                _shift = newshift;
                ++_cnt;
                return this;
            }

            public IPersistentCollection immutable()
            {
                EnsureEditable();
                _root.Edit.Set(null);
                object[] trimmedTail = new object[_cnt-Tailoff()];
                Array.Copy(_tail,trimmedTail,trimmedTail.Length);
                return new PersistentVector(_cnt, _shift, _root, trimmedTail);
            }

            #endregion
        }
 
        #endregion
    }
}
