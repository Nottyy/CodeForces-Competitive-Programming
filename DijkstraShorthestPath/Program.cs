using DotNetty.Common.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShorthestPath
{
    public class Program
    {
        private static string input = @"5
8
1 2 2
1 3 3
1 4 11
2 3 3
2 5 15
3 5 6
3 4 2
4 5 3
";
        static void Main(string[] args)
        {
            FakeInput();
            List<Node>[] vertices = ReadWeightedGraph();
            var distances = Dijsktra(vertices, 1);

            var s = 4;
        }

        private static int[] Dijsktra(List<Node>[] vertices, int start)
        {
            var used = new HashSet<int>();
            var distances = new int[vertices.Length];

            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[start] = 0;
            used.Add(start);

            var queue = new PriorityQueue<Node>();
            queue.Enqueue(new Node(start, 0));

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                used.Add(current.Vertex);

                foreach (var node in vertices[current.Vertex])
                {
                    if (used.Contains(node.Vertex))
                    {
                        continue;
                    }
                    var currentBest = distances[node.Vertex];
                    var to = node.Distance + current.Distance;

                    if (to < currentBest)
                    {
                        distances[node.Vertex] = to;
                        node.Distance = to;
                    }

                    queue.Enqueue(node);
                }
               
            }

            return distances;
        }

        private static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }

        private static List<Node>[] ReadWeightedGraph()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            var vertices = new List<Node>[n + 1];

            for (int i = 0; i < m; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                AddEdge(vertices, edge[0], edge[1], edge[2]);
                AddEdge(vertices, edge[1], edge[0], edge[2]);
            }

            return vertices;
        }

        private static void AddEdge(List<Node>[] vertices, int from, int to, int distance)
        {
            if (vertices[from] == null)
            {
                vertices[from] = new List<Node>();
            }

            var node = new Node(to, distance);
            vertices[from].Add(node);
        }
    }
}
