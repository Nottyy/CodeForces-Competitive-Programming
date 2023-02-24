using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxProduct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var p = firstLine[1];
            var k = firstLine[2];

            var pNums = Console.ReadLine().Split(' ').Select(int.Parse).OrderByDescending(x => x).ToArray();
            var kNums = Console.ReadLine().Split(' ').Select(int.Parse).OrderByDescending(x => x).ToArray();
            Console.WriteLine(MaxProduct(k, pNums, kNums));
        }

        private static long MaxProduct(int k, int[] pNums, int[] kNums)
        {
            var strs = new string[k];

            for (int i = k - 1, j = 0; i >= 0; i--, j++)
            {
                strs[i] += pNums[j];
            }

            var pIndex = k;
            var kIndex = 0;

            while (pIndex < pNums.Length)
            {
                var pNum = pNums[pIndex];
                if (strs[kIndex].Length >= kNums[kIndex])
                {
                    kIndex++;
                    if (kIndex > k - 1)
                    {
                        kIndex = 0;
                    }
                }
                else
                {
                    strs[kIndex] += pNum;

                    pIndex++;
                    kIndex++;
                    if (kIndex > k - 1)
                    {
                        kIndex = 0;
                    }
                }
            }

            long res = strs.Select(long.Parse).Aggregate((x, y) => x * y);

            return res;
        }
    }
}
