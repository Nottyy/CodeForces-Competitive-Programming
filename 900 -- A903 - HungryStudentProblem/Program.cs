using System;

namespace _900____A903___HungryStudentProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int chickenChunks = int.Parse(Console.ReadLine());

                if (chickenChunks % 3 == 0 || chickenChunks % 7 == 0 || chickenChunks % 10 == 0)
                {
                    Console.WriteLine("YES");
                    continue;
                }

                if (chickenChunks > 7)
                {
                    if ((chickenChunks - 3) % 7 == 0 || (chickenChunks - 3) % 3 == 0 || (chickenChunks - 3) % 10 == 0 || 
                        (chickenChunks - 7) % 7 == 0 || (chickenChunks - 7) % 3 == 0 ||(chickenChunks - 7) % 10 == 0)
                    {
                        Console.WriteLine("YES");
                        continue;
                    }
                }
                Console.WriteLine("NO");
            }

        }
    }
}
