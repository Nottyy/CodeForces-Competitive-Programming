﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new MyDictionary<int, int>();
            for (int i = 0; i < 10; i++)
            {
                dict.Add(i, i * 2);
            }

            Console.WriteLine(String.Join(" ", dict));

            dict[50] = 101;
            Console.WriteLine(String.Join(" ", dict));

            dict[51] = 222;
            dict[51] = 222;
            dict[51] = 222;
            dict[51] = 444;

            Console.WriteLine(String.Join(" ", dict));


        }
    }
}
