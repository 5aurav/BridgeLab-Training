using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InBuiltFunctions
{
    internal class MaximumOfThreeNumbers
    {
        public static void findMax()
        {
            Console.Write("Enter the first number: ");
            int firstNum = int.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            int secondNum = int.Parse(Console.ReadLine());
            Console.Write("Enter the third number: ");
            int thirdNum = int.Parse(Console.ReadLine());
            int num = MaxOfAllThree(firstNum, secondNum, thirdNum);
            if (num == firstNum)
            {
                Console.WriteLine($"{firstNum} is the largest of the three.");
            }
            else if(num==secondNum)
            {
                Console.WriteLine($"{secondNum} is the largest of the three.");
            }
            else
            {
                Console.WriteLine($"{thirdNum} is the largest of the three.");
            }
        }
        public static int MaxOfAllThree(int first,int second,int third)
        {
            if (first > second)
            {
                if (first > third)
                {
                    return first;
                }
                else
                {
                    return third;
                }
            }
            else
            {
                if (second > third)
                {
                    return second;
                }
                else
                {
                    return third;
                }
            }
        }
    }
}
