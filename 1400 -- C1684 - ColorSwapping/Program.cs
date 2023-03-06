using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1400____C1684___ColorSwapping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                var line1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var n = line1[0];
                var m = line1[1];
                var array = ReadRowsCols(n, m);

                int badRow = GetBadRow(array);

                if (badRow == -1)
                {
                    Console.WriteLine("1 1");
                }
                else
                {
                    var unsortedBadRow = array[badRow];
                    var sortedBadRow = array[badRow].OrderBy(x => x).ToArray();
                    var badRowLength = array[badRow].Length;

                    var counter = 0;
                    var colsToSwap = new int[2];

                    for (int j = 0; j < badRowLength; j++)
                    {
                        if (unsortedBadRow[j] != sortedBadRow[j])
                        {
                            if (counter == 2)
                            {
                                counter++;
                                Console.WriteLine("-1");
                                break;
                            }
                            colsToSwap[counter] = j;
                            counter++;
                        }
                    }

                    if (counter == 2)
                    {
                        var res = GetBadRow(array, colsToSwap);

                        if (res == -1)
                        {
                            Console.WriteLine((colsToSwap[0] + 1) + " " + (colsToSwap[1] + 1));
                        }
                        else
                        {
                            Console.WriteLine("-1");
                        }
                    }
                }
            }
        }

        private static int GetBadRow(int[][] array, int[] swapArr = null)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length - 1; j++)
                {
                    int current;
                    int next;

                    if (swapArr != null)
                    {
                        if (j == swapArr[0])
                        {
                            current = array[i][swapArr[1]];
                        }
                        else if (j == swapArr[1])
                        {
                            current = array[i][swapArr[0]];
                        }
                        else
                        {
                            current = array[i][j];
                        }

                        if (j + 1 == swapArr[0])
                        {
                            next = array[i][swapArr[1]];
                        }
                        else if (j + 1 == swapArr[1])
                        {
                            next = array[i][swapArr[0]];
                        }
                        else
                        {
                            next = array[i][j + 1];
                        }
                    }
                    else
                    {
                        current = array[i][j];
                        next = array[i][j + 1];
                    }

                    if (current > next)
                    {
                        return i;
                    }

                    current = next;
                }
            }

            return -1;
        }

        private static int[][] ReadRowsCols(int n, int m)
        {
            var array = new int[n][];

            for (int j = 0; j < n; j++)
            {
                array[j] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            return array;
        }
    }
}
