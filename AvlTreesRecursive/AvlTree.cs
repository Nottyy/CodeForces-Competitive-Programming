using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace AvlTreesRecursive
{
    internal class AvlTree<T> : IEnumerable<T> where T: IComparable<T>
    {
        private AvlNode<T> root;

        public int Count => AvlNode<T>.GetSize(this.root);
        public int Height => AvlNode<T>.GetHeight(this.root);

        public AvlTree()
        {
            this.root = null;
        }

        public bool Add(T value)
        {
            return AvlNode<T>.Add(ref this.root, value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var stack = new Stack<Tuple<AvlNode<T>, bool>>();
            stack.Push(new Tuple<AvlNode<T>, bool>(this.root, false));

            while (stack.Count > 0)
            {
                var tuple = stack.Pop();
                var node = tuple.Item1;
                var isLeftTraversed = tuple.Item2;

                if (node == null)
                {
                    continue;
                }

                if (isLeftTraversed == false)
                {
                    stack.Push(new Tuple<AvlNode<T>, bool>(node, true));
                    stack.Push(new Tuple<AvlNode<T>, bool>(node.Left, false));
                }
                else
                {
                    yield return node.Value;
                    stack.Push(new Tuple<AvlNode<T>, bool>(node.Right, false));
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
