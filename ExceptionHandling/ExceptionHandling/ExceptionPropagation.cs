using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class ExceptionPropagation
    {
        public static void Run()
        {
            try
            {
                Method2();
            }
            catch (ArithmeticException)
            {
                Console.WriteLine("Handled exception in Main");
            }
        }

        private static void Method1()
        {
            int numerator = 10;
            int denominator = 0;

            int result = numerator / denominator;
        }

        private static void Method2()
        {
            Method1();
        }
    }
}
