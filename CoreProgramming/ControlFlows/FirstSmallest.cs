using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class FirstSmallest
    {
        public static void Run()
        {
            Console.Write("Enter 3 numbers: ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            if (a < b && a < c)
            {
                Console.WriteLine("Is the first number the smallest: Yes");
            }
            else
            {
                Console.WriteLine("Is the first number the smallest: No");
            }
        }
    }
}
