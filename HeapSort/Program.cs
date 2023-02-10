using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[10];
            var rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(50);
            }

            BinaryHeapSort.HeapSort(arr, (a, b) => a > b);
        }
    }
}
