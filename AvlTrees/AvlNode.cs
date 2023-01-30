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
        private int size;
        private int height;

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

        public AvlNode(T value)
        {
            this.Neighbours = new AvlNode<T>[3];
            this.Value = value;
            this.size = 1;
            this.height = 1;
        }

        public static int GetSize(AvlNode<T> node)
        {
            return node == null ? 0 : node.size;
        }

        public static int GetHeight(AvlNode<T> node)
        {
            return node == null ? 0 : node.height;
        }

        private void UpdateSizes(int val)
        {
            this.size = GetSize(this.Left) + GetSize(this.Right) + val;
            this.height = Math.Max(GetHeight(this.Left), GetHeight(this.Right)) + val;
        }

        public AvlNode<T> Update(int val)
        {
            var root = this;
            var curBalance = this.GetBalance();

            if (curBalance > 1)
            {
                var bl = this.Left.GetBalance();
                if (bl < 0)
                {
                    root = this.Left.RotateLeft();
                    //this.Right.UpdateSizes(1);
                }

                root = this.RotateLeft();
            }
            else if (curBalance < -1)
            {
                var bl = this.Right.GetBalance();
                if (bl > 0)
                {
                    root = this.Right.RotateRight();
                    //this.Left.UpdateSizes(1);
                }
                root = this.RotateRight();
            }
            else
            {
                root.UpdateSizes(1);
            }

            if (root.Parent != null)
            {
                root = this.Parent.Update(val);
            }

            return root;
        }

        public int GetBalance()
        {
            return GetHeight(this.Left) - GetHeight(this.Right);
        }

        private AvlNode<T> RotateRight()
        {
            return this.Rotate(1, 0);
        }

        private AvlNode<T> RotateLeft()
        {
            return this.Rotate(0, 1);
        }

        public AvlNode<T> Rotate(int left, int right)
        {
            var newRoot = this.Neighbours[left];
            bool nullNewRoot = false;

            if (newRoot == null)
            {
                newRoot = this.Neighbours[right];
                nullNewRoot = true;
            }
            
            if (newRoot.Neighbours[right] != null)
            {
                newRoot.Neighbours[right].Parent = this;
            }

            if (this.Parent != null)
            {
                if (this.Parent.Left == this)
                {
                    this.Parent.Left = newRoot;
                }
                else
                {
                    this.Parent.Right = newRoot;
                }
            }

            newRoot.Parent = this.Parent;
            this.Parent = newRoot;

            var st = newRoot.Neighbours[right];
            if (nullNewRoot)
            {
                newRoot.Neighbours[left] = this;
                this.Neighbours[right] = null;
            }
            else
            {
                newRoot.Neighbours[right] = this;
                this.Neighbours[left] = st;
            }

            this.UpdateSizes(1);
            newRoot.UpdateSizes(1);

            return newRoot;
        }
    }
}
