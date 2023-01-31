﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTreesRecursive
{
    internal class AvlNode<T> where T : IComparable<T>
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

        public static int GetHeight(AvlNode<T> node)
        {
            return node == null ? 0 : node.height;
        }

        public static int GetSize(AvlNode<T> node)
        {
            return node == null ? 0 : node.size;
        }

        public static int Balance(AvlNode<T> node)
        {
            return GetHeight(node.Left) - GetHeight(node.Right);
        }

        public void UpdateSizes()
        {
            this.size = GetSize(this.Left) + GetSize(this.Right) + 1;
            this.height = Math.Max(GetHeight(this.Left), GetHeight(this.Right)) + 1;
        }

        public void Update()
        {

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

        public static bool Add(ref AvlNode<T> node, T value)
        {
            if (node == null)
            {
                node = new AvlNode<T>(value);
                return true;
            }

            var cmp = value.CompareTo(node.Value);

            if (cmp < 0)
            {
                var child = node.Left;
                var result = Add(ref child, value);
                node.Left = child;

                if (result)
                {
                    node.UpdateSizes();
                    node = Update(node);
                }

                return result;
            }
            else if (cmp > 0)
            {
                var child = node.Right;
                var result = Add(ref child, value);
                node.Right = child;

                if (result)
                {
                    node.UpdateSizes();
                    node = Update(node);
                }

                return result;
            }
            else
            {
                return false;
            }
        }

        public static int IndexOf(AvlNode<T> node, T value)
        {
            if (node == null)
            {
                return -1;
            }
            var cmp = value.CompareTo(node.Value);

            if (cmp < 0)
            {
                return IndexOf(node.Left, value);
            }
            if (cmp > 0)
            {
                var size = GetSize(node.Left) + 1;
                return IndexOf(node.Right, value) + size;
            }

            return GetSize(node.Left);
        }

        public static T GetValueAtIndex(AvlNode<T> node, int index)
        {
            if (node == null)
            {
                throw new ArgumentException("No such value at index!");
            }

            var cmp = index.CompareTo(GetSize(node.Left));

            if (cmp < 0)
            {
                return GetValueAtIndex(node.Left, index);
            }
            if (cmp > 0)
            {
                return GetValueAtIndex(node.Right, index - GetSize(node.Left) - 1);
            }

            return node.Value;
        }

        private static AvlNode<T> Update(AvlNode<T> node)
        {
            var balance = Balance(node);

            if (balance > 1)
            {
                if (Balance(node.Left) < 0)
                {
                    var sub = node.Left;
                    RotateLeft(ref sub);
                    node.Left = sub;
                }
                RotateRight(ref node);
            }
            else if (balance < -1)
            {
                if (Balance(node.Right) > 0)
                {
                    var sub = node.Right;
                    RotateRight(ref sub);
                    node.Right = sub;
                }
                RotateLeft(ref node);
            }

            return node;
        }
    }
}
