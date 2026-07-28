using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class LeapYearChecker
    {
        public static void display()
        {
            Console.Write("Enter Year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            if (IsLeapYear(year))
            {
                Console.WriteLine(year + " is a Leap Year.");
            }
            else
            {
                Console.WriteLine(year + " is not a Leap Year.");
            }
        }

        public static bool IsLeapYear(int year)
        {
            if (year < 1582)
            {
                return false;
            }

            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
