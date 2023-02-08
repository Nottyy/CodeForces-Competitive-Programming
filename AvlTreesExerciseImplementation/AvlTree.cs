using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AvlTreesExerciseImplementation
{
    public class AvlTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public AvlNode<T> root;

        public AvlTree()
        {
            this.root = null;
        }

        public bool Add(T value)
        {
            return AvlNode<T>.Add(ref this.root, value);
        }

        public bool Remove(T value)
        {
            return AvlNode<T>.Remove(ref this.root, value);
        }
        public IEnumerator<T> GetEnumerator()
        {
            var stack = new Stack<Tuple<AvlNode<T>, bool>>();
            var tuple = new Tuple<AvlNode<T>, bool> (this.root, false);
            stack.Push(tuple);

            while (stack.Count > 0)
            {
                var poppedVal = stack.Pop();
                var node = poppedVal.Item1;
                var isTraversed = poppedVal.Item2;

                if (isTraversed == false)
                {
                    stack.Push(new Tuple<AvlNode<T>, bool>(node, true));
                    if (node.Left != null)
                    {
                        stack.Push(new Tuple<AvlNode<T>, bool>(node.Left, false));
                    }
                }
                else
                {
                    yield return node.Value;

                    //Console.WriteLine(node.Balance);
                    if (node.Right != null)
                    {
                        stack.Push(new Tuple<AvlNode<T>, bool>(node.Right, false));
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
