using BinaryHeap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoding
{
    public class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();

            var frequencies = new Dictionary<char, int>();

            for (int i = 0; i < str.Length; i++)
            {
                var ch = str[i];

                if (frequencies.ContainsKey(ch))
                {
                    frequencies[ch]++;
                }
                else
                {
                    frequencies[ch] = 1;
                }
            }

            var queue = new PriorityQ<Tuple<int, HuffmanTree>>((x, y) => x.Item1 < y.Item1);

            foreach (var x in frequencies)
            {
                queue.Add(new Tuple<int, HuffmanTree>(x.Value,
                    new HuffmanTree(x.Key)));
            }

            while (queue.Count > 1)
            {
                var first = queue.RemoveTop();
                var second = queue.RemoveTop();

                queue.Add(new Tuple<int, HuffmanTree>(first.Item1 + second.Item1,
                    new HuffmanTree(first.Item2, second.Item2)));
            }

            var root = queue.RemoveTop().Item2;
            root.Dfs();
        }
    }
}
