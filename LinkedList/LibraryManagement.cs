using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class LibraryManagement
    {
        class Node
        {
            public int id;
            public string title;
            public string author;
            public string genre;
            public bool available;

            public Node prev;
            public Node next;

            public Node(
                int id,
                string title,
                string author,
                string genre,
                bool available)
            {
                this.id = id;
                this.title = title;
                this.author = author;
                this.genre = genre;
                this.available = available;
            }
        }

        static Node head;
        static Node tail;
        static int count;

        public static void Run()
        {
            head = null;
            tail = null;
            count = 0;

            AddLast(
                101,
                "Clean Code",
                "Robert Martin",
                "Programming",
                true);

            AddLast(
                102,
                "1984",
                "George Orwell",
                "Fiction",
                false);

            AddFirst(
                103,
                "Atomic Habits",
                "James Clear",
                "Self Help",
                true);

            AddPosition(
                104,
                "The Hobbit",
                "Tolkien",
                "Fantasy",
                true,
                2);

            Console.WriteLine("\nBooks:");
            DisplayForward();

            Console.WriteLine("\nReverse:");
            DisplayReverse();

            Console.WriteLine("\nSearch by author:");
            SearchAuthor("George Orwell");

            UpdateStatus(102, true);

            Console.WriteLine("\nAfter updating status:");
            DisplayForward();

            Console.WriteLine(
                "\nTotal books = " + count);
        }

        static void AddFirst(
            int id,
            string title,
            string author,
            string genre,
            bool available)
        {
            Node n = new Node(
                id,
                title,
                author,
                genre,
                available);

            if (head == null)
            {
                head = tail = n;
            }
            else
            {
                n.next = head;
                head.prev = n;
                head = n;
            }

            count++;
        }

        static void AddLast(
            int id,
            string title,
            string author,
            string genre,
            bool available)
        {
            Node n = new Node(
                id,
                title,
                author,
                genre,
                available);

            if (head == null)
            {
                head = tail = n;
            }
            else
            {
                tail.next = n;
                n.prev = tail;
                tail = n;
            }

            count++;
        }

        static void AddPosition(
            int id,
            string title,
            string author,
            string genre,
            bool available,
            int position)
        {
            if (position == 1)
            {
                AddFirst(
                    id,
                    title,
                    author,
                    genre,
                    available);

                return;
            }

            Node temp = head;

            for (int i = 1; i < position - 1; i++)
            {
                if (temp == null)
                    return;

                temp = temp.next;
            }

            if (temp == null)
                return;

            if (temp == tail)
            {
                AddLast(
                    id,
                    title,
                    author,
                    genre,
                    available);

                return;
            }

            Node n = new Node(
                id,
                title,
                author,
                genre,
                available);

            n.next = temp.next;
            n.prev = temp;

            temp.next.prev = n;
            temp.next = n;

            count++;
        }

        static void Remove(int id)
        {
            Node temp = head;

            while (temp != null)
            {
                if (temp.id == id)
                {
                    if (temp == head)
                        head = temp.next;

                    if (temp == tail)
                        tail = temp.prev;

                    if (temp.prev != null)
                        temp.prev.next = temp.next;

                    if (temp.next != null)
                        temp.next.prev = temp.prev;

                    count--;
                    return;
                }

                temp = temp.next;
            }
        }

        static void SearchTitle(string title)
        {
            Node temp = head;

            while (temp != null)
            {
                if (temp.title.Equals(
                    title,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Print(temp);
                }

                temp = temp.next;
            }
        }

        static void SearchAuthor(string author)
        {
            Node temp = head;

            while (temp != null)
            {
                if (temp.author.Equals(
                    author,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Print(temp);
                }

                temp = temp.next;
            }
        }

        static void UpdateStatus(
            int id,
            bool status)
        {
            Node temp = head;

            while (temp != null)
            {
                if (temp.id == id)
                {
                    temp.available = status;
                    return;
                }

                temp = temp.next;
            }
        }

        static void DisplayForward()
        {
            Node temp = head;

            while (temp != null)
            {
                Print(temp);
                temp = temp.next;
            }
        }

        static void DisplayReverse()
        {
            Node temp = tail;

            while (temp != null)
            {
                Print(temp);
                temp = temp.prev;
            }
        }

        static void Print(Node book)
        {
            Console.WriteLine(
                book.id + " | " +
                book.title + " | " +
                book.author + " | " +
                book.genre + " | " +
                (book.available ? "Available" : "Not Available"));
        }
    }
}
