using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class MeanHeight
    {
        public static void Run()
        {
            Console.Write("Enter each player's height(in cm): ");
            double[] heights = new double[11];
            for(int i = 0; i < 11; i++)
            {
                heights[i] = double.Parse(Console.ReadLine());
            }
            double sum = 0.0;
            for(int i = 0; i < 11; i++)
            {
                sum += heights[i];
            }
            double meanHeight = sum / 11;
            Console.WriteLine("The mean height of the football team is " + meanHeight);
        }
    }
}
