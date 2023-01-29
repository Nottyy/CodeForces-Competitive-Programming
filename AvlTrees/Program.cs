using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTrees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new AvlTree<int>();
            for (int i = 10; i > 0; i--)
            {
                tree.Add(i);
                Console.WriteLine(String.Join(" ", tree));
                Console.WriteLine("Root is " + tree.root.Value);
            }

            Console.WriteLine(tree.Count);
            Console.WriteLine(tree.Height);

            tree = new AvlTree<int>();
            for (int i = 0; i < 10; i++)
            {
                tree.Add(i);
                Console.WriteLine(String.Join(" ", tree));
            }
            //tree.Add(20);
            //tree.Add(15);
            //tree.Add(16);
            //tree.Add(11);
            Console.WriteLine(tree.Count);
            Console.WriteLine(tree.Height);
        }
    }
}
