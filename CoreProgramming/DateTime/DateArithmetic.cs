using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAndTime
{
    internal class DateArithmetic
    {
        public static void display()
        {
            Console.Write("Enter day:");
            int day = int.Parse(Console.ReadLine());
            Console.Write("Enter month:");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter year:");
            int year = int.Parse(Console.ReadLine());
            DateTime date = new DateTime(year, month, day);
            DateTime newDate = date.AddDays(7).AddMonths(1).AddYears(2).AddDays(-21);
            Console.WriteLine("New Date: " + newDate.ToShortDateString());
        }
    }
}
