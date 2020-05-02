using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace _1300____B707___Bakery
{
    public class Node : IComparable<Node>
    {
        public Node(int vertex, long weight)
        {
            Vertex = vertex;
            Weight = weight;
        }

        public int Vertex { get; set; }

        public long Weight { get; set; }

        public int CompareTo(Node other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }

    public class Bakery
    {
        static void Main()
        {
            var command = Console.ReadLine().Split(' ');
            var allCities = int.Parse(command[0]);
            var roads = int.Parse(command[1]);
            var numberOfFlourCottages = int.Parse(command[2]);

            List<Node>[] graph = new List<Node>[allCities + 1];
            for (int i = 0; i < roads; i++)
            {
                var edges = Console.ReadLine().Split(' ');
                
                var x = int.Parse(edges[0]);
                var y = int.Parse(edges[1]);
                var weight = long.Parse(edges[2]);

                AddEdges(graph, x, y, weight);
                AddEdges(graph, y, x, weight);
            }


            if (numberOfFlourCottages == 0)
            {
                Console.WriteLine(-1);
                return;
            }

            var flourCottagesLine = Console.ReadLine().Split(' ');
            bool[] checkedCottages = new bool[allCities + 1];
            int[] allFlourCottages = new int[flourCottagesLine.Length];

            for (int i = 0; i < flourCottagesLine.Length; i++)
            {
                var currentCottage = int.Parse(flourCottagesLine[i]);
                allFlourCottages[i] = currentCottage;
                checkedCottages[currentCottage] = true;
            }


            long maxValue = long.MaxValue;
            for (int i = 0; i < allFlourCottages.Length; i++)
            {
                var currentFlourCottageNumber = allFlourCottages[i];
                var neighbours = graph[currentFlourCottageNumber];

                if (neighbours == null)
                {
                    continue;
                }

                foreach (var next in neighbours)
                {
                    if (checkedCottages[next.Vertex])
                    {
                        continue;
                    }

                    if (next.Weight < maxValue)
                    {
                        maxValue = next.Weight;
                    }
                }
            }


            Console.WriteLine(maxValue == long.MaxValue ? -1 : maxValue);
        }

        private static void AddEdges(List<Node>[] vertices, int from, int to, long weight)
        {
            if (vertices[from] == null)
            {
                vertices[from] = new List<Node>();
            }
            vertices[from].Add(new Node(to, weight));
        }
    }
}
