using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class LargestOfTheThree
    {
        public static void Run()
        {
            Console.Write("Enter 3 numbers: ");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            if (a > b)
            {
                if (a > c)
                {
                    Console.WriteLine("Is the first number the largest? Yes\nIs the second number the largest? No\nIs the third number the largest? No");
                }
                else
                {
                    Console.WriteLine("Is the first number the largest? No\nIs the second number the largest? No\nIs the third number the largest? Yes");
                }
            }
            else
            {
                if (b > c)
                {
                    Console.WriteLine("Is the first number the largest? No\nIs the second number the largest? Yes\nIs the third number the largest? No");
                }
                else
                {
                    Console.WriteLine("Is the first number the largest? No\nIs the second number the largest? No\nIs the third number the largest? Yes");
                }
            }
        }
    }
}
