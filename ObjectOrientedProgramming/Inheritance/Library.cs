using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Book
    {
        public string Title { get; set; }
        public int PublicationYear { get; set; }

        public Book(string title, int publicationYear)
        {
            Title = title;
            PublicationYear = publicationYear;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Title : {Title}");
            Console.WriteLine($"Publication Year : {PublicationYear}");
        }
    }

    class Author : Book
    {
        public string Name { get; set; }
        public string Bio { get; set; }

        public Author(string title, int publicationYear, string name, string bio)
            : base(title, publicationYear)
        {
            Name = name;
            Bio = bio;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Book Details");
            base.DisplayInfo();
            Console.WriteLine($"Author Name : {Name}");
            Console.WriteLine($"Bio : {Bio}");
        }
    }

    internal class LibraryDisplay
    {
        public static void ShowBook()
        {
            Book book = new Author(
                "The Alchemist",
                1988,
                "Paulo Coelho",
                "Brazilian novelist."
            );

            book.DisplayInfo();
        }
    }
}
