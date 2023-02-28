using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000____B1704___LukeIsAFoodie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                var line1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var n = line1[0];
                var x = line1[1];

                var nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var counter = 0;
                int min = nums[0];
                int max = nums[0];

                for (int j = 1; j < n; j++)
                {
                    if (nums[j] > max)
                    {
                        max = nums[j];
                    }

                    if (nums[j] < min)
                    {
                        min = nums[j];
                    }

                    if (max - min > 2 * x)
                    {
                        counter++;
                        min = nums[j];
                        max = nums[j];
                    }
                }

                Console.WriteLine(counter);
            }
        }
    }
}
