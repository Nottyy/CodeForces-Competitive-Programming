using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortWithSwapping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 8, 5, 2, 7, 10, 0, 1, 3, 2, 22 };
            arr = new int[] { 1, 1, 0, 101, 50, 23, 8, 5, 2, 7, 10, 0, 1, 3, 2, 22 };

            // { 8 5 2 0 7 9 1 3 2 10 22 }
            // { 2 5 2 0 7 9 1 3 8 10 22 }
            // { 2 5 2 0 7 9 1 3 8 10 22}
            // { 2 0 1 2 5 7 9 3 8 10 22 }
            QuickSortSwap(arr, 0, arr.Length - 1);
            Console.WriteLine(String.Join(" ", arr));
        }

        static void QuickSortSwap(int[] arr, int left, int right)
        {
            if (right - left < 2)
            {
                return;
            }
            var pivot = arr[left];

            var leftpointer = left + 1;
            var rightpointer = right;

            while (leftpointer < rightpointer)
            {
                while (arr[leftpointer] <= pivot && leftpointer < rightpointer)
                {
                    leftpointer++;
                }

                while (arr[rightpointer] >= pivot && leftpointer < rightpointer)
                {
                    rightpointer--;
                }

                var tmp = arr[leftpointer];
                arr[leftpointer] = arr[rightpointer];
                arr[rightpointer] = tmp;
            }

            arr[left] = arr[leftpointer - 1];
            arr[leftpointer - 1] = pivot;

            QuickSortSwap(arr, left, leftpointer - 1);
            QuickSortSwap(arr, leftpointer, right);


        }
    }
}
