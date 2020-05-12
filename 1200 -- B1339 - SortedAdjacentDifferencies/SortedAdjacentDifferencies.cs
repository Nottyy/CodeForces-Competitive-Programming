using System;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _1200____B1339___SortedAdjacentDifferencies
{
    class SortedAdjacentDifferencies
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int arrLength = int.Parse(Console.ReadLine());
                var arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var rearrangedArray = new int[arrLength];
                Array.Sort(arr);

                var counter = 0;
                var counterLength = arrLength % 2 == 0 ? arrLength / 2 : arrLength / 2 + 1;
                while (counter < counterLength)
                {
                    rearrangedArray[arrLength - 1 - (counter * 2)] = arr[arrLength - 1 - counter];
                    if (arrLength % 2 != 0 && counter == counterLength - 1)
                    {
                        break;
                    }
                    rearrangedArray[arrLength - 1 - (counter * 2) - 1] = arr[counter];
                    counter++;
                }

                Console.WriteLine(string.Join(" ", rearrangedArray));
            }
        }
    }
}
