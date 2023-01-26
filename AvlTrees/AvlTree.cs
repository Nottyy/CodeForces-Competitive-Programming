using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTrees
{
    public class AvlTree<T> where T : IComparable<T>
    {
        private AvlNode<T> node;

        public AvlTree(AvlNode<T> node)
        {
            this.node = node;
        }
    }
}
