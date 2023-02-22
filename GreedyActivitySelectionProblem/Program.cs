using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyActivitySelectionProblem
{
    public class Interval
    {
        public Interval(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }

        public int Start { get; set; }
        public int End { get; set; }
    }
    internal class Program
    {
        private static string input = @"6
1 5
2 5
3 6
6 9
8 10
10 15";
        static void Main(string[] args)
        {
            Console.SetIn(new StringReader(input));
            var n = int.Parse(Console.ReadLine());

            var intervals = new Interval[n];

            for (int i = 0; i < n; i++)
            {
                var interval = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var start = interval[0];
                var end = interval[1];

                intervals[i] = new Interval(start, end);
            }

            var sortedIntervals = intervals.OrderBy(x => x.End);

            var result = 1;
            var previous = intervals[0];
            for (int i = 1; i < sortedIntervals.Count(); i++)
            {
                var current = intervals[i];

                if (current.End <= previous.End)
                {
                    continue;
                }

                if (current.Start < previous.End)
                {
                    continue;
                }

                previous = current;
                result++;
            }

            Console.WriteLine(result);
        }
    }
}
