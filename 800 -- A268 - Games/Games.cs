using System;

namespace _800____A268___Games
{
    public class Team
    {
        public Team(int home, int away)
        {
            Home = home;
            Away = away;
        }

        public int Home { get; set; }
        public int Away { get; set; }
    }
    class Games
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var teams = new Team[n];

            for (int i = 0; i < n; i++)
            {
                var teamColorsLine = Console.ReadLine().Split(' ');
                var colorHome = int.Parse(teamColorsLine[0]);
                var colorAway = int.Parse(teamColorsLine[1]);

                var team = new Team(colorHome, colorAway);
                teams[i] = team;
            }

            int counter = 0;

            for (int i = 0; i < teams.Length; i++)
            {
                for (int j = 0; j < teams.Length; j++)
                {
                    if (teams[i].Home == teams[j].Away && i != j)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
