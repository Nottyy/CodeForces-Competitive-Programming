using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGenerateMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = ReadSudokuMatrix();
            PrintMatrix(matrix);

            HashSet<int>[] squares = ReadSquares(matrix);
            HashSet<int>[] rows = ReadRows(matrix);
            HashSet<int>[] cols = ReadCols(matrix);

            if (matrix[0, 0] == 0)
            {
                var nextRow = 0;
                var nextCol = 0;
                for (int i = 1; i <= 9; i++)
                {
                    var squareIndex = GetSquareIndex(nextRow, nextCol);

                    if (!squares[squareIndex].Contains(i)
                        && !rows[nextRow].Contains(i)
                        && !cols[nextCol].Contains(i))
                    {
                        squares[squareIndex].Add(i);
                        rows[nextRow].Add(i);
                        cols[nextCol].Add(i);

                        matrix[nextRow, nextCol] = i;

                        DFS(matrix, squares, rows, cols, nextRow, nextCol);

                        //Console.WriteLine();
                        //PrintMatrix(matrix);

                        matrix[nextRow, nextCol] = 0;
                        squares[squareIndex].Remove(i);
                        rows[nextRow].Remove(i);
                        cols[nextCol].Remove(i);
                    }
                }
            }
        }

        private static void DFS(int[,] matrix, HashSet<int>[] squares, HashSet<int>[] rows,
            HashSet<int>[] cols, int row, int col)
        {
            if (CheckIfFinished(squares))
            {
                Console.WriteLine();
                PrintMatrix(matrix);
                return;
            }

            if (col + 1 >= matrix.GetLength(1) && row + 1 >= matrix.GetLength(0))
            {
                return;
            }

            int nextCol = GetNextCol(col);
            var nextRow = GetNextRow(row, col);

            if (matrix[nextRow, nextCol] == 0)
            {
                for (int i = 1; i <= 9; i++)
                {

                    var squareIndex = GetSquareIndex(nextRow, nextCol);
                    if (!squares[squareIndex].Contains(i)
                        && !rows[nextRow].Contains(i)
                        && !cols[nextCol].Contains(i))
                    {
                        squares[squareIndex].Add(i);
                        rows[nextRow].Add(i);
                        cols[nextCol].Add(i);

                        matrix[nextRow, nextCol] = i;

                        DFS(matrix, squares, rows, cols, nextRow, nextCol);

                        //Console.WriteLine();
                        //PrintMatrix(matrix);

                        matrix[nextRow, nextCol] = 0;
                        squares[squareIndex].Remove(i);
                        rows[nextRow].Remove(i);
                        cols[nextCol].Remove(i);
                    }
                }
            }
            else
            {
                DFS(matrix, squares, rows, cols, nextRow, nextCol);
            }
        }

        private static int GetNextRow(int row, int col)
        {
            return col + 1 >= 9 ? row + 1 : row;
        }

        private static int GetNextCol(int col)
        {
            var nextCol = col + 1;
            if (nextCol >= 9)
            {
                nextCol = 0;
            }

            return nextCol;
        }

        private static int GetSquareIndex(int row, int col)
        {
            // 1, 2, 3
            if (row <= 2 && col <= 2)
            {
                return 0;
            }

            if (row <= 2 && (col > 2 && col <= 5))
            {
                return 1;
            }

            if (row <= 2 && (col > 5 && col <= 8))
            {
                return 2;
            }

            // 3, 4, 5
            if (row > 2 && row <= 5 && col <= 2)
            {
                return 3;
            }

            if (row > 2 && row <= 5 && (col > 2 && col <= 5))
            {
                return 4;
            }

            if (row > 2 && row <= 5 && (col > 5 && col <= 8))
            {
                return 5;
            }

            // 6, 7, 8
            if (row > 5 && row <= 8 && col <= 2)
            {
                return 6;
            }

            if (row > 5 && row <= 8 && (col > 2 && col <= 5))
            {
                return 7;
            }

            if (row > 5 && row <= 8 && (col > 5 && col <= 8))
            {
                return 8;
            }

            return default;
        }

        private static bool CheckIfFinished(HashSet<int>[] squares)
        {
            for (int i = 0; i < squares.Length; i++)
            {
                if (squares[i].Count < 9)
                {
                    return false;
                }
            }

            return true;
        }

        private static HashSet<int>[] ReadCols(int[,] matrix)
        {
            var cols = new HashSet<int>[9];
            var counter = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (cols[counter] == null)
                    {
                        cols[counter] = new HashSet<int>();
                    }

                    var curNum = matrix[j, i];

                    if (curNum != 0)
                    {
                        cols[counter].Add(curNum);
                    }
                }

                counter++;
            }

            return cols;
        }

        private static HashSet<int>[] ReadRows(int[,] matrix)
        {
            var rows = new HashSet<int>[9];
            var counter = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (rows[counter] == null)
                    {
                        rows[counter] = new HashSet<int>();
                    }

                    var curNum = matrix[i, j];

                    if (curNum != 0)
                    {
                        rows[counter].Add(curNum);
                    }
                }

                counter++;
            }

            return rows;
        }

        private static HashSet<int>[] ReadSquares(int[,] matrix)
        {
            var squares = new HashSet<int>[9];
            var counter = 0;

            for (int i = 0; i < matrix.GetLength(0); i += 3)
            {
                for (int j = 0; j < matrix.GetLength(1); j += 3)
                {
                    for (int p = 0; p < 3; p++)
                    {
                        for (int t = 0; t < 3; t++)
                        {
                            if (squares[counter] == null)
                            {
                                squares[counter] = new HashSet<int>();
                            }
                            var curNum = matrix[i + p, j + t];

                            if (curNum != 0)
                            {
                                squares[counter].Add(curNum);
                            }
                        }
                    }

                    counter++;
                }
            }

            return squares;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] == 0 ? "- " : matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[,] ReadSudokuMatrix()
        {
            var matrix = new int[9, 9];

            matrix[1, 1] = 5;
            matrix[2, 2] = 7;

            matrix[0, 3] = 3;
            matrix[0, 5] = 2;
            matrix[1, 3] = 7;
            matrix[1, 4] = 9;
            matrix[1, 5] = 8;

            matrix[1, 7] = 3;
            matrix[2, 6] = 8;

            matrix[3, 2] = 8;
            matrix[4, 1] = 7;
            matrix[5, 2] = 3;

            matrix[3, 3] = 6;
            matrix[3, 5] = 7;
            matrix[5, 3] = 5;
            matrix[5, 5] = 4;

            matrix[3, 6] = 3;
            matrix[4, 7] = 6;
            matrix[5, 6] = 1;

            matrix[6, 2] = 5;
            matrix[7, 1] = 2;

            matrix[7, 3] = 4;
            matrix[7, 4] = 1;
            matrix[7, 5] = 9;
            matrix[8, 3] = 8;
            matrix[8, 5] = 6;

            matrix[6, 6] = 6;
            matrix[7, 7] = 5;

            return matrix;
        }
    }
}
