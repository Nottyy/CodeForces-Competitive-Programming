using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    public static class BinaryHeapSort
    {
        public static void HeapSort<T>(this T[] array, Func<T, T, bool> cmfFunc)
        {
            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                array.HeapifyDown(cmfFunc, i, array[i], array.Length);
            }

            Console.WriteLine("After heapify - " + String.Join(" ", array));

            for (int i = array.Length - 1; i >= 0; i--)
            {
                var lastValue = array[i];
                var minElement = array[0];

                array[0] = lastValue;

                array.HeapifyDown(cmfFunc, 0, lastValue, i);
                array[i] = minElement;
            }

            Console.WriteLine("After sorting - " + String.Join(" ", array));
        }

        private static void HeapifyDown<T>(this T[] array, Func<T, T, bool> cmfFunc, 
            int currentIndex, T value, int length)
        {
            while (currentIndex * 2 + 1 < length)
            {
                var smallerChildIndex = cmfFunc(array[currentIndex * 2], array[currentIndex * 2 + 1]) ?
                    currentIndex * 2 : currentIndex * 2 + 1;

                if (cmfFunc(array[smallerChildIndex], value))
                {
                    var tmp = array[currentIndex];
                    array[currentIndex] = array[smallerChildIndex];
                    array[smallerChildIndex] = tmp;

                    currentIndex = smallerChildIndex;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
