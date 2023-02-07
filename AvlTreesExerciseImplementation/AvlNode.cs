using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AvlTreesExerciseImplementation
{
    public class AvlNode<T> where T: IComparable<T>
    {
        private int height;
        private int size;
        public T Value { get; private set; }

        public AvlNode<T>[] Children;

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

        public AvlNode(T value)
        {
            this.Value = value;
            this.Children = new AvlNode<T>[2];
            this.height = 1;
            this.size = 1;
        }

        public static int GetHeight(AvlNode<T> node)
        {
            return node == null ? 0 : node.height;
        }

        public static int GetSize(AvlNode<T> node)
        {
            return node == null ? 0 : node.size;
        }

        public int Balance => GetHeight(this.Left) - GetHeight(this.Right);

        public void UpdateSizes()
        {
            this.height = Math.Max(GetHeight(this.Left), GetHeight(Right)) + 1;
            this.size = GetSize(this.Left) + GetSize(this.Right) + 1;
        }

        public static bool Add(ref AvlNode<T> node, T value)
        {
            if (node == null)
            {
                node = new AvlNode<T>(value);
                return false;
            }

            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new AvlNode<T>(value);
                    node.UpdateSizes();

                    return true;
                }

                var child = node.Left;  
                var result = Add(ref child, value);
                if (result)
                {
                    node.Left = child;
                    node.UpdateSizes();

                    if (node.Balance > 1)
                    {
                        AvlNode<T>.RotateRight(ref node);
                    }
                }

                return result;
            }
            else if (value.CompareTo(node.Value) > 0)
            {
                if (node.Right == null)
                {
                    node.Right = new AvlNode<T>(value);
                    node.UpdateSizes();

                    return true;
                }

                var child = node.Right;
                var result = Add(ref child, value);

                if (result)
                {
                    node.Right = child;
                    node.UpdateSizes();

                    //if (node.Balance < -1)
                    //{
                    //    AvlNode<T>.RotateRight(ref node);
                    //}
                }

                return result;
            }
            else
            {
                return false;
            }
        }

        private static void RotateRight(ref AvlNode<T> node)
        {
            //var newRoot = TraverseRight(node.Left);
            //var tmp = newRoot.Left;
            //node.Left.Right = tmp;
            //newRoot.Right = node;
            //newRoot.Left = node.Left;

            //node = newRoot;

            var newRoot = node.Left;
            node.Left = newRoot.Right;
            newRoot.Right = node;
            node.UpdateSizes();
            newRoot.UpdateSizes();

            node = newRoot;
        }

        private static AvlNode<T> TraverseRight(AvlNode<T> node)
        {
            while (node.Right != null)
            {
                node = node.Right;
            }

            return node;
        }
    }
}
