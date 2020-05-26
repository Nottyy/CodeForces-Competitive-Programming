using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _1400____B1348___PhoenixAndBeauty
{
    class Program
    {
        static void Main()
        {
            int t = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();

            for (int i = 0; i < t; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var arrLength = input[0];
                var k = input[1];


                var beautifulArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                if (arrLength == k)
                {
                    Console.WriteLine(beautifulArr.Length);
                    Console.WriteLine(string.Join(" ", beautifulArr));
                    continue;
                }

                var hashset = new HashSet<int>(beautifulArr);

                if (hashset.Count > k)
                {
                    Console.WriteLine("-1");
                }

                else
                {
                    var counter = 0;
                    foreach (var item in hashset)
                    {
                        sb.Append(item + " ");
                        counter++;
                    }
                    if (counter < k)
                    {
                        var sbLength = k - counter;
                        for (int j = 0; j < sbLength; j++)
                        {
                            sb.Append("1 ");
                        }
                    }

                    var result = sb.ToString();
                    Console.WriteLine(k * arrLength);

                    for (int j = 1; j < arrLength; j++)
                    {
                        sb.Append(result);
                    }

                    Console.WriteLine(sb.ToString().Trim());

                    sb.Clear();
                }
            }
        }
    }
}
