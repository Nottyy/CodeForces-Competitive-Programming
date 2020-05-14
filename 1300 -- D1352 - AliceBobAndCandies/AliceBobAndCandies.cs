using System;
using System.Linq;

namespace _1300____D1352___AliceBobAndCandies
{
    class AliceBobAndCandies
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int numberOfCandies = int.Parse(Console.ReadLine());
                var candiesSizeArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                int firstPlayerCurrentEatenCandies = candiesSizeArr[0];
                int firstPlayerTotalEatnCandies = firstPlayerCurrentEatenCandies;
                int secondPlayerCurrentEatenCandies = 0;
                int secondPlayerTotalEatenCandies = 0;

                int totalGameMoves = 1;

                int counterFirstPlayer = 1;
                int counterSecondPlayer = 0;
                bool isFirstPlayerOnTurn = false;

                while (counterFirstPlayer + counterSecondPlayer < numberOfCandies)
                {
                    if (isFirstPlayerOnTurn)
                    {
                        while (secondPlayerCurrentEatenCandies >= firstPlayerCurrentEatenCandies && CheckIfInArrayBorder(counterFirstPlayer, counterSecondPlayer, numberOfCandies))
                        {
                            firstPlayerCurrentEatenCandies += candiesSizeArr[counterFirstPlayer];
                            firstPlayerTotalEatnCandies += candiesSizeArr[counterFirstPlayer];
                            counterFirstPlayer++;
                        }

                        secondPlayerCurrentEatenCandies = 0;
                        isFirstPlayerOnTurn = false;
                    }
                    else
                    {
                        while (firstPlayerCurrentEatenCandies >= secondPlayerCurrentEatenCandies && CheckIfInArrayBorder(counterFirstPlayer, counterSecondPlayer, numberOfCandies))
                        {
                            secondPlayerCurrentEatenCandies += candiesSizeArr[numberOfCandies - 1 - counterSecondPlayer];
                            secondPlayerTotalEatenCandies += candiesSizeArr[numberOfCandies - 1 - counterSecondPlayer];
                            counterSecondPlayer++;
                        }

                        firstPlayerCurrentEatenCandies = 0;
                        isFirstPlayerOnTurn = true;
                    }

                    totalGameMoves++;
                }

                Console.WriteLine($"{totalGameMoves} {firstPlayerTotalEatnCandies} {secondPlayerTotalEatenCandies}");
            }
        }

        private static bool CheckIfInArrayBorder(int counterFirstPlayer, int counterSecondPlayer, int numberOfCandies)
        {
            return counterFirstPlayer + counterSecondPlayer < numberOfCandies;
        }
    }
}
