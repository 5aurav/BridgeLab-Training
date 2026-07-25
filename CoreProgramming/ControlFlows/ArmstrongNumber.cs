using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class ArmstrongNumber
    {
        public static void Run()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            int originalNumber = number;
            while (originalNumber > 0)
            {
                int digit = originalNumber % 10;
                sum += (int)Math.Pow(digit, 3);
                originalNumber /= 10;
            }
            if (number == sum)
            {
                Console.WriteLine("Armstrong Number");
            }
            else
            {
                Console.WriteLine("Not a Armstrong Number");
            }
        }
    }
}
