using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphWithMatrix
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter N:");
            var n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of edges:");

            var edges = int.Parse(Console.ReadLine());

            var matrix = new bool[n + 1, n + 1];

            for (int i = 0; i < edges; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var from = edge[0];
                var to = edge[1];

                matrix[from, to] = true;
                //matrix[to, from] = true;
            }

            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    Console.Write((matrix[i, j] == true ? 1 : 0) + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
