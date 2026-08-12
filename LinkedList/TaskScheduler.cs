using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class TaskScheduler
    {
        class Node
        {
            public int id;
            public string name;
            public int priority;
            public string dueDate;
            public Node next;

            public Node(
                int id,
                string name,
                int priority,
                string dueDate)
            {
                this.id = id;
                this.name = name;
                this.priority = priority;
                this.dueDate = dueDate;
            }
        }

        static Node head;
        static Node tail;
        static Node current;

        public static void Run()
        {
            head = null;
            tail = null;
            current = null;

            AddLast(1, "Study", 2, "13-08-2026");
            AddLast(2, "Meeting", 1, "14-08-2026");
            AddFirst(3, "Project", 3, "15-08-2026");
            AddPosition(4, "Assignment", 2, "16-08-2026", 2);

            Console.WriteLine("\nTasks:");
            Display();

            Console.WriteLine("\nCurrent task:");
            Print(current);

            MoveNext();

            Console.WriteLine("\nAfter moving next:");
            Print(current);

            Console.WriteLine("\nPriority 2 tasks:");
            SearchPriority(2);

            Remove(2);

            Console.WriteLine("\nAfter deleting task 2:");
            Display();
        }

        static void AddFirst(
            int id,
            string name,
            int priority,
            string date)
        {
            Node n = new Node(
                id,
                name,
                priority,
                date);

            if (head == null)
            {
                head = tail = n;
                n.next = n;
                current = head;
                return;
            }

            n.next = head;
            head = n;
            tail.next = head;
        }

        static void AddLast(
            int id,
            string name,
            int priority,
            string date)
        {
            Node n = new Node(
                id,
                name,
                priority,
                date);

            if (head == null)
            {
                head = tail = n;
                n.next = n;
                current = head;
                return;
            }

            tail.next = n;
            tail = n;
            tail.next = head;
        }

        static void AddPosition(
            int id,
            string name,
            int priority,
            string date,
            int position)
        {
            if (position == 1)
            {
                AddFirst(id, name, priority, date);
                return;
            }

            Node temp = head;

            for (int i = 1; i < position - 1; i++)
                temp = temp.next;

            Node n = new Node(
                id,
                name,
                priority,
                date);

            n.next = temp.next;
            temp.next = n;

            if (temp == tail)
            {
                tail = n;
                tail.next = head;
            }
        }

        static void Remove(int id)
        {
            if (head == null)
                return;

            Node temp = head;
            Node prev = tail;

            do
            {
                if (temp.id == id)
                {
                    if (head == tail)
                    {
                        head = tail = current = null;
                        return;
                    }

                    if (temp == head)
                        head = head.next;

                    if (temp == tail)
                        tail = prev;

                    prev.next = temp.next;
                    tail.next = head;

                    if (current == temp)
                        current = temp.next;

                    return;
                }

                prev = temp;
                temp = temp.next;

            } while (temp != head);
        }

        static void MoveNext()
        {
            if (current != null)
                current = current.next;
        }

        static void SearchPriority(int priority)
        {
            if (head == null)
                return;

            Node temp = head;

            do
            {
                if (temp.priority == priority)
                    Print(temp);

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

        static void Print(Node n)
        {
            Console.WriteLine(
                n.id + " | " +
                n.name + " | Priority: " +
                n.priority + " | Due: " +
                n.dueDate);
        }
    }
}
