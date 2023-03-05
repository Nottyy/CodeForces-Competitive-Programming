using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1200____C1704___Virus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = int.Parse(Console.ReadLine());


            for (int i = 0; i < t; i++)
            {
                var line1 = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                long n = line1[0];
                long m = line1[1];
                long[] infectedHouses = Console.ReadLine().Split(' ').Select(long.Parse).OrderBy(x => x).ToArray();


                if (n == m)
                {
                    Console.WriteLine(n);
                    continue;
                }

                if (m == 1)
                {
                    if (n == 2)
                    {
                        Console.WriteLine(1);
                        continue;
                    }
                    else if (n > 2)
                    {
                        Console.WriteLine(2);
                        continue;
                    }
                }

                var differences = infectedHouses.Zip(infectedHouses.Skip(1), (x, y) => y - x).ToList();
                differences.Add(n + infectedHouses[0] - infectedHouses[infectedHouses.Length - 1]);
                var ordered = differences.OrderByDescending(x => x).ToArray();


                if (ordered[0] == 1)
                {
                    Console.WriteLine(n);
                }

                else if (ordered[0] == 2)
                {
                    Console.WriteLine(n - 1);
                }
                else
                {
                    long result = GetNumberOfUninfectedHouses(ordered);
                    Console.WriteLine(n - result);
                }
            }
        }

        private static long GetNumberOfUninfectedHouses(long[] ordered)
        {
            long result = 0;
            var counter = 0;

            for (int i = 0; i < ordered.Length; i++)
            {
                var difference = ordered[i] - 1 - (counter * 2);

                if (difference > 0)
                {
                    if (difference == 1)
                    {
                        return result += 1;
                    }
                    result += ordered[i] - 1 - 1 - (counter * 2);

                    counter += 2;
                }
                else
                {
                    return result;
                }
            }

            return result;
        }
    }
}
