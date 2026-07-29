using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAndTime
{
    internal class DateCommparsion
    {
        public static void display()
        {
            Console.Write("Enter first date (dd/MM/yyyy): ");
            DateTime date1 = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter second date (dd/MM/yyyy): ");
            DateTime date2 = DateTime.Parse(Console.ReadLine());
            int result = DateTime.Compare(date1, date2);
            if (result < 0)
            {
                Console.WriteLine($"{date1} was earlier than {date2}");
            }
            else if (result > 0)
            {
                Console.WriteLine($"{date1} was later than {date2}");
            }
            else
            {
                Console.WriteLine($"{date1} and {date2} are the same dates");
            }
        }
    }
}
