using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphConnectivity
{
    public class Program
    {
        private static string input = @"9
7
1 2
1 4
2 5
4 5
7 9
3 6
6 8
";
        private static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }

        static void Main(string[] args)
        {
            FakeInput();

            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            var graph = ReadGraph(n, m);
            //bool isConnected = IsConnected(graph);
            //Console.WriteLine(isConnected);
            int connectedUnionOfNodes = Connectivities(graph);
            Console.WriteLine(connectedUnionOfNodes);
        }

        private static int Connectivities(HashSet<int>[] graph)
        {
            var connectivities = 0;
            var used = new bool[graph.Length];
            used[0] = true;

            for (int i = 1; i < graph.Length; i++)
            {
                if (used[i])
                {
                    continue;
                }

                Dfs(i, graph, used);
                connectivities++;
            }

            return connectivities;
        }

        private static bool IsConnected(HashSet<int>[] graph)
        {
            var n = graph.Length;
            var vertex = 1;
            var used = new bool[n];
            used[0] = true;

            Dfs(vertex, graph, used);

            return used.Any(x => x == false) ? false : true;
        }

        private static void Dfs(int vertex, HashSet<int>[] graph, bool[] used)
        {
            used[vertex] = true;
            foreach (var node in graph[vertex])
            {
                if (used[node])
                {
                    continue;
                }
                Dfs(node, graph, used);
            }
        }

        private static HashSet<int>[] ReadGraph(int n, int m)
        {
            var graph = new HashSet<int>[n + 1];

            for (int i = 1; i <= m; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var from = edge[0];
                var to = edge[1];

                if (graph[from] == null)
                {
                    graph[from] = new HashSet<int>();
                }

                graph[from].Add(to);

                if (graph[to] == null)
                {
                    graph[to] = new HashSet<int>();
                }

                graph[to].Add(from);
            }

            return graph;
        }
    }
}
