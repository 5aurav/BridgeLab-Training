using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBuiltFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NumberGuessingGame.Guess();
            MaximumOfThreeNumbers.findMax();
            PrimeChecker.PrimeCheck();
            FibonacciSequence.display();
            PalindromeChecker.Palindrome();
            RecursiveFactorial.Factorial();
            GCDAndLCM.Calculator();
            TemperatureConvertor.display();
            BasicCalculator.display();
        }
    }
}
