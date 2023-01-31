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
            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                tree.Add(i);
            }
            Console.WriteLine(tree.Count);            
            Console.WriteLine(tree.Height);

            Console.WriteLine(String.Join(" ", tree));
        }
    }
}
