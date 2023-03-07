using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1300____C1647___MadokaAndChildishPranks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var n = line[0];
                var m = line[1];

                var matrix = ReadMatrix(n, m);

                if (matrix[0][0] == 1)
                {
                    Console.WriteLine(-1);
                }
                else
                {
                    var operations = new List<List<int>>();

                    for (int row = n - 1; row >= 0; row--)
                    {
                        for (int col = m - 1; col >= 0; col--)
                        {
                            var current = matrix[row][col];

                            if (current == 1)
                            {
                                if (col == 0)
                                {
                                    operations.Add(new List<int> { row - 1 + 1, col + 1, row + 1, col + 1 });
                                }
                                else
                                {
                                    operations.Add(new List<int> { row + 1, col - 1 + 1, row + 1, col + 1 });
                                }
                            }
                        }
                    }

                    Console.WriteLine(operations.Count);
                    for (int j = 0; j < operations.Count; j++)
                    {
                        Console.WriteLine(String.Join(" ", operations[j]));
                    }
                }
            }
        }

        private static int[][] ReadMatrix(int n, int m)
        {
            int[][] matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Select(c => c - '0').ToArray();

                for (int j = 0; j < m; j++)
                {
                    if (matrix[i] == null)
                    {
                        matrix[i] = new int[m];
                    }
                    matrix[i][j] = line[j];
                }
            }

            return matrix;
        }
    }
}
