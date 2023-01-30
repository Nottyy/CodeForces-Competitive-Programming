using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTreesRecursive
{
    internal class AvlTree<T> : IEnumerable<T> where T: IComparable<T>
    {
        public AvlNode<T> root;

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
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
