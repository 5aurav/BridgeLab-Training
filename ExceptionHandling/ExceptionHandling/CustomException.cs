using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class CustomException
    {
        public static void Run()
        {
            try
            {
                Console.Write("Enter age: ");
                int age = int.Parse(Console.ReadLine());

                ValidateAge(age);

                Console.WriteLine("Access granted!");
            }
            catch (InvalidAgeException)
            {
                Console.WriteLine("Age must be 18 or above");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid age format");
            }
        }

        private static void ValidateAge(int age)
        {
            if (age < 18)
            {
                throw new InvalidAgeException("Age must be 18 or above");
            }
        }
    }
}
