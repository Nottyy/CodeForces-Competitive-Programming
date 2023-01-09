using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8QueensProblem
{
    internal class Program
    {
        static int size = 8;
        static int solutions = 0;
        static bool[,] matrix = new bool[8,8];
        static void Main(string[] args)
        {
            PlaceQueen(0);
            Console.WriteLine(solutions);
        }

        static void PlaceQueen(int col)
        {
            if (col == size)
            {
                solutions++;
                return;
            }

            for (int row = 0; row < size; row++)
            {
                if (!CheckCollisions(row, col))
                {
                    matrix[row, col] = true;
                    PlaceQueen(col + 1);
                    matrix[row, col] = false;
                }
            }
        }

        static bool CheckCollisions(int row, int col)
        {
            for (int curRow = 0; curRow < size; curRow++)
            {
                if (matrix[curRow, col])
                {
                    return true;
                }
            }

            for (int curCol = 0; curCol < size; curCol++)
            {
                if (matrix[row, curCol])
                {
                    return true;
                }
            }

            // diagonal up right
            for (int i = col, j=row; i < 0; i++,j--)
            {
                if (matrix[i,j])
                {
                    return true;
                }
            }

            // diagonal up left
            for (int i = col, j = row; i < 0; i--, j--)
            {
                if (matrix[i, j])
                {
                    return true;
                }
            }

            // diagonal down left
            for (int i = col, j = row; i < 0; i--, j++)
            {
                if (matrix[i, j])
                {
                    return true;
                }
            }

            // diagonal down right
            for (int i = col, j = row; i < 0; i++, j++)
            {
                if (matrix[i, j])
                {
                    return true;
                }
            }

            return false;
        }
    }
}
