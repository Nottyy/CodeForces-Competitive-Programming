using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlgorithmsForGraphs
{
    public class Program
    {
        private static string input = @"7
8
6 3 4
1 4 5
1 3 2
2 1 5
3 4 8
4 5 4
5 6 6
2 3 6";
        static void Main(string[] args)
        {
            FakeInput();
            LinkedList<int>[] vertices = GetVertices();
            //PrintPathWithDFS(vertices);
            PrintPathWithBFS(vertices);
        }

        private static void PrintPathWithBFS(LinkedList<int>[] vertices)
        {
            var vertex = 2;
            var used = new bool[vertices.Length];
            var distances = new int[vertices.Length];
            distances[vertex] = 0;

            BFS(vertex, vertices, used, distances);

            for (int i = 0; i < distances.Length; i++)
            {
                Console.WriteLine($"Vertex {i} has distance: {distances[i]}");
            }
        }

        private static void BFS(int vertex, LinkedList<int>[] vertices, bool[] used, int[] distances)
        {
            var queue = new Queue<int>();
            queue.Enqueue(vertex);
            used[vertex] = true;

            while (queue.Count > 0)
            {
                var element = queue.Dequeue();
                used[element] = true;

                foreach (var x in vertices[element])
                {
                    if (used[x] == true)
                    {
                        continue;
                    }
                    queue.Enqueue(x);
                    distances[x] = distances[element] + 1;
                }
            }
        }

        static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }

        private static void PrintPathWithDFS(LinkedList<int>[] vertices)
        {
            var vertex = 2;
            var used = new bool[vertices.Length + 1];
            var path = new int[vertices.Length + 1];
            path[0] = -1;

            DFS(vertex, vertices, used, path);
            Console.WriteLine();
            for (int i = 1; i < path.Length; i++)
            {
                if (path[i] != 0)
                {
                    Console.WriteLine($"From {path[i]} - to {i}");
                }
            }
        }

        private static void DFS(int vertex, LinkedList<int>[] vertices, bool[] used, int[] path)
        {
            Console.Write(vertex + " ");
            used[vertex] = true;

            foreach (var node in vertices[vertex])
            {
                if (used[node] == true)
                {
                    continue;
                }

                path[node] = vertex;

                DFS(node, vertices, used, path);
            }
        }

        private static LinkedList<int>[] GetVertices()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            var vertices = new LinkedList<int>[n + 1];

            for (int i = 1; i <= m; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var from = edge[0];
                var to = edge[1];
                //var value = edge[2];

                if (vertices[from] == null)
                {
                    vertices[from] = new LinkedList<int>();
                }
                vertices[from].AddLast(to);

                //if (vertices[to] == null)
                //{
                //    vertices[to] = new LinkedList<int>();
                //}
                //vertices[to].AddLast(from);
            }

            return vertices;
        }
    }
}
