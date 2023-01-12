using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchRecursion
{
    static class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 1, 5, 10, 15, 20, 25, 40 };
            Console.WriteLine(arr.BinarySearchRecursion(40));
        }

        public static int BinarySearchRecursion<T>(this T[] arr, T value) 
            where T: IComparable<T>
        {
            return arr.BinarySearchRecursion(value, 0, arr.Length);
        }

        private static int BinarySearchRecursion<T>(this T[] arr, T value, int left, int right) 
            where T : IComparable<T>
        {
            if (left >= right)
            {
                return -1;
            }

            var middle = (left + right) / 2;
            var cmp = arr[middle].CompareTo(value);

            if (cmp < 0)
            {
                return arr.BinarySearchRecursion(value, middle + 1, right);
            }
            if (cmp > 0)
            {
                return arr.BinarySearchRecursion(value, left, middle);
            }

            return middle;
        }
    }
}
