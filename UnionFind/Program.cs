using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var uf = new UnionFind(10);
            uf[1] = 2;
            uf[3] = 4;
            uf[4] = 5;

            for (int i = 0; i < 10; i++)
            {
                var parent = uf.FindParentRecursive(i);
                Console.WriteLine($"Parent of '{i}' is -> " + (parent == i ? "No parent" : parent.ToString()));
            }

            Console.WriteLine(uf.Union(3, 1));
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                var parent = uf.FindParentRecursive(i);
                Console.WriteLine($"Parent of '{i}' is -> " + (parent == i ? "No parent" : parent.ToString()));
            }
        }
    }
}
