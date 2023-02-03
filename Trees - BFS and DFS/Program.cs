using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees___BFS_and_DFS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var node0 = new Node<int>(0);
            var node1 = new Node<int>(1);
            var node2 = new Node<int>(2);
            var node3 = new Node<int>(3);
            var node4 = new Node<int>(4);
            var node5 = new Node<int>(5);

            node3.Left = node1;
            node3.Right = node4;
            node1.Left = node0;
            node1.Right = node2;
            node4.Right = node5;

            StackDFS(node3);
            QueueBFS(node3);
        }

        private static void StackDFS(Node<int> node3)
        {
            var stack = new Stack<Node<int>>();
            stack.Push(node3);

            var sb = new StringBuilder();

            while (stack.Count > 0)
            {
                var element = stack.Pop();
                sb.Append(element.Value + " ");

                if (element.Left != null)
                {
                    stack.Push(element.Left);
                }
                if (element.Right != null)
                {
                    stack.Push(element.Right);
                }
            }

            Console.WriteLine(sb);
        }

        private static void QueueBFS(Node<int> node3)
        {
            var queue = new Queue<Node<int>>();
            queue.Enqueue(node3);

            var sb = new StringBuilder();

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();
                sb.Append(element.Value + " ");

                if (element.Left != null)
                {
                    queue.Enqueue(element.Left);
                }
                if (element.Right != null)
                {
                    queue.Enqueue(element.Right);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
