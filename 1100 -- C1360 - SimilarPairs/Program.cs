using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1100____C1360___SimilarPairs
{
    class Program
    {
        static void Main()
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Array.Sort(input);
                var evenCount = input.Count(x => x % 2 == 0);
                var oddCount = input.Count(x => x % 2 != 0);

                if (CheckEvenCount(evenCount, oddCount))
                {
                    Console.WriteLine("YES");
                    continue;
                }

                if (input.Length == 2 && Math.Abs(input[0] - input[1]) == 1)
                {
                    Console.WriteLine("YES");
                    continue;
                }

                var found = false;
                for (int j = 1; j < input.Length; j++)
                {
                    if (Math.Abs(input[j - 1] - input[j]) == 1)
                    {
                        evenCount--;
                        oddCount--;
                        if (CheckEvenCount(evenCount, oddCount))
                        {
                            found = true;
                            break;
                        }
                    }
                }
                if (found)
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }

        }

        private static bool CheckEvenCount(int num1, int num2)
        {
            return num1 % 2 == 0 && num2 % 2 == 0;
        }
    }
}
