using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsForGraphs
{
    internal class Program
    {
        private static string input = @"7
8
1 4 5
1 3 2
2 1 5
2 3 6
3 4 8
4 2 4
5 2 6
6 5 4";
        static void Main(string[] args)
        {
            FakeInput();
            LinkedList<int>[] vertices = GetVertices();
            PrintPathWithDFS(vertices);
        }

        static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }

        private static void PrintPathWithDFS(LinkedList<int>[] vertices)
        {
            var vertex = 1;
            var used = new bool[vertices.Length];
            DFS(vertex, vertices, used);
        }

        private static void DFS(int vertex, LinkedList<int>[] vertices, bool[] used)
        {
            if (used[vertex] == true)
            {
                return;
            }

            Console.Write(vertex + " ");
            used[vertex] = true;

            foreach (var node in vertices[vertex])
            {
                DFS(node, vertices, used);
            }
        }

        private static LinkedList<int>[] GetVertices()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            var vertices = new LinkedList<int>[n];

            for (int i = 0; i < m; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var from = edge[0] - 1;
                var to = edge[1] - 1;
                //var value = edge[2];

                if (vertices[from] == null)
                {
                    vertices[from] = new LinkedList<int>();
                }
                vertices[from].AddLast(to);

                if (vertices[to] == null)
                {
                    vertices[to] = new LinkedList<int>();
                }
                vertices[to].AddLast(from);
            }

            return vertices;
        }
    }
}
