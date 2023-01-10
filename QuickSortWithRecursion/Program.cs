using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortWithRecursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 4, 5, 2, 1, 9, 0 };

            Console.WriteLine(String.Join(" ", QuickSortRecursion(arr)));
        }

        static int[] QuickSortRecursion(int[] arr)
        {
            if (arr.Length <= 1)
            {
                return arr;
            }

            int pivot = arr[0];
            var right = new List<int>();
            var left = new List<int>();

            for (int i = 1; i < arr.Length; i++)
            {
                if (pivot > arr[i])
                {
                    left.Add(arr[i]);
                }
                else
                {
                    right.Add(arr[i]);
                }
            }

            var leftSorted = QuickSortRecursion(left.ToArray());
            var rightSorted = QuickSortRecursion(right.ToArray());

            var newArr = new List<int>();
            newArr.AddRange(leftSorted);
            newArr.Add(pivot);
            newArr.AddRange(rightSorted);

            return newArr.ToArray();
        }
    }
}
