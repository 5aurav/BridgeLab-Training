using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class StudentRecords
    {
        class Node
        {
            public int roll;
            public string name;
            public int age;
            public string grade;
            public Node next;

            public Node(int roll, string name, int age, string grade)
            {
                this.roll = roll;
                this.name = name;
                this.age = age;
                this.grade = grade;
            }
        }

        static Node head;

        public static void Run()
        {
            head = null;

            AddFirst(1, "Amit", 20, "A");
            AddLast(2, "Riya", 21, "B");
            AddFirst(3, "Rahul", 20, "A+");
            AddPosition(4, "Neha", 22, "B+", 2);

            Console.WriteLine("\nStudents:");
            Display();

            Console.WriteLine("\nSearching roll 2:");
            Search(2);

            UpdateGrade(2, "A+");

            Console.WriteLine("\nAfter updating grade:");
            Display();

            Delete(3);

            Console.WriteLine("\nAfter deleting roll 3:");
            Display();
        }

        static void AddFirst(int roll, string name, int age, string grade)
        {
            Node n = new Node(roll, name, age, grade);

            n.next = head;
            head = n;
        }

        static void AddLast(int roll, string name, int age, string grade)
        {
            Node n = new Node(roll, name, age, grade);

            if (head == null)
            {
                head = n;
                return;
            }

            Node temp = head;

            while (temp.next != null)
            {
                temp = temp.next;
            }

            temp.next = n;
        }

        static void AddPosition(
            int roll,
            string name,
            int age,
            string grade,
            int position)
        {
            if (position == 1)
            {
                AddFirst(roll, name, age, grade);
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

            Node n = new Node(roll, name, age, grade);

            n.next = temp.next;
            temp.next = n;
        }

        static void Delete(int roll)
        {
            if (head == null)
                return;

            if (head.roll == roll)
            {
                head = head.next;
                return;
            }

            Node temp = head;

            while (temp.next != null)
            {
                if (temp.next.roll == roll)
                {
                    temp.next = temp.next.next;
                    return;
                }

                temp = temp.next;
            }
        }

        static void Search(int roll)
        {
            Node temp = head;

            while (temp != null)
            {
                if (temp.roll == roll)
                {
                    Console.WriteLine(
                        temp.roll + " " +
                        temp.name + " " +
                        temp.age + " " +
                        temp.grade);

                    return;
                }

                temp = temp.next;
            }

            Console.WriteLine("Student not found");
        }

        static void UpdateGrade(int roll, string grade)
        {
            Node temp = head;

            while (temp != null)
            {
                if (temp.roll == roll)
                {
                    temp.grade = grade;
                    return;
                }

                temp = temp.next;
            }
        }

        static void Display()
        {
            Node temp = head;

            while (temp != null)
            {
                Console.WriteLine(
                    "Roll: " + temp.roll +
                    ", Name: " + temp.name +
                    ", Age: " + temp.age +
                    ", Grade: " + temp.grade);

                temp = temp.next;
            }
        }
    }
}
