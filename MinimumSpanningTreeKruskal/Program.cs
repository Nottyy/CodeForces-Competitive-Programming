using DotNetty.Common.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSpanningTreeKruskal
{
    internal class Program
    {
        private static string input = @"8
3 4 22
1 2 2
1 3 3
2 3 3
2 5 15
5 3 6
4 5 3
1 4 11";

        private static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }
        static void Main(string[] args)
        {
            FakeInput();

            PriorityQueue<Node> edges = ReadGraphWithListOfEdges();

            var elements = new int[edges.Count];
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = -1;
            }

            var nodes = MinimumSpanningTreeKruskal(edges, elements);

            foreach (var node in nodes)
            {
                Console.WriteLine(node);
            }
        }

        private static List<Node> MinimumSpanningTreeKruskal(PriorityQueue<Node> edges, int[] elements)
        {
            var result = new List<Node>();
            var n = edges.Count;

            for(var i = 0; i < n; i++)
            {
                var element = edges.Dequeue();
                var from = element.X;
                var to = element.Y;

                var parentFrom = FindParentIterative(from, elements);
                var parentTo = FindParentIterative(to, elements);

                if (parentFrom == parentTo)
                {
                    continue;
                }

                elements[parentFrom] = parentTo; // merging unions here
                result.Add(element);
            }

            return result;
        }

        private static int FindParentIterative(int x, int[] arr)
        {
            while (arr[x] >= 0)
            {
                x = arr[x];
            }

            return x;
        }

        private static PriorityQueue<Node> ReadGraphWithListOfEdges()
        {
            int m = int.Parse(Console.ReadLine());

            var vertices = new PriorityQueue<Node>();

            for (int i = 0; i < m; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                vertices.Enqueue(new Node(edge[0], edge[1], edge[2]));
                //vertices.Enqueue(new Node(edge[1], edge[0], edge[2]));
            }

            return vertices;
        }
    }
}
