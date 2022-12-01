using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1200____EnergyDrinks
{
    internal class EnergyDrinks
    {
        static void Main(string[] args)
        {
            LinkedList<int> list1 = new LinkedList<int>(Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).Select(o => int.Parse(o)));
            LinkedList<int> list2 = new LinkedList<int>(Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None).Select(o => int.Parse(o)));
            int stamatCurrentMG = 0;
            int stamatAllowedMG = 0;

            while (list1.Count != 0 && list2.Count != 0)
            {
                int currentCaffMG = list1.Last();
                int currentDrink = list2.First();
                int res = currentCaffMG * currentDrink;

                if (res + stamatCurrentMG < 300)
                {
                    stamatCurrentMG += res;
                    stamatAllowedMG = 300 - stamatCurrentMG;
                    list1.RemoveLast();
                    list2.RemoveFirst();
                }
                else
                {
                    list1.RemoveLast();
                    list2.AddLast(currentDrink);
                    list2.RemoveFirst();

                    stamatCurrentMG -= 30;
                    if (stamatCurrentMG <= 0)
                    {
                        stamatCurrentMG = 0;
                    }
                }
            }

            if (list2.Count == 0)
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            else
            {
                Console.WriteLine(String.Format("Drinks left: {0}", String.Join(", ", list2)));
            }

            Console.WriteLine(String.Format("Stamat is going to sleep with {0} mg caffeine.", stamatCurrentMG));
        }
    }
}
