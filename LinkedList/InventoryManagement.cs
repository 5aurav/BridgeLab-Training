using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class InventoryManagement
    {
        class Node
        {
            public int id;
            public string name;
            public int quantity;
            public double price;
            public Node next;

            public Node(
                int id,
                string name,
                int quantity,
                double price)
            {
                this.id = id;
                this.name = name;
                this.quantity = quantity;
                this.price = price;
            }
        }

        static Node head;

        public static void Run()
        {
            head = null;

            AddLast(1, "Laptop", 5, 60000);
            AddLast(2, "Mouse", 20, 800);
            AddFirst(3, "Keyboard", 10, 1500);
            AddPosition(4, "Monitor", 7, 12000, 2);

            Console.WriteLine("\nInventory:");
            Display();

            UpdateQuantity(2, 25);

            Console.WriteLine("\nAfter quantity update:");
            Display();

            Console.WriteLine(
                "\nTotal value = " + TotalValue());

            Console.WriteLine("\nSearch item ID 1:");
            SearchId(1);

            Console.WriteLine("\nSearch item Mouse:");
            SearchName("Mouse");

            Console.WriteLine("\nSorted by price:");
            SortPrice(true);
            Display();
        }

        static void AddFirst(
            int id,
            string name,
            int quantity,
            double price)
        {
            Node n = new Node(
                id,
                name,
                quantity,
                price);

            n.next = head;
            head = n;
        }

        static void AddLast(
            int id,
            string name,
            int quantity,
            double price)
        {
            Node n = new Node(
                id,
                name,
                quantity,
                price);

            if (head == null)
            {
                head = n;
                return;
            }

            Node temp = head;

            while (temp.next != null)
                temp = temp.next;

            temp.next = n;
        }

        static void AddPosition(
            int id,
            string name,
            int quantity,
            double price,
            int position)
        {
            if (position == 1)
            {
                AddFirst(id, name, quantity, price);
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

            Node n = new Node(
                id,
                name,
                quantity,
                price);

            n.next = temp.next;
            temp.next = n;
        }

        static void Remove(int id)
        {
            if (head == null)
                return;

            if (head.id == id)
            {
                head = head.next;
                return;
            }

            Node temp = head;

            while (temp.next != null)
            {
                if (temp.next.id == id)
                {
                    temp.next = temp.next.next;
                    return;
                }

                temp = temp.next;
            }
        }

        static void UpdateQuantity(
            int id,
            int quantity)
        {
            Node temp = head;

            while (temp != null)
            {
                if (temp.id == id)
                {
                    temp.quantity = quantity;
                    return;
                }

                temp = temp.next;
            }
        }

        static void SearchId(int id)
        {
            Node temp = head;

            while (temp != null)
            {
                if (temp.id == id)
                {
                    Print(temp);
                    return;
                }

                temp = temp.next;
            }
        }

        static void SearchName(string name)
        {
            Node temp = head;

            while (temp != null)
            {
                if (temp.name.Equals(
                    name,
                    StringComparison.OrdinalIgnoreCase))
                {
                    Print(temp);
                }

                temp = temp.next;
            }
        }

        static double TotalValue()
        {
            double total = 0;

            Node temp = head;

            while (temp != null)
            {
                total += temp.price * temp.quantity;
                temp = temp.next;
            }

            return total;
        }

        static void SortPrice(bool ascending)
        {
            Node i = head;

            while (i != null)
            {
                Node j = i.next;

                while (j != null)
                {
                    if (ascending && i.price > j.price)
                        Swap(i, j);

                    if (!ascending && i.price < j.price)
                        Swap(i, j);

                    j = j.next;
                }

                i = i.next;
            }
        }

        static void SortName(bool ascending)
        {
            Node i = head;

            while (i != null)
            {
                Node j = i.next;

                while (j != null)
                {
                    int result = string.Compare(
                        i.name,
                        j.name,
                        StringComparison.OrdinalIgnoreCase);

                    if (ascending && result > 0)
                        Swap(i, j);

                    if (!ascending && result < 0)
                        Swap(i, j);

                    j = j.next;
                }

                i = i.next;
            }
        }

        static void Swap(Node a, Node b)
        {
            int id = a.id;
            a.id = b.id;
            b.id = id;

            string name = a.name;
            a.name = b.name;
            b.name = name;

            int quantity = a.quantity;
            a.quantity = b.quantity;
            b.quantity = quantity;

            double price = a.price;
            a.price = b.price;
            b.price = price;
        }

        static void Display()
        {
            Node temp = head;

            while (temp != null)
            {
                Print(temp);
                temp = temp.next;
            }
        }

        static void Print(Node item)
        {
            Console.WriteLine(
                item.id + " | " +
                item.name + " | Qty: " +
                item.quantity + " | Price: " +
                item.price);
        }
    }
}
