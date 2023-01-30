using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTreesRecursive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new AvlTree<int>();

            tree.Add(20);
            tree.Add(15);
            tree.Add(18);
            Console.WriteLine(tree.Count);
            Console.WriteLine(tree.Height);
            Console.WriteLine(tree.root.Value);
        }
    }
}
