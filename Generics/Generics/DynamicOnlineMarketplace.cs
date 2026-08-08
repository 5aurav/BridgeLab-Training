using System;

namespace Generics
{
    abstract class Category
    {
        public string Name { get; set; }

        public Category(string name)
        {
            Name = name;
        }
    }

    class BookCategory : Category
    {
        public BookCategory() : base("Book") { }
    }

    class ClothingCategory : Category
    {
        public ClothingCategory() : base("Clothing") { }
    }

    abstract class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public abstract void Display();
    }

    class Product<T> : Product where T : Category
    {
        public T Category { get; set; }

        public Product(string name, double price, T category)
            : base(name, price)
        {
            Category = category;
        }

        public override void Display()
        {
            Console.WriteLine(
                $"{Name} - {Price} - {Category.Name}");
        }
    }

    class Marketplace
    {
        public void ApplyDiscount<T>(
            T product,
            double percentage)
            where T : Product
        {
            product.Price -= product.Price * percentage / 100;
        }
    }

    public class DynamicOnlineMarketplace
    {
        public static void Run()
        {
            Product<BookCategory> book =
                new Product<BookCategory>(
                    "Clean Code",
                    800,
                    new BookCategory());

            Product<ClothingCategory> shirt =
                new Product<ClothingCategory>(
                    "T-Shirt",
                    1000,
                    new ClothingCategory());

            Marketplace marketplace =
                new Marketplace();

            marketplace.ApplyDiscount(book, 10);
            marketplace.ApplyDiscount(shirt, 20);

            book.Display();
            shirt.Display();
        }
    }
}