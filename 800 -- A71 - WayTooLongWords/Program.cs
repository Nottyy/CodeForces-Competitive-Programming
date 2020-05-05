using System;
using System.Text;

namespace _800____A71___WayTooLongWords
{
    public class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var word = Console.ReadLine();

                if (word.Length > 10)
                {
                    sb.Append(word[0]);
                    sb.Append(word.Length - 2);
                    sb.Append(word[word.Length - 1]);
                    sb.AppendLine();
                }
                else
                {
                    sb.AppendLine(word);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
