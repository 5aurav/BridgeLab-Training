using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class VoteEligibilty
    {
        public static void Run()
        {
            Console.Write("Enter the age of the person: ");
            int age = int.Parse(Console.ReadLine());
            if (age >= 18)
            {
                Console.WriteLine("The person's age is " + age + " and can vote.");
            }
            else
            {
                Console.WriteLine("The person's age is " + age + " and cannot vote.");
            }
        }
    }
}
