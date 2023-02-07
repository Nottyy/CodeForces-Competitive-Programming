using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvlTreesExerciseImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var root = new AvlNode<int>(15);
            var rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                //AvlNode<int>.Add(ref root, rnd.Next(200));

                AvlNode<int>.Add(ref root, 10);
                AvlNode<int>.Add(ref root, 25);
                AvlNode<int>.Add(ref root, 5);
                AvlNode<int>.Add(ref root, 4);
            }

            var s = 5;
        }
    }
}
