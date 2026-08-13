using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMap_and_HashSet
{
    class CustomHashMap
    {
        class Node
        {
            public int key;
            public string value;
            public Node next;

            public Node(int key, string value)
            {
                this.key = key;
                this.value = value;
            }
        }

        class MyHashMap
        {
            Node[] table;
            int size;

            public MyHashMap(int size)
            {
                this.size = size;
                table = new Node[size];
            }

            int GetIndex(int key)
            {
                return Math.Abs(key) % size;
            }

            public void Put(int key, string value)
            {
                int index = GetIndex(key);

                Node temp = table[index];

                while (temp != null)
                {
                    if (temp.key == key)
                    {
                        temp.value = value;
                        return;
                    }

                    temp = temp.next;
                }

                Node n = new Node(key, value);

                n.next = table[index];
                table[index] = n;
            }

            public string Get(int key)
            {
                int index = GetIndex(key);

                Node temp = table[index];

                while (temp != null)
                {
                    if (temp.key == key)
                        return temp.value;

                    temp = temp.next;
                }

                return null;
            }

            public void Remove(int key)
            {
                int index = GetIndex(key);

                Node temp = table[index];
                Node prev = null;

                while (temp != null)
                {
                    if (temp.key == key)
                    {
                        if (prev == null)
                            table[index] = temp.next;
                        else
                            prev.next = temp.next;

                        return;
                    }

                    prev = temp;
                    temp = temp.next;
                }
            }

            public void Display()
            {
                for (int i = 0; i < size; i++)
                {
                    Node temp = table[i];

                    Console.Write(i + ": ");

                    while (temp != null)
                    {
                        Console.Write(
                            "[" +
                            temp.key +
                            ", " +
                            temp.value +
                            "] ");

                        temp = temp.next;
                    }

                    Console.WriteLine();
                }
            }
        }

        public static void Run()
        {
            MyHashMap map =
                new MyHashMap(5);

            map.Put(1, "Amit");
            map.Put(6, "Riya");
            map.Put(11, "Rahul");
            map.Put(2, "Neha");

            Console.WriteLine(
                "Value of key 6: " +
                map.Get(6));

            Console.WriteLine("\nHash Map:");
            map.Display();

            map.Put(6, "Priya");

            Console.WriteLine(
                "\nAfter updating key 6:");

            Console.WriteLine(
                map.Get(6));

            map.Remove(11);

            Console.WriteLine(
                "\nAfter deleting key 11:");

            map.Display();
        }
    }
}
