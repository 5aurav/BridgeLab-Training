using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class CountDigits
    {
        public static void Run()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            int digits = 0;
            int num = number;
            while (num > 0)
            {
                num /= 10;
                digits++;
            }
            Console.WriteLine("There are " + digits + " in " + number);
        }
    }
}
