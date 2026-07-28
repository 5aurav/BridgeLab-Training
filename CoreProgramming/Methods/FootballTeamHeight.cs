using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class FootballTeamHeight
    {
        public static void display()
        {
            int[] heights = GenerateHeights(11);

            Console.WriteLine("Player Heights (cm)");

            for (int i = 0; i < heights.Length; i++)
            {
                Console.WriteLine("Player " + (i + 1) + " : " + heights[i]);
            }

            int sum = FindSum(heights);
            double mean = FindMean(heights);
            int shortest = FindShortest(heights);
            int tallest = FindTallest(heights);

            Console.WriteLine();
            Console.WriteLine("Sum of Heights : " + sum);
            Console.WriteLine("Mean Height : " + Math.Round(mean, 2));
            Console.WriteLine("Shortest Height : " + shortest);
            Console.WriteLine("Tallest Height : " + tallest);
        }

        public static int[] GenerateHeights(int size)
        {
            Random random = new Random();
            int[] heights = new int[size];

            for (int i = 0; i < size; i++)
            {
                heights[i] = random.Next(150, 251);
            }

            return heights;
        }

        public static int FindSum(int[] heights)
        {
            int sum = 0;

            for (int i = 0; i < heights.Length; i++)
            {
                sum += heights[i];
            }

            return sum;
        }

        public static double FindMean(int[] heights)
        {
            return (double)FindSum(heights) / heights.Length;
        }

        public static int FindShortest(int[] heights)
        {
            int shortest = heights[0];

            for (int i = 1; i < heights.Length; i++)
            {
                if (heights[i] < shortest)
                {
                    shortest = heights[i];
                }
            }

            return shortest;
        }

        public static int FindTallest(int[] heights)
        {
            int tallest = heights[0];

            for (int i = 1; i < heights.Length; i++)
            {
                if (heights[i] > tallest)
                {
                    tallest = heights[i];
                }
            }

            return tallest;
        }
    }
}
