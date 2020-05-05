using System;
using System.Linq;

namespace _800____A546___SoldierAndBananas
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int costOfFirstBanana = input[0];
            int initialSoldierDollars = input[1];
            int bananasSoliderWants = input[2];

            var totalCostOfBananas = costOfFirstBanana * CalculateSumOfFirstGivenNIntegers(bananasSoliderWants);

            var dollarsToBorrow = 0;
            if (totalCostOfBananas > initialSoldierDollars)
            {
                dollarsToBorrow = totalCostOfBananas - initialSoldierDollars;
            }

            Console.WriteLine(dollarsToBorrow);
        }

        static int CalculateSumOfFirstGivenNIntegers(int N)
        {
            // Sum of N given integers = N * (N + 1) / 2;
            int result = (N * (N + 1)) / 2;

            return result;
        }
    }
}
