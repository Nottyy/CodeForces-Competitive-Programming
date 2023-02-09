using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AvlTreesExerciseImplementation
{
    public class AvlNode<T> where T : IComparable<T>
    {
        private int height;
        public int size;
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

        public bool IsLeaf => this.Right == null && this.Left == null;

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
                    BalanceIfLeftIsHeavy(ref node);
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
                    BalanceIfRightIsHeavy(ref node);
                }

                return result;
            }
            else
            {
                return false;
            }
        }
        private static void BalanceIfLeftIsHeavy(ref AvlNode<T> node)
        {
            node.UpdateSizes();

            if (node.Balance > 1)
            {
                if (node.Left.Balance < 0)
                {
                    var child = node.Left;
                    AvlNode<T>.RotateLeft(ref child);
                    node.Left = child;
                }
                AvlNode<T>.RotateRight(ref node);
            }
        }
        private static void BalanceIfRightIsHeavy(ref AvlNode<T> node)
        {
            node.UpdateSizes();

            if (node.Balance < -1)
            {
                if (node.Right.Balance > 0)
                {
                    var child = node.Right;
                    AvlNode<T>.RotateRight(ref child);
                    node.Right = child;
                }
                AvlNode<T>.RotateLeft(ref node);
            }
        }

        public static bool Remove(ref AvlNode<T> node, T value)
        {
            if (node == null)
            {
                return false;
            }

            var cmp = value.CompareTo(node.Value);

            if (cmp < 0)
            {
                var child = node.Left;
                var result = AvlNode<T>.Remove(ref child, value);

                if (result)
                {
                    node.Left = child;
                    node.UpdateSizes();
                }

                return result;
            }
            else if (cmp > 0)
            {
                var child = node.Right;
                var result = AvlNode<T>.Remove(ref child, value);

                if (result)
                {
                    node.Right = child;
                    node.UpdateSizes();
                }

                return result;
            }
            else
            {
                if (node.Left.IsLeaf )
                {
                    node = node.Left;
                    return true;
                }

                if (node.Left == null)
                {
                    if (node.Right.Left == null)
                    {
                        node.Right.Left = node.Left;
                        node = node.Right;
                    }
                    else
                    {
                        // traverse left
                        var child = node.Right;
                        AvlNode<T>.Traverse(ref child, 0);
                        var leftmost = child.Left;
                        var tmp = leftmost.Right;

                        child.Left = tmp;
                        child.UpdateSizes();

                        leftmost.Left = node.Left;
                        leftmost.Right = node.Right;
                        leftmost.UpdateSizes();

                        node = leftmost;
                    }
                }
                else
                {
                    if (node.Left.Right == null)
                    {
                        node.Left.Right = node.Right;
                        node = node.Left;
                    }
                    else
                    {
                        // traverse right
                        var child = node.Left;
                        AvlNode<T>.Traverse(ref child, 0);
                        var rightmost = child.Right;
                        var tmp = rightmost.Left;

                        child.Right = tmp;
                        child.UpdateSizes();

                        rightmost.Right = node.Right;
                        rightmost.Left = node.Left;
                        rightmost.UpdateSizes();

                        node = rightmost;
                    }
                }

                return true;
            }
        }

        private static AvlNode<T> Find(ref AvlNode<T> node, T value)
        {
            if (node == null)
            {
                return null;
            }
            var cmp = value.CompareTo(node.Value);

            if (cmp < 0)
            {
                var child = node.Left;
                var toReturn = AvlNode<T>.Find(ref child, value);
                node.Left = child;

                return toReturn;
            }
            else if (cmp > 0)
            {
                var child = node.Right;
                var toReturn = AvlNode<T>.Find(ref child, value);
                node.Right = child;

                return toReturn;
            }
            else
            {
                return node;
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

        private static void Traverse(ref AvlNode<T> node, int direction)
        {
            while (node.Children[direction] != null)
            {
                if (node.Children[direction].Children[direction] == null)
                {
                    return;
                }
                node = node.Children[direction];
            }
        }
    }
}
