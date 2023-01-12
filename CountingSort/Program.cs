using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            var size = 1000;
            var arr = new int[size + 1];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(100);
            }

            Console.WriteLine(String.Join(" ", CountingSort(arr, 100)));
        }

        static int[] CountingSort(int[] arr, int n)
        {
            var newArr = new int[n];
            for (int i = 0; i < arr.Length; i++)
            {
                newArr[arr[i]]++;
            }

            var sortedArr = new int[arr.Length];
            var index = 0;

            for (int j = 0; j < newArr.Length; j++)
            {
                if (newArr[j] != 0)
                {
                    for (int p = 0; p < newArr[j]; p++)
                    {
                        sortedArr[index] = j;
                        index++;
                    }
                }
            }

            Console.WriteLine(sortedArr.Length);
            return sortedArr;
        }
    }
}
