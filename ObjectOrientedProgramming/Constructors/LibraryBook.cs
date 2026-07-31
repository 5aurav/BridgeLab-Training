using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    internal class BookLibrary
    {
        string title;
        string author;
        double price;
        bool availability;

        public BookLibrary()
        {
            title = "Unknown";
            author = "Unknown";
            price = 0;
            availability = true;
        }

        public BookLibrary(string title, string author, double price, bool availability)
        {
            this.title = title;
            this.author = author;
            this.price = price;
            this.availability = availability;
        }

        public void BorrowBook()
        {
            if (availability)
            {
                availability = false;
                Console.WriteLine("Book borrowed successfully.");
            }
            else
            {
                Console.WriteLine("Book is not available.");
            }
        }

        public void Display()
        {
            Console.WriteLine("Title        : " + title);
            Console.WriteLine("Author       : " + author);
            Console.WriteLine("Price        : " + price);
            Console.WriteLine("Availability : " + availability);
        }

        public static void display()
        {
            BookLibrary b = new BookLibrary("Atomic Habits", "James Clear", 799, true);

            Console.WriteLine("Before Borrowing");
            b.Display();

            Console.WriteLine();

            b.BorrowBook();

            Console.WriteLine();

            Console.WriteLine("After Borrowing");
            b.Display();
        }
    }
}
