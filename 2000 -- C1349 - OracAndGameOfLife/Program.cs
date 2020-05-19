using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace _2000____C1349___OracAndGameOfLife
{
    public class Node
    {
        public Node(int vertex, bool boolValue, bool from)
        {
            Vertex = vertex;
            BoolValue = boolValue;
            FromBoolValue = from;
        }

        public int Vertex { get; set; }
        public bool BoolValue { get; set; }
        public bool FromBoolValue { get; set; }
    }
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var rows = input[0];
            var cols = input[1];
            var queries = input[2];

            var matrix = ReadMatrix(rows, cols);
            var vertices = ReadVertices(matrix, rows, cols);

            for (int i = 0; i < queries; i++)
            {
                var query = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
                var qRow = query[0];
                var qCol = query[1];
                var p = query[2];

                long startIndex = qRow == 1 ? qCol : qCol + (qRow- 1) * cols;

                long res = BFSQueue(startIndex, vertices, p);

                if (res == -1)
                {
                    Console.WriteLine(matrix[qRow,qCol] == true ? 0 : 1);
                }
                else
                {
                    if (p - res == 0)
                    {
                        Console.WriteLine(matrix[qRow, qCol] == true ? 1 : 0);
                    }
                    else
                    {
                        if ((p - res) % 2 == 0)
                        {
                            Console.WriteLine(matrix[qRow, qCol] == true ? 1 : 0);
                        }
                        else
                        {
                            Console.WriteLine(matrix[qRow, qCol] == true ? 0 : 1);
                        }
                    }
                }
            }
        }

        private static long BFSQueue(long startVertex, LinkedList<Node>[] vertices, long iteration)
        {
            bool[] used = new bool[vertices.Length + 1];
            used[startVertex] = true;
            var distances = new long[vertices.Length + 1];
            distances[startVertex - 1] = 0;
            var queue = new Queue<long>();
            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                foreach (var next in vertices[vertex])
                {
                    if (used[next.Vertex])
                    {
                        continue;
                    }

                    distances[next.Vertex] = distances[vertex] + 1;
                    
                    if (next.BoolValue == next.FromBoolValue)
                    {
                        return distances[next.Vertex];
                    }

                    if (distances[next.Vertex] > iteration)
                    {
                        return -1;
                    }

                    used[next.Vertex] = true;
                    queue.Enqueue(next.Vertex);
                }
            }

            return -1;
        }

        

        private static LinkedList<Node>[] ReadVertices(bool[,] matrix, int rows, int cols)
        {
            var newMatrix = new LinkedList<Node>[(rows * cols) + 1];

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= cols; j++)
                {
                    int currentIndex = i == 1 ? j : j + (i - 1) * cols;
                    newMatrix[currentIndex] = new LinkedList<Node>();
                    // up 1
                    if (i > 1)
                    {
                        newMatrix[currentIndex].AddLast(new Node(currentIndex - cols, matrix[i - 1, j], matrix[i,j]));
                    }
                    // down 1
                    if (i <= cols - 1)
                    {
                        newMatrix[currentIndex].AddLast(new Node(currentIndex + cols, matrix[i + 1, j], matrix[i, j]));
                    }

                    // left 1
                    if (j > 1)
                    {
                        newMatrix[currentIndex].AddLast(new Node(currentIndex - 1, matrix[i, j - 1], matrix[i, j]));
                    }

                    // right 1
                    if (j <= cols - 1)
                    {
                        newMatrix[currentIndex].AddLast(new Node(currentIndex + 1, matrix[i, j + 1], matrix[i, j]));
                    }

                }
            }

            return newMatrix;
        }

        private static bool[,] ReadMatrix(int rows, int cols)
        {
            var matrix = new bool[rows + 1, cols + 1];
            for (int i = 1; i <= matrix.GetLength(0) - 1; i++)
            {
                var rowLine = Console.ReadLine();
                for (int j = 1; j <= matrix.GetLength(1) - 1; j++)
                {
                    matrix[i, j] = rowLine[j - 1] == '1' ? false : true;
                }
            }

            return matrix;
        }
    }
}
