using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class MovieManagement
    {
        class Node
        {
            public string title;
            public string director;
            public int year;
            public double rating;

            public Node prev;
            public Node next;

            public Node(
                string title,
                string director,
                int year,
                double rating)
            {
                this.title = title;
                this.director = director;
                this.year = year;
                this.rating = rating;
            }
        }

        static Node head;
        static Node tail;

        public static void Run()
        {
            head = null;
            tail = null;

            AddFirst("Inception", "Nolan", 2010, 8.8);
            AddLast("Interstellar", "Nolan", 2014, 8.7);
            AddFirst("Titanic", "Cameron", 1997, 7.9);
            AddPosition("Avatar", "Cameron", 2009, 7.8, 2);

            Console.WriteLine("\nForward:");
            DisplayForward();

            Console.WriteLine("\nReverse:");
            DisplayReverse();

            Console.WriteLine("\nMovies by Nolan:");
            SearchDirector("Nolan");

            UpdateRating("Avatar", 8.2);

            Console.WriteLine("\nAfter rating update:");
            DisplayForward();

            Remove("Titanic");

            Console.WriteLine("\nAfter removing Titanic:");
            DisplayForward();
        }

        static void AddFirst(
            string title,
            string director,
            int year,
            double rating)
        {
            Node n = new Node(
                title,
                director,
                year,
                rating);

            if (head == null)
            {
                head = tail = n;
                return;
            }

            n.next = head;
            head.prev = n;
            head = n;
        }

        static void AddLast(
            string title,
            string director,
            int year,
            double rating)
        {
            Node n = new Node(
                title,
                director,
                year,
                rating);

            if (head == null)
            {
                head = tail = n;
                return;
            }

            tail.next = n;
            n.prev = tail;
            tail = n;
        }

        static void AddPosition(
            string title,
            string director,
            int year,
            double rating,
            int position)
        {
            if (position == 1)
            {
                AddFirst(title, director, year, rating);
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
                AddLast(title, director, year, rating);
                return;
            }

            Node n = new Node(
                title,
                director,
                year,
                rating);

            n.next = temp.next;
            n.prev = temp;

            temp.next.prev = n;
            temp.next = n;
        }

        static void Remove(string title)
        {
            Node temp = head;

            while (temp != null)
            {
                if (temp.title.Equals(
                    title,
                    StringComparison.OrdinalIgnoreCase))
                {
                    if (temp == head)
                        head = temp.next;

                    if (temp == tail)
                        tail = temp.prev;

                    if (temp.prev != null)
                        temp.prev.next = temp.next;

                    if (temp.next != null)
                        temp.next.prev = temp.prev;

                    return;
                }

                temp = temp.next;
            }
        }

        static void SearchDirector(string director)
        {
            Node temp = head;

            while (temp != null)
            {
                if (temp.director.Equals(
                    director,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Print(temp);
                }

                temp = temp.next;
            }
        }

        static void SearchRating(double rating)
        {
            Node temp = head;

            while (temp != null)
            {
                if (temp.rating == rating)
                    Print(temp);

                temp = temp.next;
            }
        }

        static void UpdateRating(
            string title,
            double rating)
        {
            Node temp = head;

            while (temp != null)
            {
                if (temp.title.Equals(
                    title,
                    StringComparison.OrdinalIgnoreCase))
                {
                    temp.rating = rating;
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

        static void Print(Node movie)
        {
            Console.WriteLine(
                movie.title + " | " +
                movie.director + " | " +
                movie.year + " | " +
                movie.rating);
        }
    }
}
