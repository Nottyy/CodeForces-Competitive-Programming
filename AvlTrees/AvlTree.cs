using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTrees
{
    public class AvlTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        public AvlNode<T> root;

        public int Count => AvlNode<T>.GetSize(this.root);
        public int Height => AvlNode<T>.GetHeight(this.root);

        public AvlTree()
        {
            this.root = null;
        }

        public Tuple<AvlTreeIterator<T>, bool> Add(T value)
        {
            var it = this.LowerBound(value);

            if (it.Node == null)
            {
                if (this.root != null)
                {
                    var node = this.root;
                    while (node.Right != null)
                    {
                        node = node.Right;
                    }

                    node.Right = new AvlNode<T>(value);
                    node.Right.Parent = node;

                    this.root = node.Update(1);

                    var newNodeIt = new AvlTreeIterator<T>(node.Right);
                    return new Tuple<AvlTreeIterator<T>, bool>(newNodeIt, true);
                }
                else
                {
                    this.root = new AvlNode<T>(value);
                    var newIt = new AvlTreeIterator<T>(this.root);

                    return new Tuple<AvlTreeIterator<T>, bool>(newIt, true);
                }
            }

            if (it.Node.Value.CompareTo(value) == 0)
            {
                return new Tuple<AvlTreeIterator<T>, bool>(it, false);
            }

            var newNode = new AvlNode<T>(value);

            if (it.Node.Left == null)
            {
                it.Node.Left = newNode;
                newNode.Parent = it.Node;
            }
            else
            {
                it.MoveLeft();
                it.Node.Right = newNode;
                newNode.Parent = it.Node;
            }

            this.root = newNode.Parent.Update(1);
            var newIT = new AvlTreeIterator<T>(newNode);

            return new Tuple<AvlTreeIterator<T>, bool>(newIT, true);
        }

        public void Remove(T value)
        {

        }

        public bool Contains(T value)
        {
            var it = this.LowerBound(value);

            return it.Node.Value.CompareTo(value) == 0;
        }

        public AvlTreeIterator<T> Find(T value)
        {
            var it = this.LowerBound(value);

            if (it.Node.Value.CompareTo(value) == 0)
            {
                return it;
            }

            return null;
        }

        public AvlTreeIterator<T> LowerBound(T value)
        {
            var node = this.root;

            if (node == null)
            {
                return this.End;
            }

            while (true)
            {
                var cmp = value.CompareTo(node.Value);

                if (cmp < 0)
                {
                    if (node.Left == null)
                    {
                        return new AvlTreeIterator<T>(node);
                    }
                    node = node.Left;
                }
                else if (cmp > 0)
                {
                    if (node.Right == null)
                    {
                        var it = new AvlTreeIterator<T>(node);
                        it.MoveRight();
                        return it;
                    }
                    node = node.Right;
                }
                else
                {
                    return new AvlTreeIterator<T>(node);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var it = this.Begin;

            while (it.Node != null)
            {
                yield return it.Value;
                it.MoveRight();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public AvlTreeIterator<T> Begin
        {
            get
            {
                if (this.root == null)
                {
                    return new AvlTreeIterator<T>(null);
                }

                var node = this.root;

                while (node.Left != null)
                {
                    node = node.Left;
                }

                return new AvlTreeIterator<T>(node);
            }
        }

        public AvlTreeIterator<T> End
        {
            get
            {
                return new AvlTreeIterator<T>(null);
            }
        }
    }
}
