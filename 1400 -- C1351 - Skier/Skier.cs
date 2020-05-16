using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace _1400____C1351___Skier
{
    public struct SkierDirection 
    {
        public SkierDirection(int x1, int y1, int x2, int y2)
        {
            this.X1 = x1;
            this.X2 = x2;
            this.Y1 = y1;
            this.Y2 = y2;
        }

        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }


        public override bool Equals(Object obj)
        {
            var outer = (SkierDirection)obj;
            return outer.X1 == this.X1 &&
                outer.Y1 == this.Y1 &&
                outer.X2 == this.X2 &&
                outer.Y2 == this.Y2;
        }
        
        public override int GetHashCode()
        {
            return 1000000009 * this.X1 * this.X1 * this.X1 * this.X1 * this.X1 + 31 * 
                this.Y1 * this.Y1 * this.Y1 * this.Y1 + 29 * X2 * X2 * X2 + 41 * Y2 * Y2 + 101;
        }

        public SkierDirection GetOppMove()
        {
            return new SkierDirection(X2, Y2, X1, Y1);
        }
    }
    public class Skier
    {
        static void Main()
        {
            int t = int.Parse(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                var directions = Console.ReadLine();
                var hashset = new HashSet<SkierDirection>();
                var totalSum = 0;
                var currentHorizontalPos = 0;
                var currentVerticalPos = 0;

                for (int j = 0; j < directions.Length; j++)
                {
                    var tempHorPos = currentHorizontalPos;
                    var tempVerPos = currentVerticalPos;
                    switch (directions[j])
                    {
                        case 'S':
                            currentVerticalPos--;
                            break;
                        case 'N':
                            currentVerticalPos++;
                            break;
                        case 'E':
                            currentHorizontalPos++;
                            break;
                        case 'W':
                            currentHorizontalPos--;
                            break;
                    }

                    var newDirPos = new SkierDirection(tempHorPos, tempVerPos, currentHorizontalPos, currentVerticalPos);
                    

                    if (hashset.Contains(newDirPos))
                    {
                        totalSum += 1;
                    }
                    else
                    {
                        totalSum += 5;
                    }

                    hashset.Add(newDirPos);
                    hashset.Add(newDirPos.GetOppMove());
                }

                Console.WriteLine(totalSum);
            }
        }
    }
}
