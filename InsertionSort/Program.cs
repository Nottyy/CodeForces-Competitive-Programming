using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 2, 4, 0, 8, 1, 5, 55, 66, 101, 1, 2, 4, 3, 7, 11, 44, 33 };
            var pos = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    pos = i;

                    while (pos > 0 && arr[pos] < arr[pos - 1])
                    {
                        var current = arr[pos];
                        arr[pos] = arr[pos - 1];
                        arr[pos - 1] = current;
                        pos--;
                    }
                }
            }

            Console.WriteLine(String.Join(" ", arr));
        }
    }
}
