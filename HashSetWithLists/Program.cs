using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSetWithLists
{
    public class Program
    {
        static void Main(string[] args)
        {
            var hash = new HashsetWithLists<int>();

            for (int i = 0; i < 20; i++)
            {
                hash.Add(i);
            }

            Console.WriteLine(String.Join(" ", hash));
            Console.WriteLine(hash.Remove(4));
            Console.WriteLine(String.Join(" ", hash));
            Console.WriteLine(hash.Remove(4));
            Console.WriteLine(hash.Remove(111));
            Console.WriteLine(hash.Remove(5));
            Console.WriteLine(hash.Remove(6));
            Console.WriteLine(String.Join(" ", hash));


        }
    }
}
