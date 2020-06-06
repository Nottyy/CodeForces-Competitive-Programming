using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _800____A492___VanyaAndCubes
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());

            var height = 0;
            var cur = 0;
            var counter = 1;
            var result = 0;
            while (true)
            {
                cur = cur + counter;
                result += cur;
                
                if (result > num)
                {
                    Console.WriteLine(height);
                    break;
                }
                height++;
                counter++;
            }
        }
    }
}
