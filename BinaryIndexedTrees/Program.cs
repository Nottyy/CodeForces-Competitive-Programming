using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryIndexedTrees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var func = new Func<int, int, int>((a, b) => a + b);
            var tree = new BinaryIndexedTree<int>(5, func);

            while (true)
            {
                var strs = Console.ReadLine().Split(' ').ToArray();

                if (strs[0] == "u")
                {
                    var index = int.Parse(strs[1]);
                    var value = int.Parse(strs[2]);
                    tree[index] = value;
                }
                else if (strs[0] == "q")
                {
                    var left = int.Parse(strs[1]);
                    var right = int.Parse(strs[2]);
                    Console.WriteLine(tree.GetInterval(left, right));
                }
            }
        }
    }
}
