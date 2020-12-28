using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.DisneylandJourney
{
    class Program
    {
        static void Main(string[] args)
        {
            double journeyCost = double.Parse(Console.ReadLine());
            int input = int.Parse(Console.ReadLine());
            int[] months = new int[input];

            double moneySaved = 2 * journeyCost * 0.25;
            double moneyPerMonth = journeyCost * 0.25;
            for (int i = 2; i < months.Length; i++)
            {
                if (i % 2 == 0)
                {
                    moneySaved = moneySaved * 0.84;
                    moneySaved += moneyPerMonth;
                }
                else
                {
                    moneySaved += moneyPerMonth;
                }

                if (i == 3 || i ==7 || i == 11)
                {
                    moneySaved = (moneySaved-moneyPerMonth) * 1.25;
                    moneySaved += moneyPerMonth;
                }
            }
            if (moneySaved > journeyCost)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {(moneySaved-journeyCost):F2}lv. for souvenirs.");
            }         
            else
            {
                Console.WriteLine($"Sorry. You need {(journeyCost-moneySaved):F2}lv. more.");
            }
        }
    }
}
