using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class TextEditorHistory
    {
        class Node
        {
            public string text;
            public Node prev;
            public Node next;

            public Node(string text)
            {
                this.text = text;
            }
        }

        static Node head;
        static Node tail;
        static Node current;

        static int count;
        static int max = 10;

        public static void Run()
        {
            head = null;
            tail = null;
            current = null;
            count = 0;

            AddState("");
            AddState("Hello");
            AddState("Hello World");
            AddState("Hello World!");

            Console.WriteLine(
                "Current: " + current.text);

            Undo();

            Console.WriteLine(
                "After Undo: " + current.text);

            Redo();

            Console.WriteLine(
                "After Redo: " + current.text);

            AddState("Hello World! Welcome");

            Console.WriteLine(
                "Current: " + current.text);

            Display();
        }

        static void AddState(string text)
        {
            Node n = new Node(text);

            if (head == null)
            {
                head = tail = current = n;
                count++;
                return;
            }

            if (current != tail)
            {
                Node temp = current.next;

                while (temp != null)
                {
                    temp = temp.next;
                }

                current.next = null;
                tail = current;
            }

            n.prev = tail;
            tail.next = n;
            tail = n;
            current = n;

            count++;

            if (count > max)
            {
                head = head.next;
                head.prev = null;
                count--;
            }
        }

        static void Undo()
        {
            if (current != null &&
                current.prev != null)
            {
                current = current.prev;
            }
        }

        static void Redo()
        {
            if (current != null &&
                current.next != null)
            {
                current = current.next;
            }
        }

        static void DisplayCurrent()
        {
            if (current != null)
            {
                Console.WriteLine(
                    "Current text: " +
                    current.text);
            }
        }

        static void Display()
        {
            Node temp = head;

            Console.WriteLine("\nHistory:");

            while (temp != null)
            {
                if (temp == current)
                    Console.WriteLine(
                        "-> " + temp.text);
                else
                    Console.WriteLine(
                        "   " + temp.text);

                temp = temp.next;
            }
        }
    }
}
