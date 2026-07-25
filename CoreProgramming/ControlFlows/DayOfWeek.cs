using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class DayOfWeek
    {
        public static void Run()
        {
            Console.Write("Enter a month: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter a day: ");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Enter a year: ");
            int year = int.Parse(Console.ReadLine());
            int y1 = year - (14 - month) / 12;
            int x = y1 + y1 / 4 - y1 / 100 + y1 / 400;
            int m1 = month + 12 * ((14 - month) / 12) - 2;
            int d1 = (day + x + 31 * m1 / 12) % 7;
            switch (d1)
            {
                case 0:
                    Console.WriteLine("It is Sunday");
                    break;

                case 1:
                    Console.WriteLine("It is Monday");
                    break;

                case 2:
                    Console.WriteLine("It is Tuesday");
                    break;

                case 3:
                    Console.WriteLine("It is Wednesday");
                    break;

                case 4:
                    Console.WriteLine("It is Thursday");
                    break;

                case 5:
                    Console.WriteLine("It is Friday");
                    break;

                case 6:
                    Console.WriteLine("It is Saturday");
                    break;

                default:
                    Console.WriteLine("Wrong output");
                    break;
            }
        }
    }
}
