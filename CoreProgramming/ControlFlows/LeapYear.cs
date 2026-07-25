using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class LeapYear
    {
        public static void Run()
        {
            Console.Write("Enter Year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            if (year < 1582)
            {
                Console.WriteLine("Enter a valid year.");
            }
            else if (year % 400 == 0)
            {
                Console.WriteLine(year + " is a Leap Year.");
            }
            else if (year % 100 == 0)
            {
                Console.WriteLine(year + " is not a Leap Year.");
            }
            else if (year % 4 == 0)
            {
                Console.WriteLine(year + " is a Leap Year.");
            }
            else
            {
                Console.WriteLine(year + " is not a Leap Year.");
            }

            if (year >= 1582 && (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)))
            {
                Console.WriteLine(year + " is a Leap Year.");
            }
            else
            {
                Console.WriteLine(year + " is not a Leap Year.");
            }
        }
    }
}
