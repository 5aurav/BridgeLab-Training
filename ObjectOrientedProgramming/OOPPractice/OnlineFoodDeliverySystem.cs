using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPractice
{
    interface IDiscountable
    {
        double ApplyDiscount();
        void GetDiscountDetails();
    }

    abstract class FoodItem
    {
        private string itemName;
        private double price;
        private int quantity;

        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public FoodItem(string itemName, double price, int quantity)
        {
            ItemName = itemName;
            Price = price;
            Quantity = quantity;
        }

        public abstract double CalculateTotalPrice();

        public void GetItemDetails()
        {
            Console.WriteLine($"Item Name : {ItemName}");
            Console.WriteLine($"Price     : {Price}");
            Console.WriteLine($"Quantity  : {Quantity}");
        }
    }

    class VegItem : FoodItem, IDiscountable
    {
        public VegItem(string itemName, double price, int quantity)
            : base(itemName, price, quantity)
        {
        }

        public override double CalculateTotalPrice()
        {
            return (Price * Quantity) + 20;
        }

        public double ApplyDiscount()
        {
            return CalculateTotalPrice() * 0.10;
        }

        public void GetDiscountDetails()
        {
            Console.WriteLine($"Discount : {ApplyDiscount()}");
        }
    }

    class NonVegItem : FoodItem, IDiscountable
    {
        public NonVegItem(string itemName, double price, int quantity)
            : base(itemName, price, quantity)
        {
        }

        public override double CalculateTotalPrice()
        {
            return (Price * Quantity) + 50;
        }

        public double ApplyDiscount()
        {
            return CalculateTotalPrice() * 0.05;
        }

        public void GetDiscountDetails()
        {
            Console.WriteLine($"Discount : {ApplyDiscount()}");
        }
    }

    class OnlineFoodDeliverySystem
    {
        public static void Run()
        {
            List<FoodItem> foodItems = new List<FoodItem>();

            foodItems.Add(new VegItem("Paneer Tikka", 250, 2));
            foodItems.Add(new NonVegItem("Chicken Biryani", 350, 1));

            foreach (FoodItem item in foodItems)
            {
                item.GetItemDetails();

                double totalPrice = item.CalculateTotalPrice();
                Console.WriteLine($"Total Price : {totalPrice}");

                if (item is IDiscountable discountable)
                {
                    discountable.GetDiscountDetails();

                    double finalPrice = totalPrice - discountable.ApplyDiscount();
                    Console.WriteLine($"Final Price : {finalPrice}");
                }

                Console.WriteLine();
            }
        }
    }
}
