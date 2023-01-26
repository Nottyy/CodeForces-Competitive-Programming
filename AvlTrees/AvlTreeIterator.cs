using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTrees
{
    public class AvlTreeIterator<T> where T : IComparable<T>
    {
        internal AvlNode<T> Node { get; private set; }

        public T Value => Node.Value;

        public AvlTreeIterator(AvlNode<T> node)
        {
            this.Node = node;
        }

        public void Move(int left, int right)
        {
            if (Node.Neighbours[right] != null)
            {
                Node = Node.Neighbours[right];

                while (Node.Neighbours[left] != null)
                {
                    Node = Node.Neighbours[left];
                }
            }
            else
            {
                while (Node.Parent != null && Node.Parent.Neighbours[right] == Node)
                {
                    Node = Node.Parent;
                }

                if (Node.Parent == null)
                {
                    Node = null;
                    return;
                }

                Node = Node.Parent;
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
