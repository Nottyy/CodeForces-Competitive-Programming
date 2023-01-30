using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTreesRecursive
{
    internal class AvlNode<T>
    {
        private int size;

        private int height;
        public T Value { get; private set; }

        public AvlNode<T> Left
        {
            get
            {
                return this.Children[0];
            }
            set
            {
                this.Children[0] = value;
            }
        }

        public AvlNode<T> Right
        {
            get
            {
                return this.Children[1];
            }
            set
            {
                this.Children[1] = value;
            }
        }

        public AvlNode<T>[] Children;

        public AvlNode(T value)
        {
            this.size = 1;
            this.height = 1;
            this.Value = value;
            this.Children = new AvlNode<T>[2];
        }

        public int GetHeight(AvlNode<T> node)
        {
            return node == null ? 0 : node.height;
        }

        public int GetSize(AvlNode<T> node)
        {
            return node == null ? 0 : node.size;
        }

        public int Balance(AvlNode<T> node)
        {
            return this.GetHeight(node.Left) - this.GetHeight(node.Right);
        }

        public void UpdateSizes()
        {
            this.size = this.GetSize(this.Left) + this.GetSize(this.Right) + 1;
            this.height = Math.Max(this.GetHeight(this.Left), this.GetHeight(this.Right)) + 1;
        }

        public static void Rotate(ref AvlNode<T> node, int left, int right)
        {
            var newRoot = node.Children[left];
            node.Children[left] = newRoot.Children[right];
            newRoot.Children[right] = node;

            node.UpdateSizes();
            newRoot.UpdateSizes();

            node = newRoot;
        }

        public static void RotateLeft(ref AvlNode<T> node)
        {
            Rotate(ref node, 1, 0);
        }

        public static void RotateRight(ref AvlNode<T> node)
        {
            Rotate(ref node, 0, 1);
        }
    }
}
