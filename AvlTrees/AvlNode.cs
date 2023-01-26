using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AvlTrees
{
    public class AvlNode<T> where T : IComparable<T>
    {
        private int Size;
        private int Height;

        public T Value { get; private set; }

        public AvlNode<T>[] Neighbours { get; private set; }

        public AvlNode<T> Left
        {
            get
            {
                return this.Neighbours[0];
            }
            set
            {
                this.Neighbours[0] = value;
            }
        }
        public AvlNode<T> Right
        {
            get
            {
                return this.Neighbours[1];
            }
            set
            {
                this.Neighbours[1] = value;
            }
        }
        public AvlNode<T> Parent
        {
            get
            {
                return this.Neighbours[2];
            }
            set
            {
                this.Neighbours[2] = value;
            }
        }

        public AvlNode()
        {
            this.Neighbours = new AvlNode<T>[3];
        }

        public static int GetSize(AvlNode<T> node)
        {
            return node == null ? 0 : node.Size;
        }

        public static int GetHeight(AvlNode<T> node)
        {
            return node == null ? 0 : node.Height;
        }

        public int GetBalance()
        {
            return GetHeight(this.Left) - GetHeight(this.Right);
        }
    }
}
