using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class BookDetails
    {
        string title;
        string author;
        double price;

        public BookDetails(string title, string author, double price)
        {
            this.title = title;
            this.author = author;
            this.price = price;
        }

        public void ShowDetails()
        {
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("Price: " + price);
        }

        public static void display()
        {
            BookDetails book = new BookDetails("C# Programming", "John Doe", 499);

            book.ShowDetails();
        }
    }
}
