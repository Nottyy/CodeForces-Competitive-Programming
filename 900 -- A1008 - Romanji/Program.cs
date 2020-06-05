using System;
using System.Linq;

namespace _900____A1008___Romanji
{
    class Program
    {
        private static bool IsVowel(char ch)
        {
            if (ch =='a' || ch == 'o' || ch == 'u' || ch == 'i' || ch == 'e')
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {

            var word = Console.ReadLine();
            //var vowels = new char[] { 'a', 'o', 'u', 'i', 'e' };
            bool answer = true;

            for (int i = 0; i < word.Length; i++)
            {
                var currentChar = word[i];

                bool isCurConsonant = !IsVowel(currentChar);

                if (currentChar == 'n' || !isCurConsonant)
                {
                    continue;
                }

                if (i + 1 >= word.Length || !IsVowel(word[i + 1]))
                {
                    answer = false;
                    break;
                }
                
            }

            Console.WriteLine(answer == true ? "YES" : "NO");
        }
    }
}
