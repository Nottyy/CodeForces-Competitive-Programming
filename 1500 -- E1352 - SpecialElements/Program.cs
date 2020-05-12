using System;
using System.Collections.Generic;
using System.Linq;

namespace _1500____E1352___SpecialElements
{
    class Program
    {
        //9
        //3 1 4 1 5 9 2 6 5
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var arrLength = int.Parse(Console.ReadLine());
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var frequencies = new int[arrLength + 1];

                for (int j = 0; j < input.Length; j++)
                {
                    var currentNum = input[j];
                    frequencies[currentNum]++;
                }

                //var hashset = new HashSet<int>(input);
                int specialNumbers = CalculateSpecialNumber(input, frequencies);
                Console.WriteLine(specialNumbers);
            }
        }

        private static int CalculateSpecialNumber(int[] input, int[] frequencies)
        {
            int specialNumbers = 0;
            int currentSum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                currentSum = input[i];
                for (int j = i + 1; j < input.Length; j++)
                {
                    currentSum += input[j];
                    if (currentSum > input.Length)
                    {
                        break;
                    }
                    if (frequencies[currentSum] > 0)
                    {
                        specialNumbers += frequencies[currentSum];
                        frequencies[currentSum] = 0;
                    }
                }
            }

            return specialNumbers;
        }
    }
}
