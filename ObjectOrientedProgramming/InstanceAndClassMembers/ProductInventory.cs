using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstanceAndClassMembers
{
    internal class ProductInventory
    {
        string productName;
        double price;

        static int totalProducts = 0;

        public ProductInventory(string productName, double price)
        {
            this.productName = productName;
            this.price = price;

            totalProducts++;
        }

        public void DisplayProductDetails()
        {
            Console.WriteLine("Product Name : " + productName);
            Console.WriteLine("Price        : " + price);
        }

        public static void DisplayTotalProducts()
        {
            Console.WriteLine("Total Products : " + totalProducts);
        }

        public static void display()
        {
            ProductInventory p1 = new ProductInventory("Laptop", 65000);
            ProductInventory p2 = new ProductInventory("Mouse", 1200);
            ProductInventory p3 = new ProductInventory("Keyboard", 2500);

            p1.DisplayProductDetails();

            Console.WriteLine();

            p2.DisplayProductDetails();

            Console.WriteLine();

            p3.DisplayProductDetails();

            Console.WriteLine();

            ProductInventory.DisplayTotalProducts();
        }
    }
}
