using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1000____D1702___NotACheapString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                var line1 = Console.ReadLine();
                var unsortedElements = new int[line1.Length][];

                for (int j = 0; j < line1.Length; j++)
                {
                    unsortedElements[j] = new int[] { line1[j], j };
                }

                var sortedElements = unsortedElements.OrderByDescending(x => x[0]).ToArray();

                var p = int.Parse(Console.ReadLine());

                var sum = sortedElements.Sum(x => (int)x[0] % 32);

                var counter = 0;

                if (p >= sum)
                {
                    Console.WriteLine(line1);
                }
                else
                {
                    while (sum > p)
                    {
                        var cur = (int)sortedElements[counter][0] % 32;
                        sum -= cur;
                        unsortedElements[sortedElements[counter][1]][0] = 0;
                        counter++;
                        
                    }
                    var result = string.Join("", unsortedElements.Where(x => x[0] != 0).Select(x => (char)(x[0])).ToArray());
                    Console.WriteLine(result);
                }
            }
        }
    }
}
