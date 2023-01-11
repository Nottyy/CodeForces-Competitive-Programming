using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 12, 2, 5, 6, 9, 0, 1, 10, 7 };
            Console.WriteLine(String.Join(" ", MergeSort(arr)));
            Console.WriteLine(String.Join(" ", MergeSort(arr)));

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
