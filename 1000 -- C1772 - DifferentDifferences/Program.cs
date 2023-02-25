using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000____C1772___DifferentDifferences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                // 5 9
                // 1 2 3 4 5 - (1) ||| 1 2 3 4 6 - (2)
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var k = line[0];
                var n = line[1];

                var arr = new int[k];

                for (int j = 0; j < k; j++)
                {
                    arr[j] = j + 1;
                }

                var diff = n - k; // 4
                var last = k; // 5
                var res = 1;

                for (int p = 1; p <= diff; p++)
                {
                    if (k - res <= 1)
                    {
                        break;
                    }

                    last += p;

                    if (last > n)
                    {
                        break;
                    }

                    res++;
                }

                for (int j = k - res, p = 1; j < k; j++, p++)
                {
                    arr[j] = arr[j - 1] + p;
                }

                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
