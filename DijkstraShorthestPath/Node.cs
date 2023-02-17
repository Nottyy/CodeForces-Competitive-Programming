using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraShorthestPath
{
    public class Node :IComparable<Node>
    {
        public Node(int vertex, int distance)
        {
            this.Vertex = vertex;
            this.Distance = distance;
        }

        public int Vertex { get; set; }

        public int Distance { get; set; }

        public int CompareTo(Node other)
        {
            return this.Distance.CompareTo(other.Distance);
        }
    }
}
