using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateAndTime
{
    internal class DateFormating
    {
        public static void display()
        {
            DateTime today = DateTime.Now;
            Console.WriteLine("dd/MM/yyyy      : " + today.ToString("dd/MM/yyyy"));
            Console.WriteLine("yyyy-MM-dd      : " + today.ToString("yyyy-MM-dd"));
            Console.WriteLine("ddd, MMM dd, yyyy : " + today.ToString("ddd, MMM dd, yyyy"));
        }
    }
}
