using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();

            var rnd = new Random();
            var size = 20;
            var arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = rnd.Next(50);
            }
            //var arr = new int[] { 3, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0, 2, 5, 6, 9, 1, 8, 7, 4, 0 };
            //Console.WriteLine(String.Join(" ", MergeSort(arr)));
            sw.Start();
            MergeSort(arr);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

        }

        static int[] MergeSort(int[] arr)
        {
            if (arr.Length == 1)
            {
                return arr;
            }

            var firstArray = arr.Take(arr.Length / 2).ToArray();
            var secondArray = arr.Skip(arr.Length / 2).ToArray();

            var sortedFirstArr = MergeSort(firstArray);
            var sortedSecondArr = MergeSort(secondArray);

            var newArr = new List<int>();
            var firstPointer = 0;
            var secondPointer = 0;

            for (int i = 0; i < sortedFirstArr.Length + sortedSecondArr.Length; i++)
            {
                if (firstPointer > sortedFirstArr.Length - 1)
                {
                    while (secondPointer < sortedSecondArr.Length)
                    {
                        newArr.Add(sortedSecondArr[secondPointer]);
                        secondPointer++;
                    }
                    break;
                }

                if (secondPointer > sortedSecondArr.Length - 1)
                {
                    while (firstPointer < sortedFirstArr.Length)
                    {
                        newArr.Add(sortedFirstArr[firstPointer]);
                        firstPointer++;
                    }
                    break;
                }


                if (sortedFirstArr[firstPointer] < sortedSecondArr[secondPointer])
                {
                    newArr.Add(sortedFirstArr[firstPointer]);
                    firstPointer++;
                }
                else
                {
                    newArr.Add(sortedSecondArr[secondPointer]);
                    secondPointer++;
                }
            }
                
            return newArr.ToArray();
        }
    }
}
