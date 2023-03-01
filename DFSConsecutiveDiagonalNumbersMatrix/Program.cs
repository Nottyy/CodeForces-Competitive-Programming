using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFSConsecutiveDiagonalNumbersMatrix
{
    

    class Program
    {
        static void Main()
        {
            int n = 3;
            int[,] matrix = new int[n, n];
            //matrix[0, 0] = 2;
            //matrix[0, 1] = 6;
            //matrix[0, 2] = 5;

            //matrix[1, 0] = 1;
            //matrix[1, 1] = 7;
            //matrix[1, 2] = 9;

            //matrix[2, 0] = 3;
            //matrix[2, 1] = 3;
            //matrix[2, 2] = 9;

            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rnd.Next(10);
                }
            }

            PrintMatrix(matrix);

            var visited = new bool[n];

            for (int i = 0; i < n; i++)
            {
                DFS(matrix, visited, matrix[i, 0], i, 0);
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void DFS(int[,] matrix, bool[] visited, int path, int row, int col)
        {
            var pathLength = path.ToString().Length;

            if (pathLength >= matrix.GetLength(0))
            {
                Console.WriteLine(path);
                return;
            }

            if (visited[row])
            {
                return;
            }

            var curDigit = path % 10;
            visited[row] = true;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (visited[i])
                {
                    continue;
                }

                if (col + 1 >= matrix.GetLength(1))
                {
                    return;
                }
                var nextDigit = matrix[i, col + 1];

                if (nextDigit >= curDigit)
                {
                    path = path * 10 + nextDigit;

                    DFS(matrix, visited, path, i, col + 1);

                    path /= 10;
                }
            }

            visited[row] = false;
        }
    }
}
