using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketSortLeft
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var st = new int[] { 1, 1, 1, 1, 20, 20, 50, 50, 0, 0, 11, 50, 10, 22, 4, 33, 55 };
            Console.WriteLine(String.Join(" ", BucketSort(st, 1)));
        }

        static int[] BucketSort(int[] arr, int digit)
        {
            if (arr.Length == 1)
            {
                return arr;
            }
            var buckets = new List<int>[10];

            for (int i = 0; i < arr.Length; i++)
            {
                if (digit == 1)
                {
                    var bucket = arr[i] / 10;
                    if (buckets[bucket] == null)
                    {
                        buckets[bucket] = new List<int>();
                    }
                    buckets[bucket].Add(arr[i]);
                }
                else
                {
                    var bucket = arr[i] % 10;
                    if (buckets[bucket] == null)
                    {
                        buckets[bucket] = new List<int>();
                    }
                    buckets[bucket].Add(arr[i]);
                }
            }

            var sortedArr = new List<int>();

            foreach (var b in buckets)
            {
                if (b != null && b.Count > 1)
                {
                    if (digit < 2)
                    {
                        var newArr = BucketSort(b.ToArray(), digit + 1);
                        foreach (var s in newArr)
                        {
                            sortedArr.Add(s);
                        }
                    }
                    else
                    {
                        foreach (var s in b)
                        {
                            sortedArr.Add(s);
                        }
                    }
                }
                else if(b != null && b.Count == 1)
                {
                    foreach (var s in b)
                    {
                        sortedArr.Add(s);
                    }
                }
            }

            return sortedArr.ToArray();
        }
    }
}
