using System;
using System.Linq;

namespace _900____B764___TimofeyAndCubes
{
    class TimofeyAndCubes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var changedOrderArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] originalOrderArr = new int[n];

            for (int i = 0; i < n / 2; i++)
            {
                if (i % 2 == 0)
                {
                    originalOrderArr[i] = changedOrderArr[n - i - 1];
                    originalOrderArr[n - i - 1] = changedOrderArr[i];
                }
                else
                {
                    originalOrderArr[i] = changedOrderArr[i];
                    originalOrderArr[n - i - 1] = changedOrderArr[n - i - 1];
                }
                
            }
            if (n % 2 != 0)
            {
                originalOrderArr[n / 2] = changedOrderArr[n / 2];
            }
            Console.WriteLine(string.Join(" ", originalOrderArr));
        }
    }
}
