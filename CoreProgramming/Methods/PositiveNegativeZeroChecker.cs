using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class PositiveNegativeZeroChecker
    {
        public static void display()
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            if (checker(num) == 0)
            {
                Console.WriteLine("Zero");
            }
            else if (checker(num) == 1)
            {
                Console.WriteLine("Positive");
            }
            else
            {
                Console.WriteLine("Negative");
            }

        }
        public static int checker(int num)
        {
            if (num == 0)
            {
                return 0;
            }
            else if (num > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
