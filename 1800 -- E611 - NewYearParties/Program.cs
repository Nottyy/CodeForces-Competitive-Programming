using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;

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
            var arr = new bool[allHouses.Length + 1];
            var maxHouses = 0;
            var h = 1;
            do
            {
                var currentHouse = allHouses[h];

                if (currentHouse == 1)
                {
                    if (arr[h - 1] == false)
                    {
                        arr[h - 1] = true;
                        maxHouses++;
                    }
                    else if (arr[h] == true)
                    {
                        arr[h + 1] = true;
                        maxHouses++;
                    }
                    else if (arr[h] == false)
                    {
                        arr[h] = true;
                        maxHouses++;
                    }
                }
                else if (currentHouse == 2)
                {
                    if (arr[h - 1] == false)
                    {
                        arr[h - 1] = true;
                        arr[h] = true;
                        maxHouses += 2;
                    }
                    else if (arr[h] == true)
                    {
                        arr[h + 1] = true;
                        maxHouses += 1;
                    }
                    else if (arr[h] == false)
                    {
                        arr[h] = true;
                        arr[h + 1] = true;
                        maxHouses += 2;
                    }
                }
                else if(currentHouse > 2)
                {
                    maxHouses += arr[h - 1] == false ? 3 : (arr[h] == true ? 1 : 2);

                    arr[h - 1] = true;
                    arr[h] = true;
                    arr[h + 1] = true;
                }

                h++;
            }
            while (h <= allHouses.Length - 1);

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
            }

            return minHouses;
        }
    }
}
