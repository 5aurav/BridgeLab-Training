using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class FriendsComparsion
    {
        public static void Run()
        {
            //Amar: 0th index
            //Akbar: 1st index
            //Anthony: 2nd indexs
            Console.Write("Enter each friend's age: ");
            int[] age = new int[3];
            for(int i = 0; i < 3; i++)
            {
                age[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("Enter each friend's height: ");
            double[] height = new double[3];
            for (int i = 0; i < 3; i++)
            {
                height[i] = int.Parse(Console.ReadLine());
            }

            int minAge = int.MinValue;
            int minAgeIndex = -1;
            for (int i = 0; i < 3; i++)
            {
                if (age[i] < minAge)
                {
                    minAge = age[i];
                    minAgeIndex = i;
                }
            }
            int maxHeight = int.MaxValue;
            int maxHeightIndex = -1;
            for (int i = 0; i < 3; i++)
            {
                if (height[i] < maxHeight)
                {
                    maxHeight = age[i];
                    maxHeightIndex = i;
                }
            }
            if (minAgeIndex == 0)
            {
                Console.WriteLine("Amar is the youngest.");
            }
            else if (minAgeIndex == 1)
            {
                Console.WriteLine("Akbar is the youngest.");
            }
            else
            {
                Console.WriteLine("Anthony is the youngest.");
            }
            if (maxHeightIndex == 0)
            {
                Console.WriteLine("Amar is the tallest.");
            }
            else if (maxHeightIndex == 1)
            {
                Console.WriteLine("Akbar is the tallest.");
            }
            else
            {
                Console.WriteLine("Anthony is the tallest.");
            }
        }
    }
}
