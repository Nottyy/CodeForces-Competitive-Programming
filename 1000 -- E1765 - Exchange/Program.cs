using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000____E1765___Exchange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputNum; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(o => int.Parse(o)).ToArray();
                var n = input[0];
                var a = input[1];
                var b = input[2];

                if (a <= b)
                {
                    int remainder;
                    int quotient = Math.DivRem(n, a, out remainder);
                    Console.WriteLine(remainder == 0 ? quotient : quotient + 1);
                }
                else
                {
                    Console.WriteLine(1);
                }
            }
        }
    }
}
