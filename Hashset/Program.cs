using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Hashset
{
    public class Program
    {
        static void Main(string[] args)
        {
            var hash1 = new HashsetNew<int>();
            for (int i = 0; i < 100; i++)
            {
                hash1.Add(i);
            }
            //Console.WriteLine(hash1.Count);
            //Console.WriteLine(hash1.Contains(1));
            //hash1.Remove(1);
            Console.WriteLine(hash1.Count);
            //Console.WriteLine(hash1.Contains(1));

            Console.WriteLine(String.Join(" ", hash1));
        }
    }
}
