using DotNetty.Common.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MinimumSpanningTree
{
    public class Program
    {
        private static string input = @"5
8
3 4 2
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
            List<Node>[] vertices = ReadGraph();
            //int minSpanTreeSum = SumMinSpanTreeSum(vertices, 4);
            //Console.WriteLine(minSpanTreeSum);
            var mst = GetEdgesMinSpanTreeSum(vertices, 5);
            for (int i = 0; i < mst.Count - 1; i++)
            {
                Console.WriteLine($"{mst[i][0] + " " + mst[i][1] + " " + mst[i + 1][2]}");
            }
        }
        private static List<int[]> GetEdgesMinSpanTreeSum(List<Node>[] vertices, int vertex)
        {
            var mst = new List<int[]>();
            var sum = 0;
            var used = new HashSet<int>();
            var q = new PriorityQueue<Node>();
            q.Enqueue(new Node(vertex, vertex, 0));

            while (q.Count > 0 && used.Count != vertices.Length - 1)
            {
                var element = q.Dequeue();

                foreach (var node in vertices[element.X])
                {
                    if (used.Contains(node.X))
                    {
                        continue;
                    }

                    q.Enqueue(new Node(node.X, node.Y, node.Distance));
                }

                sum += element.Distance;

                while (used.Contains(q.Peek().X))
                {
                    q.Dequeue();
                }

                var p = q.Peek();

                var first = used.Contains(p.X) ? p.Y : p.X;
                mst.Add(new int[] {first == p.X ? p.Y: p.X, first, sum });

                used.Add(element.X);
            }

            return mst;
        }
        private static int SumMinSpanTreeSum(List<Node>[] vertices, int vertex)
        {
            var sum = 0;
            var used = new HashSet<int>();
            var q = new PriorityQueue<Node>();
            q.Enqueue(new Node(vertex, 0));

            while (q.Count > 0 && used.Count != vertices.Length - 1)
            {
                var element = q.Dequeue();

                if (used.Contains(element.X))
                {
                    continue;
                }

                sum += element.Distance;

                foreach (var node in vertices[element.X])
                {
                    q.Enqueue(node);
                }

                used.Add(element.X);
            }

            return sum;
        }

        private static List<Node>[] ReadGraph()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            var v = new List<Node>[n + 1];

            for (int i = 0; i < m; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                AddEdge(v, edge[0], edge[1], edge[2]);
                AddEdge(v, edge[1], edge[0], edge[2]);
            }

            return v;
        }

        private static void AddEdge(List<Node>[] vertices, int from, int to, int d)
        {
            if (vertices[from] == null)
            {
                vertices[from] = new List<Node>();
            }

            vertices[from].Add(new Node(to, from, d));
        }
    }
}
