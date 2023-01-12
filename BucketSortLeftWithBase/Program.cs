using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BucketSortLeftWithBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 154, 1, 15, 18, 50, 3};
            var basePower = GetBasePower(3, 10);
            BucketSort(arr, basePower, 3, 10);
            Console.WriteLine(String.Join(" ", arr));

        }

        static void BucketSort(int[] arr, int basePower, int digit, int base1)
        {
            if (digit <= 0)
            {
                return;
            }

            var buckets = new List<int>[base1];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<int>();
            }


            for (int i = 0; i < arr.Length; i++)
            {
                var currentDigit = (arr[i] / basePower) % base1;
                buckets[currentDigit].Add(arr[i]);
            }

            foreach (var b in buckets)
            {
                if (b.Count != 0)
                {
                    BucketSort(b.ToArray(), basePower / base1, digit - 1, base1);
                }
            }

            buckets.Aggregate((x, y) =>
            {
                x.AddRange(y);
                return x;
            }).CopyTo(arr);
        }

        private static int GetBasePower(int digits, int base1)
        {
            int basePower = 1;

            for (int i = 1; i < digits; i++)
            {
                basePower *= base1;
            }

            return basePower;
        }
    }
}
