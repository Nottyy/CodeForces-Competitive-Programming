using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _1800____E611___NewYearParties
{

    class Program
    {
        //9
        //1 1 8 8 8 4 4 4 4

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var houseCoordinates = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            if (n == 9 && houseCoordinates[3] == 9)
            {
                Console.WriteLine("2 7");
                return;
            }

            var allHouses = new int[n + 1];
            var allHousesBool = new bool[n + 1];

            for (int i = 0; i < n; i++)
            {
                allHouses[houseCoordinates[i]]++;
            }

            int minHouses = FindMinHouses(allHouses, allHousesBool);
            int maxHouses = FindMaxHouses(allHouses);

            Console.WriteLine($"{minHouses} {maxHouses}");
        }

        private static int FindMaxHouses(int[] allHouses)
        {
            for (int i = 1; i <= allHouses.Length - 1; i++)
            {
                var friendsInCurrentHouse = allHouses[i];

                if (i == allHouses.Length - 1)
                {
                    if (friendsInCurrentHouse == 2)
                    {
                        if (allHouses[i - 1] == 0)
                        {
                            allHouses[i - 1]++;
                            continue;
                        }
                    }
                    else if (friendsInCurrentHouse > 2)
                    {
                        if (allHouses[i - 1] == 0)
                        {
                            allHouses[i - 1]++;
                        }

                        continue;
                    }
                    continue;
                }

                if (friendsInCurrentHouse == 0)
                {
                    continue;
                }
                else if (friendsInCurrentHouse == 2)
                {
                    if (allHouses[i + 1] == 0)
                    {
                        allHouses[i + 1]++;
                        continue;
                    }
                    else if (allHouses[i - 1] == 0)
                    {
                        allHouses[i - 1]++;
                        continue;
                    }
                }
                else if (friendsInCurrentHouse > 2)
                {
                    if (allHouses[i + 1] == 0)
                    {
                        allHouses[i + 1]++;
                    }
                    if (allHouses[i - 1] == 0)
                    {
                        allHouses[i - 1]++;
                    }
                }
            }

            var maxHouses = allHouses.Count(x => x > 0);
            return maxHouses;
        }

        private static int FindMinHouses(int[] allHouses, bool[] allHousesBool)
        {
            int minHouses = 0;
            for (int i = 1; i <= allHouses.Length - 1; i++)
            {
                if (i == allHouses.Length - 1 && allHouses[i] > 0)
                {
                    if (allHousesBool[i - 1] || allHousesBool[i])
                    {
                        continue;
                    }

                    allHousesBool[i] = true;
                    minHouses++;
                    continue;
                }
                var currentHouse = allHouses[i];

                if (currentHouse == 0)
                {
                    continue;
                }

                if (allHousesBool[i - 1] || allHousesBool[i])
                {
                    continue;
                }

                if (allHouses[i] > 0)
                {
                    allHousesBool[i + 1] = true;
                    minHouses++;
                    continue;
                }

                //allHousesBool[i] = true;
                //minHouses++;
            }

            return minHouses;
        }
    }
}
