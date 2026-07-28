using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class CalendarDisplay
    {
        public static void display()
        {
            Console.Write("Enter Month (1-12): ");
            int month = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            string monthName = GetMonthName(month);
            int days = GetDaysInMonth(month, year);
            int firstDay = GetFirstDay(month, year);

            Console.WriteLine();
            Console.WriteLine("     " + monthName + " " + year);
            Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

            for (int i = 0; i < firstDay; i++)
            {
                Console.Write("    ");
            }

            for (int day = 1; day <= days; day++)
            {
                Console.Write("{0,3} ", day);

                if ((firstDay + day) % 7 == 0)
                {
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }

        public static string GetMonthName(int month)
        {
            string[] months =
            {
            "January","February","March","April",
            "May","June","July","August",
            "September","October","November","December"
        };

            return months[month - 1];
        }

        public static int GetDaysInMonth(int month, int year)
        {
            int[] days =
            {
            31,28,31,30,31,30,
            31,31,30,31,30,31
        };

            if (month == 2 && IsLeapYear(year))
            {
                return 29;
            }

            return days[month - 1];
        }

        public static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || year % 400 == 0;
        }

        public static int GetFirstDay(int month, int year)
        {
            int d = 1;

            int y0 = year - (14 - month) / 12;
            int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
            int m0 = month + 12 * ((14 - month) / 12) - 2;

            int day = (d + x + (31 * m0) / 12) % 7;

            return day;
        }
    }
}
