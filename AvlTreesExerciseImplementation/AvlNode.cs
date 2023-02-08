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
                        if (node.Left.Balance < 0)
                        {
                            child = node.Left;
                            AvlNode<T>.RotateLeft(ref child);
                            node.Left = child;
                        }
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

                    if (node.Balance < -1)
                    {
                        if (node.Right.Balance > 0)
                        {
                            child = node.Right;
                            AvlNode<T>.RotateRight(ref child);
                            node.Right = child;
                        }
                        AvlNode<T>.RotateLeft(ref node);
                    }
                }

                return result;
            }
            else
            {
                return false;
            }
        }

        private static void Rotate(ref AvlNode<T> node, int left, int right)
        {
            var newRoot = node.Children[left];
            node.Children[left] = newRoot.Children[right];
            newRoot.Children[right] = node;
            node.UpdateSizes();
            newRoot.UpdateSizes();

            node = newRoot;
        }

        private static void RotateRight(ref AvlNode<T> node)
        {
            Rotate(ref node, 0, 1);
        }

        private static void RotateLeft(ref AvlNode<T> node)
        {
            Rotate(ref node, 1, 0);
        }

        //private static AvlNode<T> Traverse(AvlNode<T> node, int direction)
        //{
        //    while (node.Children[direction] != null)
        //    {
        //        node = node.Children[direction];
        //    }

        //    return node;
        //}
    }
}
