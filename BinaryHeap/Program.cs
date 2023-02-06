using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryHeap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[18];
            var rnd = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(100);
            }

            Console.WriteLine(String.Join(" ", arr));

            var heap = new BinaryHeap<int>((a, b) => a < b);

            for (int i = 0; i < arr.Length; i++)
            {
                heap.Add(arr[i]);
                Console.Write(heap.Top + " ");
            }

        }
    }
}
