using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWithAdjacencyNeighbours
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter N:");
            var n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of edges:");
            var edges = int.Parse(Console.ReadLine());

            var adjacencyList = new LinkedList<int>[n + 1];

            for (int i = 0; i < edges; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var from = edge[0];
                var to = edge[1];

                if (adjacencyList[from] == null)
                {
                    adjacencyList[from] = new LinkedList<int>();
                }

                if (adjacencyList[to] == null)
                {
                    adjacencyList[to] = new LinkedList<int>();
                }

                adjacencyList[from].AddLast(to);
                //adjacencyList[to].AddLast(from);
            }

            for (int i = 1; i < adjacencyList.Length; i++)
            {
                Console.WriteLine(i + " -> " + String.Join(" ", adjacencyList[i]));
            }
        }
    }
}
