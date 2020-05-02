using System;

namespace A._Anton_and_Polyhedrons
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                string figure = Console.ReadLine().Trim().ToLower();
                switch (figure)
                {
                    case "tetrahedron":
                        sum += 4;
                        break;
                    case "cube":
                        sum += 6;
                        break;
                    case "octahedron":
                        sum += 8;
                        break;
                    case "dodecahedron":
                        sum += 12;
                        break;
                    case "icosahedron":
                        sum += 20;
                        break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
