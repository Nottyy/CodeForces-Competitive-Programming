﻿using System;
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
            var arr = new int[8];
            var rnd = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(100);
            }

            //Console.WriteLine(" ---- " + String.Join(" ", arr));

            var heap = new BinaryHeap<int>((a, b) => a < b);

            for (int i = 0; i < arr.Length; i++)
            {
                heap.Add(arr[i]);
                //Console.Write(heap.Top + " ");
            }
            Console.WriteLine(" ---- " + String.Join(" ", arr));


            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine();
                arr[i] = heap.RemoveTop();
                Console.WriteLine("Before -> " + String.Join(" ", heap.heap));
                
                //heap.RemoveTop();
                //Console.WriteLine("After -> " + String.Join(" ", heap.heap));
            }

            Console.WriteLine(" ---- " + String.Join(" ", arr));

        }
    }
}