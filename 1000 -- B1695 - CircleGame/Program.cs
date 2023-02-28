using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000____B1695___CircleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                var n = int.Parse(Console.ReadLine());
                var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                if (n % 2 == 0)
                {
                    var smallestInd = Array.IndexOf(nums, nums.Min());

                    if (smallestInd % 2 > 0)
                    {
                        Console.WriteLine("Mike");
                    }
                    else
                    {
                        Console.WriteLine("Joe");
                    }
                }
                else
                {
                    Console.WriteLine("Mike");
                }
            }
        }
    }
}
