using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPKeywords
{
    internal class LibraryManagementSystem
    {
        public string Title;
        public string Author;
        public readonly string ISBN;

        static string LibraryName = "Central Library";

        public LibraryManagementSystem(string Title, string Author, string ISBN)
        {
            this.Title = Title;
            this.Author = Author;
            this.ISBN = ISBN;
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Library Name : " + LibraryName);
            Console.WriteLine("Title        : " + Title);
            Console.WriteLine("Author       : " + Author);
            Console.WriteLine("ISBN         : " + ISBN);
        }

        public static void DisplayLibraryName()
        {
            Console.WriteLine("Library Name : " + LibraryName);
        }

        public static void display()
        {
            LibraryManagementSystem book1 =
                new LibraryManagementSystem("Clean Code", "Robert C. Martin", "9780132350884");

            LibraryManagementSystem book2 =
                new LibraryManagementSystem("Atomic Habits", "James Clear", "9781847941831");

            DisplayLibraryName();

            Console.WriteLine();

            if (book1 is LibraryManagementSystem)
            {
                Console.WriteLine("Book 1 Details");
                book1.DisplayDetails();
            }

            Console.WriteLine();

            if (book2 is LibraryManagementSystem)
            {
                Console.WriteLine("Book 2 Details");
                book2.DisplayDetails();
            }
        }
    }
}
