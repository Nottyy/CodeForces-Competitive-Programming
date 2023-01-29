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
            for (int i = 0; i < 4; i++)
            {
                tree.Add(i);
                Console.WriteLine(String.Join(" ", tree));
            }

            //tree.Add(20);
            //tree.Add(15);
            //tree.Add(16);
            Console.WriteLine(tree.Count);
            Console.WriteLine(tree.Height);
        }
    }
}
