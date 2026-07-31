using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    class Book
    {
        public string ISBN;
        protected string title;
        private string author;

        public Book(string ISBN, string title, string author)
        {
            this.ISBN = ISBN;
            this.title = title;
            this.author = author;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public string GetAuthor()
        {
            return author;
        }
    }

    class EBook : Book
    {
        public EBook(string ISBN, string title, string author)
            : base(ISBN, title, author)
        {
        }

        public void Display()
        {
            Console.WriteLine("ISBN   : " + ISBN);
            Console.WriteLine("Title  : " + title);
            Console.WriteLine("Author : " + GetAuthor());
        }
    }

    class BookLibrary
    {
        public static void display()
        {
            EBook book = new EBook("978-0132350884", "Clean Code", "Robert C. Martin");

            Console.WriteLine("Book Details");
            book.Display();

            Console.WriteLine();

            book.SetAuthor("Uncle Bob");

            Console.WriteLine("After Updating Author");
            Console.WriteLine("Author : " + book.GetAuthor());
        }
    }
}
