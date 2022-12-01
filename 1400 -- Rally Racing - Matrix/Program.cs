using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace _1400____Rally_Racing___Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string carName = Console.ReadLine();
            string[,] matrix = new string[size, size];

            for (int i = 0; i < size; i++)
            {
                var row = Console.ReadLine().Split(' ').ToArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = row[j];
                }
            }

            string command = Console.ReadLine();
            int km = 0;
            int cRow = 0;
            int cCol = 0;

            while(command != "End")
            {

                if (command == "down")
                {
                    cRow++;
                }
                else if (command == "left")
                {
                    cCol--;
                }
                else if (command == "right")
                {
                    cCol++;
                }
                else if (command == "up")
                {
                    cRow--;
                }
                else
                {
                    km += 10;
                    finishRace(matrix, km, cRow, cCol, false, carName);

                    return;
                }

                if (matrix[cRow, cCol] == ".")
                {
                    km += 10;
                }
                else if (matrix[cRow,cCol] == "T")
                {
                    km += 30;
                    matrix[cRow, cCol] = ".";

                    var fRowCol = getF(matrix);
                    cRow = fRowCol[0];
                    cCol = fRowCol[1];
                    matrix[cRow, cCol] = ".";
                }
                else
                {
                    km += 10;
                    finishRace(matrix, km, cRow, cCol, true, carName);
                    return;
                }

                command = Console.ReadLine();
            }

            finishRace(matrix, km, cRow, cCol, false, carName);

        }

        private static void finishRace(string[,] matrix, int km, int row, int col, bool finishedRace, string carName)
        {
            matrix[row, col] = "C";

            if (finishedRace)
            {
                Console.WriteLine(String.Format("Racing car {0} finished the stage!", carName));
            }
            else
            {
                Console.WriteLine(String.Format("Racing car {0} DNF.", carName));
            }

            Console.WriteLine(String.Format("Distance covered {0} km.", km));

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static int[] getF(string[,] matrix)
        {
            int[] arr = new int[2];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == "T")
                    {
                        arr[0] = i;
                        arr[1] = j;
                        return arr;
                    }
                }
            }

            return arr;
        }
    }
}
