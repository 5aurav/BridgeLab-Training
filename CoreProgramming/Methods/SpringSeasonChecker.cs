using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class SpringSeasonChecker
    {
        public static void display()
        {
            Console.Write("Enter a month: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter a date: ");
            int date = int.Parse(Console.ReadLine());
            if (SpringSeason(month,date))
            {
                Console.WriteLine("Its a Spring Season.");
            }
            else
            {
                Console.WriteLine("Not a Spring Season.");
            }
        }
        public static bool SpringSeason(int month,int date)
        {
            if (month == 3 && date >= 20 || month == 4 || month == 5 || month == 6 && date <= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
