using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    internal class BookClass
    {
        string title;
        string author;
        double price;

        public BookClass()
        {
            title = "Unknown";
            author = "Unknown";
            price = 0;
        }

        public BookClass(string title, string author, double price)
        {
            this.title = title;
            this.author = author;
            this.price = price;
        }

        public void Display()
        {
            Console.WriteLine("Title : " + title);
            Console.WriteLine("Author : " + author);
            Console.WriteLine("Price : " + price);
        }

        public static void display()
        {
            BookClass b1 = new BookClass();
            BookClass b2 = new BookClass("Rich Dad Poor Dad", "Robert Kiyosaki", 599);

            b1.Display();

            Console.WriteLine();

            b2.Display();
        }
    }
}
