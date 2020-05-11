using System;
using System.Collections.Generic;
using System.Linq;

namespace _1500____E1352___SpecialElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var arrLength = int.Parse(Console.ReadLine());
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var hashset = new HashSet<int>(input);
                int specialNumbers = CalculateSpecialNumber(input, hashset);
                Console.WriteLine(specialNumbers);
            }
        }

        private static int CalculateSpecialNumber(int[] input, HashSet<int> hashset)
        {
            int specialNumbers = 0;
            int currentSum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                currentSum = input[i];
                for (int j = i + 1; j < input.Length; j++)
                {
                    currentSum += input[j];
                    if(currentSum > input.Length)
                    {
                        break;
                    }
                    if (hashset.Contains(currentSum))
                    {
                        specialNumbers++;
                    }
                }
            }

            return specialNumbers;
        }
    }
}
