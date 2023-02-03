using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees___BFS_and_DFS
{
    public class Node<T>
    {
        public T Value { get; private set; }

        public Node<T>[] Children;

        public Node<T> Left
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
        public Node<T> Right
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

        public Node(T value)
        {
            this.Value = value;
            this.Children = new Node<T>[2];
        }
    }
}
