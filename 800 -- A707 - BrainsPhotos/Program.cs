using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _800____A707___BrainsPhotos
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var n = input[0];
            var m = input[1];
            bool contains = false;

            for (int i = 0; i < n; i++)
            {
                if (Console.ReadLine().Split(' ').Any(x => x == "C" || x == "M" || x == "Y"))
                {
                    contains = true;
                    break;
                }
            }


            if (contains)
            {
                Console.WriteLine("#Color");
            }
            else
            {
                Console.WriteLine("#Black&White");
            }
        }
    }
}
