using System;
using System.Collections.Generic;

namespace Generics
{
    abstract class WarehouseItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public WarehouseItem(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public abstract void Display();
    }

    class Electronics : WarehouseItem
    {
        public Electronics(int id, string name) : base(id, name) { }

        public override void Display()
        {
            Console.WriteLine($"Electronics: {Id} - {Name}");
        }
    }

    class Grocery : WarehouseItem
    {
        public Grocery(int id, string name) : base(id, name) { }

        public override void Display()
        {
            Console.WriteLine($"Grocery: {Id} - {Name}");
        }
    }

    class Furniture : WarehouseItem
    {
        public Furniture(int id, string name) : base(id, name) { }

        public override void Display()
        {
            Console.WriteLine($"Furniture: {Id} - {Name}");
        }
    }

    class Storage<T> where T : WarehouseItem
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Display()
        {
            foreach (T item in items)
                item.Display();
        }
    }

    public class SmartWarehouseManagement
    {
        public static void Run()
        {
            Storage<Electronics> electronics =
                new Storage<Electronics>();

            Storage<Grocery> groceries =
                new Storage<Grocery>();

            Storage<Furniture> furniture =
                new Storage<Furniture>();

            electronics.Add(new Electronics(1, "Laptop"));
            electronics.Add(new Electronics(2, "Mobile"));

            groceries.Add(new Grocery(3, "Rice"));

            furniture.Add(new Furniture(4, "Table"));

            Console.WriteLine("Electronics:");
            electronics.Display();

            Console.WriteLine("\nGroceries:");
            groceries.Display();

            Console.WriteLine("\nFurniture:");
            furniture.Display();
        }
    }
}