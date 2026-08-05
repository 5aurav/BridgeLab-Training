using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPractice
{
    interface ITaxable
    {
        double CalculateTax();
        void GetTaxDetails();
    }

    abstract class Product
    {
        private int productId;
        private string name;
        private double price;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                    price = value;
            }
        }

        public Product(int productId, string name, double price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }

        public abstract double CalculateDiscount();

        public void DisplayProductDetails()
        {
            Console.WriteLine($"Product ID : {ProductId}");
            Console.WriteLine($"Name       : {Name}");
            Console.WriteLine($"Price      : {Price}");
        }
    }

    class Electronics : Product, ITaxable
    {
        public Electronics(int productId, string name, double price)
            : base(productId, name, price)
        {
        }

        public override double CalculateDiscount()
        {
            return Price * 0.10;
        }

        public double CalculateTax()
        {
            return Price * 0.18;
        }

        public void GetTaxDetails()
        {
            Console.WriteLine($"Tax (18%) : {CalculateTax()}");
        }
    }

    class Clothing : Product, ITaxable
    {
        public Clothing(int productId, string name, double price)
            : base(productId, name, price)
        {
        }

        public override double CalculateDiscount()
        {
            return Price * 0.20;
        }

        public double CalculateTax()
        {
            return Price * 0.12;
        }

        public void GetTaxDetails()
        {
            Console.WriteLine($"Tax (12%) : {CalculateTax()}");
        }
    }

    class Groceries : Product
    {
        public Groceries(int productId, string name, double price)
            : base(productId, name, price)
        {
        }

        public override double CalculateDiscount()
        {
            return Price * 0.05;
        }
    }

    class ECommercePlatform
    {
        public static void Run()
        {
            List<Product> products = new List<Product>();

            products.Add(new Electronics(101, "Laptop", 70000));
            products.Add(new Clothing(102, "Jacket", 2500));
            products.Add(new Groceries(103, "Rice Bag", 1200));

            foreach (Product product in products)
            {
                product.DisplayProductDetails();

                double tax = 0;

                if (product is ITaxable taxable)
                {
                    tax = taxable.CalculateTax();
                    taxable.GetTaxDetails();
                }
                else
                {
                    Console.WriteLine("Tax : Not Applicable");
                }

                double discount = product.CalculateDiscount();

                Console.WriteLine($"Discount : {discount}");
                Console.WriteLine($"Final Price : {product.Price + tax - discount}");
                Console.WriteLine();
            }
        }
    }
}
