using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTrees
{
    public class AvlTree<T> where T : IComparable<T>
    {
        private AvlNode<T> root;

        public int Count => AvlNode<T>.GetSize(this.root);
        public int Height => AvlNode<T>.GetHeight(this.root);

        public AvlTree(AvlNode<T> node)
        {
            this.root = node;
        }

        public void Add(T value)
        {

        }

        public void Remove(T value)
        {

        }

        public void Contains(T value)
        {

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
    }
}
