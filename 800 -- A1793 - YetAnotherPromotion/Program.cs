using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _800____A1793___YetAnotherPromotion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                //15 4
                //3 1
                var line1 = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var a = line1[0];
                var b = line1[1];

                var line2 = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var n = line2[0];
                var promotion = line2[1];

                var aSum = a * promotion; // 5 * 1 = 5 -> 2
                var bSum = b * (promotion + 1); // 4 * 2 = 8 -> 2

                long result;

                if (aSum <= bSum)
                {
                    if (promotion >= n)
                    {
                        result = Math.Min(a, b) * n;
                    }
                    else
                    {
                        var q = n / (promotion + 1);
                        result = q * a * promotion;

                        var mod = n % (promotion + 1);
                        if (mod > 0)
                        {
                            result += Math.Min(a, b) * mod; //
                        }
                    }
                }
                else
                {
                    result = b * n;
                }

                Console.WriteLine(result);
            }
        }
    }
}
