using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections.SystemDesignProblems
{
    public class ShoppingCart
    {
        public static void Run()
        {
            Dictionary<string, double> products = new Dictionary<string, double>();

            List<string> order = new List<string>();

            AddProduct("Laptop", 60000, products, order);
            AddProduct("Mouse", 1000, products, order);
            AddProduct("Keyboard", 2500, products, order);
            AddProduct("Monitor", 15000, products, order);

            Console.WriteLine("Shopping Cart:");

            foreach (string product in order)
                Console.WriteLine($"{product}: {products[product]}");

            SortedDictionary<double, string> sortedByPrice = new SortedDictionary<double, string>();

            foreach (var product in products)
                sortedByPrice[product.Value] = product.Key;

            Console.WriteLine("\nSorted by Price:");

            foreach (var item in sortedByPrice)
                Console.WriteLine($"{item.Value}: {item.Key}");
        }

        private static void AddProduct(
            string name,
            double price,
            Dictionary<string, double> products,
            List<string> order)
        {
            if (!products.ContainsKey(name))
                order.Add(name);

            products[name] = price;
        }
    }
}
