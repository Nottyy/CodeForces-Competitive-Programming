using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace _900____B1216___Shooting
{
    class Shooting
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var orderedCans = Console.ReadLine().Split(' ').Select((x, y) => new { value = int.Parse(x), index = y }).OrderByDescending(x => x.value).ToArray();

            int result = 0;
            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                result += (orderedCans[i].value * i) + 1;
                sb.Append($"{orderedCans[i].index + 1} ");
            }

            Console.WriteLine(result);
            Console.WriteLine(sb.ToString());
        }
    }
}
