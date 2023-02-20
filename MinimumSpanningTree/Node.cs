using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSpanningTree
{
    public class Node :IComparable<Node>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Distance { get; set; }

        public Node(int vertex, int distance)
        {
            this.X = vertex;
            this.Distance = distance;
        }

        public Node(int x, int y, int distance)
        {
            this.X = x;
            this.Y = y;
            this.Distance = distance;
        }

        public int CompareTo(Node other)
        {
            return this.Distance.CompareTo(other.Distance);
        }
    }
}
