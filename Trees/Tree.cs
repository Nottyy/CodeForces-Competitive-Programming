using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class Tree<T>
    {
        public T Value { get; private set; }

        public Tree<T> Left { get; set; }
        public Tree<T> Right { get; set; }

        public Tree(T value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }

        public Tree(T value, Tree<T> left, Tree<T> right) : this(value)
        {
            this.Left = left;
            this.Right = right;
        }

        public bool IsLeaf()
        {
            return this.Left == null && this.Right == null ? true : false;
        }
    }
}
