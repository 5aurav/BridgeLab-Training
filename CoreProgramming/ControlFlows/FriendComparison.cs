using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Flows
{
    internal class FriendComparison
    {
        public static void Run()
        {
            Console.Write("Enter Amar's Age: ");
            int amarAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Amar's Height (in cm): ");
            double amarHeight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Akbar's Age: ");
            int akbarAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Akbar's Height (in cm): ");
            double akbarHeight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Anthony's Age: ");
            int anthonyAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Anthony's Height (in cm): ");
            double anthonyHeight = Convert.ToDouble(Console.ReadLine());

            if (amarAge <= akbarAge && amarAge <= anthonyAge)
            {
                Console.WriteLine("Amar is the Youngest.");
            }
            else if (akbarAge <= amarAge && akbarAge <= anthonyAge)
            {
                Console.WriteLine("Akbar is the Youngest.");
            }
            else
            {
                Console.WriteLine("Anthony is the Youngest.");
            }

            if (amarHeight >= akbarHeight && amarHeight >= anthonyHeight)
            {
                Console.WriteLine("Amar is the Tallest.");
            }
            else if (akbarHeight >= amarHeight && akbarHeight >= anthonyHeight)
            {
                Console.WriteLine("Akbar is the Tallest.");
            }
            else
            {
                Console.WriteLine("Anthony is the Tallest.");
            }
        }
    }
}
