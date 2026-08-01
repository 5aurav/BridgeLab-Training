using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPKeywords
{
    internal class ShoppingCartSystem
    {
        public string ProductName;
        public readonly int ProductID;
        public double Price;
        public int Quantity;

        static double Discount = 10;

        public ShoppingCartSystem(string ProductName, int ProductID, double Price, int Quantity)
        {
            this.ProductName = ProductName;
            this.ProductID = ProductID;
            this.Price = Price;
            this.Quantity = Quantity;
        }

        public double CalculateTotal()
        {
            double total = Price * Quantity;
            return total - (total * Discount / 100);
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Product ID   : " + ProductID);
            Console.WriteLine("Product Name : " + ProductName);
            Console.WriteLine("Price        : " + Price);
            Console.WriteLine("Quantity     : " + Quantity);
            Console.WriteLine("Discount     : " + Discount + "%");
            Console.WriteLine("Total Amount : " + CalculateTotal());
        }

        public static void UpdateDiscount(double discount)
        {
            Discount = discount;
        }

        public static void display()
        {
            ShoppingCartSystem p1 = new ShoppingCartSystem("Laptop", 101, 65000, 1);
            ShoppingCartSystem p2 = new ShoppingCartSystem("Mouse", 102, 1200, 2);

            Console.WriteLine("Before Updating Discount");

            Console.WriteLine();

            if (p1 is ShoppingCartSystem)
            {
                p1.DisplayDetails();
            }

            Console.WriteLine();

            if (p2 is ShoppingCartSystem)
            {
                p2.DisplayDetails();
            }

            Console.WriteLine();

            UpdateDiscount(20);

            Console.WriteLine("After Updating Discount");

            Console.WriteLine();

            p1.DisplayDetails();

            Console.WriteLine();

            p2.DisplayDetails();
        }
    }
}
