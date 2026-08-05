using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPractice
{
    interface IReservable
    {
        void ReserveItem();
        bool CheckAvailability();
    }

    abstract class LibraryItem
    {
        private int itemId;
        private string title;
        private string author;
        private string borrowerName;

        public int ItemId
        {
            get { return itemId; }
            set { itemId = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string BorrowerName
        {
            get { return borrowerName; }
            private set { borrowerName = value; }
        }

        public LibraryItem(int itemId, string title, string author, string borrowerName)
        {
            ItemId = itemId;
            Title = title;
            Author = author;
            BorrowerName = borrowerName;
        }

        public abstract int GetLoanDuration();

        public void GetItemDetails()
        {
            Console.WriteLine($"Item ID : {ItemId}");
            Console.WriteLine($"Title   : {Title}");
            Console.WriteLine($"Author  : {Author}");
        }
    }

    class Book : LibraryItem, IReservable
    {
        private bool available = true;

        public Book(int itemId, string title, string author, string borrowerName)
            : base(itemId, title, author, borrowerName)
        {
        }

        public override int GetLoanDuration()
        {
            return 14;
        }

        public void ReserveItem()
        {
            available = false;
            Console.WriteLine("Book Reserved");
        }

        public bool CheckAvailability()
        {
            return available;
        }
    }

    class Magazine : LibraryItem, IReservable
    {
        private bool available = true;

        public Magazine(int itemId, string title, string author, string borrowerName)
            : base(itemId, title, author, borrowerName)
        {
        }

        public override int GetLoanDuration()
        {
            return 7;
        }

        public void ReserveItem()
        {
            available = false;
            Console.WriteLine("Magazine Reserved");
        }

        public bool CheckAvailability()
        {
            return available;
        }
    }

    class DVD : LibraryItem, IReservable
    {
        private bool available = true;

        public DVD(int itemId, string title, string author, string borrowerName)
            : base(itemId, title, author, borrowerName)
        {
        }

        public override int GetLoanDuration()
        {
            return 3;
        }

        public void ReserveItem()
        {
            available = false;
            Console.WriteLine("DVD Reserved");
        }

        public bool CheckAvailability()
        {
            return available;
        }
    }

    class LibraryManagementSystem
    {
        public static void Run()
        {
            List<LibraryItem> items = new List<LibraryItem>();

            items.Add(new Book(101, "C# Programming", "John", "Rahul"));
            items.Add(new Magazine(102, "Tech Monthly", "David", "Priya"));
            items.Add(new DVD(103, "Avengers", "Marvel", "Amit"));

            foreach (LibraryItem item in items)
            {
                item.GetItemDetails();

                Console.WriteLine($"Loan Duration : {item.GetLoanDuration()} days");

                if (item is IReservable reservable)
                {
                    Console.WriteLine($"Available : {reservable.CheckAvailability()}");
                    reservable.ReserveItem();
                    Console.WriteLine($"Available : {reservable.CheckAvailability()}");
                }

                Console.WriteLine();
            }
        }
    }
}
