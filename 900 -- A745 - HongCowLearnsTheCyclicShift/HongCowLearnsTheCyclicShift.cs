using System;
using System.Collections.Generic;
using System.Text;

namespace _900____A745___HongCowLearnsTheCyclicShift
{
    class HongCowLearnsTheCyclicShift
    {
        static void Main()
        {
            var results = new HashSet<string>();

            var initialWordToSpell = Console.ReadLine();
            results.Add(initialWordToSpell);

            var sb = new StringBuilder();
            sb.Append(initialWordToSpell);

            for (int i = 0; i < initialWordToSpell.Length; i++)
            {
                char lastChar = sb.ToString()[initialWordToSpell.Length -1];
                sb.Remove(initialWordToSpell.Length - 1, 1);
                sb.Insert(0, lastChar);
                results.Add(sb.ToString());
            }

            Console.WriteLine(results.Count);
        }
    }
}
