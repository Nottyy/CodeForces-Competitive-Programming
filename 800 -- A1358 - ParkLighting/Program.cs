using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _800____A1358___ParkLighting
{
    class Program
    {
        static void Main()
        {
            var cases = int.Parse(Console.ReadLine());

            for (int i = 0; i < cases; i++)
            {
                var matrixSize = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                float res = (matrixSize[0] * matrixSize[1] + 1) / 2;
                Console.WriteLine(res);
            }
        }
    }
}
