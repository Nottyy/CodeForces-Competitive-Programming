using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciRecursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var memo = new int[5000];

            Console.WriteLine(Fibonacci(30, memo));
        }

        static int Fibonacci(int n, int[] memo)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            if (memo[n] == 0)
            {
                memo[n] = Fibonacci(n - 1, memo) + Fibonacci(n - 2, memo);
            }

            return memo[n];
        }
    }
}
