using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _800____A1776___WalkingBoy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                var n = int.Parse(Console.ReadLine());
                var cases = Console.ReadLine().Split(' ').Select(int.Parse).OrderBy(x => x).ToArray();

                var start = 0;
                var result = 0;
                bool finished = false;

                for (int j = 0; j < n; j++)
                {
                    var cTime = cases[j];
                    var diff = cTime - start;
                    if (diff >= 120)
                    {
                        if (diff >= 240)
                        {
                            result = 2;
                            finished = true;
                            Console.WriteLine("YES");
                            break;
                        }
                        result++;
                        start = cTime;
                    }
                    else
                    {
                        start = cTime;
                    }
                }

                if (!finished)
                {

                    if (1440 - start >= 120)
                    {
                        result++;
                        if (1440 - start >= 240)
                        {
                            result++;
                        }
                    }

                    if (result < 2)
                    {
                        Console.WriteLine("NO");
                    }
                    else
                    {
                        Console.WriteLine("YES");
                    }
                }
            }
        }
    }
}
