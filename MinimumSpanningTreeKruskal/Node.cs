using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSpanningTreeKruskal
{
    public class Node :IComparable<Node>
    {
        public Node(int x, int y, int distance)
        {
            this.X = x;
            this.Y = y;
            this.Distance = distance;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Distance { get; set; }

        public int CompareTo(Node other)
        {
            return this.Distance.CompareTo(other.Distance);
        }

        public override string ToString()
        {
            return $"{this.X} -> {this.Y} ({this.Distance})";
        }
    }
}
