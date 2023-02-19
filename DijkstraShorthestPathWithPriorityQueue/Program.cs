using DotNetty.Common.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShorthestPathWithPriorityQueue
{
    internal class Program
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
            var distances = DijsktraWithPriorityQueue(vertices, 1);
            Console.WriteLine(String.Join(" ", distances));
        }

        private static int[] DijsktraWithPriorityQueue(List<Node>[] vertices, int vertex)
        {
            var used = new HashSet<int>();
            used.Add(vertex);

            var distances = new int[vertices.Length];
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
            }
            distances[vertex] = 0;

            var queue = new PriorityQueue<Node>();
            queue.Enqueue(new Node(vertex, 0));

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();
                used.Add(element.Vertex);

                foreach (var node in vertices[element.Vertex])
                {
                    if (used.Contains(node.Vertex))
                    {
                        continue;
                    }

                    var bDistance = distances[node.Vertex];
                    var cDistance = node.Distance + element.Distance;

                    if (bDistance > cDistance)
                    {
                        distances[node.Vertex] = cDistance;
                        node.Distance = cDistance;
                    }

                    queue.Enqueue(node);
                }
            }

            return distances;
        }

        private static List<Node>[] ReadWeightedGraph()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            var vertices = new List<Node>[n + 1];

            for (int i = 0; i < m; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var from = edge[0];
                var to = edge[1];
                var distance = edge[2];

                AddEdge(vertices, from, to, distance);
                AddEdge(vertices, to, from, distance);
            }

            return vertices;
        }

        private static void AddEdge(List<Node>[] vertices, int from, int to, int distance)
        {
            if (vertices[from] == null)
            {
                vertices[from] = new List<Node>();
            }

            vertices[from].Add(new Node(to, distance));
        }

        private static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }
    }
}
