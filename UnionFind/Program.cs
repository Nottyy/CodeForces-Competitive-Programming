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

            while (true)
            {
                uf.Print();

                var strs = Console.ReadLine().Split(' ').ToArray();

                if (strs[0] == "u")
                {
                    var first = int.Parse(strs[1]);
                    var second = int.Parse(strs[2]);

                    uf.Union(first, second);
                }
                else if (strs[0] == "f")
                {
                    var first = int.Parse(strs[1]);

                    Console.WriteLine(uf.FindParentRecursive(first));
                }
            }

        }
    }
}
