using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class Program
    {
        static void Main(string[] args)
        {
            var tree1 = new Tree<int>(20);
            var tree2 = new Tree<int>(10);
            var tree3 = new Tree<int>(30);
            var tree4 = new Tree<int>(5);
            var tree5 = new Tree<int>(25);
            var tree6 = new Tree<int>(15);
            var tree7 = new Tree<int>(35);

            tree1.Left = tree2;
            tree1.Right = tree3;

            tree2.Left = tree4;
            tree2.Right = tree6;

            tree3.Left = tree5;
            tree3.Right = tree7;

            tree5.Left = new Tree<int>(22);
            tree5.Right = new Tree<int>(28);

            DFS(tree2);
        }

        static void DFS<T>(Tree<T> tree)
        {
            if (tree == null)
            {
                return;
            }


            DFS(tree.Left);
            Console.WriteLine(tree.Value);
            DFS(tree.Right);
        }
    }
}
