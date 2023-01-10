using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FastPower(5,5));
        }

        static int FastPower(int n, int p)
        {
            if (p == 0)
            {
                return 1;
            }

            if (p % 2 == 1)
            {
                return n * FastPower(n, p - 1);
            }

            int half = FastPower(n, p / 2);
            return half * half;

            
        }
    }
}
