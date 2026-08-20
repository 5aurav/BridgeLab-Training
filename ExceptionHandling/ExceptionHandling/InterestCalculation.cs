using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class InterestCalculation
    {
        public static void Run()
        {
            try
            {
                Console.Write("Enter amount: ");
                double amount = double.Parse(Console.ReadLine());

                Console.Write("Enter rate: ");
                double rate = double.Parse(Console.ReadLine());

                Console.Write("Enter years: ");
                int years = int.Parse(Console.ReadLine());

                double interest = CalculateInterest(amount, rate, years);

                Console.WriteLine($"Calculated interest: {interest}");
            }
            catch (ArgumentException)
            {
                Console.WriteLine(
                    "Invalid input: Amount and rate must be positive"
                );
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format");
            }
        }

        private static double CalculateInterest(
            double amount,
            double rate,
            int years)
        {
            if (amount < 0 || rate < 0)
            {
                throw new ArgumentException(
                    "Amount and rate must be positive"
                );
            }

            return amount * rate * years / 100;
        }
    }
}
