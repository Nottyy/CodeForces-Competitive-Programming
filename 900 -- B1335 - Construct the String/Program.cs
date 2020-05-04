using System;
using System.Text;

namespace _900____B1335___Construct_the_String
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');
                string result = ConstructString(line, sb);
                Console.WriteLine(result);
            }
        }

        private static string ConstructString(string[] line, StringBuilder sb)
        {
            sb.Clear();

            var length = int.Parse(line[0]);
            var lengthOfSubstring = int.Parse(line[1]);
            var distinctLetters = int.Parse(line[2]);
            int counter = 0;

            for (int i = 0; i < lengthOfSubstring; i++)
            {                
                if (counter >= distinctLetters)
                {
                    counter--;
                }
                sb.Append((char)(counter + 97));
                counter++;
            }
            var str = sb.ToString();

            for (int i = 1; i < length / lengthOfSubstring; i++)
            {
                sb.Append(str);
            }
            if (length % lengthOfSubstring != 0)
            {
                for (int i = 0; i < length % lengthOfSubstring; i++)
                {
                    sb.Append(sb[i]);
                }
            }

            return sb.ToString();
        }
    }
}
