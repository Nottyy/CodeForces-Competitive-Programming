using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1500____N1765___NumberReduction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                var n = Console.ReadLine();
                var k = int.Parse(Console.ReadLine());

                if (n.Length - k == 1)
                {
                    var sorted = GetSortedNumbersWithIndexes(n);

                    Console.WriteLine(sorted.First(x => x.Item1 > 0).Item1);
                    continue;
                }

                if (k == 0)
                {
                    Console.WriteLine(long.Parse(n));
                    continue;
                }

                var diff = n.Length - 1 - k;
                var leftString = n.Remove(n.Length - diff).ToString();
                int firstOccIndex = GetIndexOfSmallestNum(leftString);

                var newStr = n.Substring(firstOccIndex);

                long finalResult;

                if (firstOccIndex >= k)
                {
                    finalResult = long.Parse( newStr);
                    Console.WriteLine(finalResult);
                }
                else
                {
                    var toRemove = k - firstOccIndex;
                    var counterR = 0;

                    for (int j = 0; j < newStr.Length; j++)
                    {
                        var cur = int.Parse(newStr[j].ToString());
                        int next = -1;
                        if (j < newStr.Length - 1)
                        {
                            next = int.Parse(newStr[j + 1].ToString());
                        }
                        else
                        {
                            if (counterR < toRemove)
                            {
                                break;
                            }
                            else
                            {
                                finalResult *= 10;
                                finalResult += cur;
                            }
                            break;
                        }

                        if (counterR < toRemove && toRemove - counterR <= newStr.Length - j)
                        {
                            if (cur == next)
                            {
                                continue;
                            }
                            else if(cur < next)
                            {
                                finalResult *= 10;
                                finalResult += cur;
                            }
                            else
                            {
                                counterR++;
                            }
                        }
                        else
                        {
                            if (counterR < toRemove)
                            {
                                continue;
                            }
                            else
                            {
                                finalResult *= 10;
                                finalResult += cur;
                            }
                        }
                    }
                    
                }

                Console.WriteLine();
            }
        }

        private static int GetIndexOfSmallestNum(string leftString)
        {
            var sorted = GetSortedNumbersWithIndexes(leftString);

            var firstOccIndex = sorted.First(x => x.Item1 > 0).Item2;
            return firstOccIndex;
        }

        private static Tuple<int, int>[] GetSortedNumbersWithIndexes(string leftString)
        {
            var tuples = new Tuple<int, int>[leftString.Length];

            for (int j = 0; j < leftString.Length; j++)
            {
                tuples[j] = new Tuple<int, int>(int.Parse(leftString[j].ToString()), j);
            }

            var sorted = tuples.OrderBy(x => x.Item1).ToArray();
            return sorted;
        }
    }
}
