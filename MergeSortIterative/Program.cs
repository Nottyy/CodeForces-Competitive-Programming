using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortIterative
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 5, 0, 3, 9, 7, 1, 2, 4, 1, 2, 3, 55, 13, 14, 0};
            Console.WriteLine(String.Join(" ", MergeSortIterative(arr)));

        }

        private static int[] MergeSortIterative(int[] arr)
        {
            for (int half = 1; half <= arr.Length; half *= 2)
            {
                for (int left = 0; left < arr.Length; left+=half * 2)
                {
                    int middle = left + half;

                    if (middle >= arr.Length)
                    {
                        break;
                    }
                    int right = left + half * 2;
                    if (right > arr.Length)
                    {
                        right = arr.Length;
                    }

                    Merge(arr, left, middle, right);
                }
            }

            return arr;
        }

        private static void Merge(int[] arr, int left, int middle, int right)
        {
            int i = left;
            int j = middle;
            var newArr = new List<int>();

            while (true)
            {
                // 5, 0, 3, 9
                if (i < middle && j < right)
                {
                    if (arr[i] > arr[j])
                    {
                        newArr.Add(arr[j]);
                        j++;
                    }
                    else
                    {
                        newArr.Add(arr[i]);
                        i++;
                    }
                }
                else if (i >= middle && j < right)
                {
                    newArr.Add(arr[j]);
                    j++;
                }
                else if (j >= right && i < middle)
                {
                    newArr.Add(arr[i]);
                    i++;
                }
                else
                {
                    break;
                }
            }

            for (int t = 0; t < newArr.Count; t++)
            {
                arr[left + t] = newArr[t];
            }
        }
    }
}
