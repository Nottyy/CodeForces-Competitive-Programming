using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchIterative
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 5, 6, 10, 20, 30, 40 };
            Console.WriteLine(arr.BinarySearchIterative(3));
        }
        public static int BinarySearchIterative<T>(this T[] arr, T value)
        where T : IComparable<T>
        {
            int left = 0;
            int right = arr.Length;

            while (left < right)
            {
                int middle = (left + right) / 2;
                var cmp = arr[middle].CompareTo(value);

                if (cmp < 0)
                {
                    left = middle + 1;
                }
                else if (cmp > 0)
                {
                    right = middle;
                }
                else
                {
                    return middle;
                }
            }

            return -1;
        }
    }
    
}
