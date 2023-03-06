using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _800____A1691___BeatTheOdds
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

                var evenNumsCount = nums.Count(x => x % 2 == 0);

                Console.WriteLine(evenNumsCount < nums.Length - evenNumsCount ? evenNumsCount : nums.Length - evenNumsCount);
            }
        }
    }
}
