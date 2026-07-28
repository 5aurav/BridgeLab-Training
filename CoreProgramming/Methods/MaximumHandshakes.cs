using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class MaximumHandshakes
    {
        public static void display()
        {
            Console.Write("Enter a number: ");
            int num = int.Parse(Console.ReadLine());
            int noOfHandshakes = Handshakes(num);
            Console.WriteLine($"The number of handshakes possible for {num} persons are {noOfHandshakes}");

        }
        public static int Handshakes(int num)
        {
            return (num * (num - 1)) / 2;
        }
    }
}
