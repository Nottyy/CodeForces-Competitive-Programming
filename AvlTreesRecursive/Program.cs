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
            tree.Add(15);
            tree.Add(10);
            tree.Add(5);
            tree.Add(2);
            tree.Add(9);
            tree.Add(12);
            tree.Add(11);
            tree.Add(14);
            tree.Add(20);
            tree.Add(25);
            tree.Add(17);
            tree.Add(50);
            tree.Add(22);

            tree.Remove(10);
            Console.WriteLine(String.Join(" ", tree));

            Console.WriteLine(tree.Count);
            Console.WriteLine(tree.Height);
        }
    }
}
