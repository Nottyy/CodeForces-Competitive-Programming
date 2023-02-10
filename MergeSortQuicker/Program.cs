using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortQuicker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 5, 55, 44, 10, 15, 16 };

            var sortedArr = MergeSort(arr, 0, arr.Length);

            Console.WriteLine(String.Join(" ", sortedArr));
        }

        public static int[] MergeSort(int[] array, int start, int end)
        {
            // Phase 1 - Split
            if (end - start < 2)
            {
                return new int[] { array[start] };
            }

            int middle = end - ((end - start) / 2);
            int[] left = MergeSort(array, start, middle);
            int[] right = MergeSort(array, middle, end);

            // Phase 2 - Merge

            int[] newArr = new int[left.Length + right.Length];
            int indexL = 0;
            int indexR = 0;
            int i = 0;

            for (; indexR < right.Length && indexL < left.Length; i++)
            {
                if (left[indexL] > right[indexR])
                {
                    newArr[i] = right[indexR];
                    indexR++;
                }
                else
                {
                    newArr[i] = left[indexL];
                    indexL++;
                }
            }

            if (indexL < left.Length)
            {
                while (indexL < left.Length)
                {
                    newArr[i] = left[indexL];
                    i++;
                    indexL++;
                }
            }

            if (indexR < right.Length)
            {
                while (indexR < right.Length)
                {
                    newArr[i] = right[indexR];
                    i++;
                    indexR++;
                }
            }

            return newArr;
        }
    }
}
