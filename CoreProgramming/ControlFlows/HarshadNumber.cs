using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class HarshadNumber
    {
        public static void Run()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            int num = number;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            if (number % sum == 0)
            {
                Console.WriteLine("Harshad Number");
            }
            else
            {
                Console.WriteLine("Not a Harshad Number");
            }
        }
    }
}
