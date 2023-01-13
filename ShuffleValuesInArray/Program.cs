using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShuffleValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ",Shuffle(10)));
        }

        static int[] Shuffle(int n)
        {
            var arr = new int[n];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = i;
            }

            var rnd = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                var j = rnd.Next() % (i + 1);
                if (i != j)
                {
                    var tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                }
            }

            return arr;
        }
    }
}
