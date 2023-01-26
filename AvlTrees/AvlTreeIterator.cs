using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTrees
{
    public class AvlTreeIterator<T> where T : IComparable<T>
    {
        private AvlNode<T> node;

        public T Value => node.Value;

        public AvlTreeIterator(AvlNode<T> node)
        {
            this.node = node;
        }

        public void Move(int left, int right)
        {
            if (node.Neighbours[right] != null)
            {
                node = node.Neighbours[right];

                while (node.Neighbours[left] != null)
                {
                    node = node.Neighbours[left];
                }
            }
            else
            {
                while (node.Parent != null && node.Parent.Neighbours[right] == node)
                {
                    node = node.Parent;
                }

                if (node.Parent == null)
                {
                    node = null;
                    return;
                }

                node = node.Parent;
            }
        }

        public void MoveRight()
        {
            this.Move(0, 1);
        }

        public void MoveLeft()
        {
            this.Move(1, 0);
        }
    }
}
