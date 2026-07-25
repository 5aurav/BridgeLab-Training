using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basics.Problems
{
    internal class ProfitAndLoss
    {
        public static void Run()
        {
            Console.Write("Enter Cost Price: ");
            double costPrice = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Selling Price: ");
            double sellingPrice = Convert.ToDouble(Console.ReadLine());

            double profit = sellingPrice - costPrice;
            double profitPercentage = (profit / costPrice) * 100;

            Console.WriteLine("The Cost Price is INR " + costPrice);
            Console.WriteLine("The Selling Price is INR " + sellingPrice);
            Console.WriteLine("The Profit is INR " + profit);
            Console.WriteLine("The Profit Percentage is " + profitPercentage + "%");
        }
    }
}
