using System;
using System.Linq;

namespace A._263___Beautiful_Matrix
{
    class Program
    {
        public const int BeautifulMatrixRow = 3;
        public const int BeautifulMatrixCol = 3;
       
        static void Main(string[] args)
        {
            int numberOneInitialRow = 0;
            int numberOneInitialCol = 0;
            for (int i = 1; i <= 5; i++)
            {
                var line = String.Join("", Console.ReadLine().Split(' '));
                if (line.Contains("1"))
                {
                    numberOneInitialRow = i;
                    numberOneInitialCol = line.IndexOf("1") + 1;
                    break;
                }
            }

            var result = Math.Abs(BeautifulMatrixCol - numberOneInitialCol) + Math.Abs(BeautifulMatrixRow - numberOneInitialRow);
            Console.WriteLine(result);
        }
    }
}
