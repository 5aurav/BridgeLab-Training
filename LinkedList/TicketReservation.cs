using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class TicketReservation
    {
        class Node
        {
            public int ticketId;
            public string customer;
            public string movie;
            public string seat;
            public string time;

            public Node next;

            public Node(
                int ticketId,
                string customer,
                string movie,
                string seat,
                string time)
            {
                this.ticketId = ticketId;
                this.customer = customer;
                this.movie = movie;
                this.seat = seat;
                this.time = time;
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

            AddTicket(
                101,
                "Amit",
                "Avengers",
                "A1",
                "6:00 PM");

            AddTicket(
                102,
                "Riya",
                "Avengers",
                "A2",
                "6:05 PM");

            AddTicket(
                103,
                "Rahul",
                "Batman",
                "B1",
                "6:10 PM");

            Console.WriteLine("\nTickets:");
            Display();

            Console.WriteLine(
                "\nSearch customer Amit:");

            SearchCustomer("Amit");

            Console.WriteLine(
                "\nSearch movie Avengers:");

            SearchMovie("Avengers");

            Console.WriteLine(
                "\nTotal tickets = " + count);

            Remove(102);

            Console.WriteLine(
                "\nAfter removing ticket 102:");

            Display();

            Console.WriteLine(
                "Total tickets = " + count);
        }

        static void AddTicket(
            int id,
            string customer,
            string movie,
            string seat,
            string time)
        {
            Node n = new Node(
                id,
                customer,
                movie,
                seat,
                time);

            if (head == null)
            {
                head = tail = n;
                n.next = head;
            }
            else
            {
                tail.next = n;
                tail = n;
                tail.next = head;
            }

            count++;
        }

        static void Remove(int id)
        {
            if (head == null)
                return;

            Node temp = head;
            Node prev = tail;

            do
            {
                if (temp.ticketId == id)
                {
                    if (head == tail)
                    {
                        head = tail = null;
                    }
                    else
                    {
                        if (temp == head)
                            head = head.next;

                        if (temp == tail)
                            tail = prev;

                        prev.next = temp.next;
                        tail.next = head;
                    }

                    count--;
                    return;
                }

                prev = temp;
                temp = temp.next;

            } while (temp != head);
        }

        static void SearchCustomer(
            string customer)
        {
            if (head == null)
                return;

            Node temp = head;

            do
            {
                if (temp.customer.Equals(
                    customer,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Print(temp);
                }

                temp = temp.next;

            } while (temp != head);
        }

        static void SearchMovie(
            string movie)
        {
            if (head == null)
                return;

            Node temp = head;

            do
            {
                if (temp.movie.Equals(
                    movie,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Print(temp);
                }

                temp = temp.next;

            } while (temp != head);
        }

        static void Display()
        {
            if (head == null)
                return;

            Node temp = head;

            do
            {
                Print(temp);
                temp = temp.next;

            } while (temp != head);
        }

        static void Print(Node ticket)
        {
            Console.WriteLine(
                "Ticket: " + ticket.ticketId +
                " | Customer: " + ticket.customer +
                " | Movie: " + ticket.movie +
                " | Seat: " + ticket.seat +
                " | Time: " + ticket.time);
        }
    }
}
