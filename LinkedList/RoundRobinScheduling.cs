using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class RoundRobinScheduling
    {
        class Node
        {
            public int id;
            public int burst;
            public int remaining;
            public int priority;

            public int waiting;
            public int turnaround;

            public Node next;

            public Node(
                int id,
                int burst,
                int priority)
            {
                this.id = id;
                this.burst = burst;
                this.remaining = burst;
                this.priority = priority;
            }
        }

        static Node head;
        static Node tail;

        public static void Run()
        {
            head = null;
            tail = null;

            AddProcess(1, 5, 1);
            AddProcess(2, 8, 2);
            AddProcess(3, 6, 1);
            AddProcess(4, 3, 2);

            Console.Write("Enter time quantum: ");
            int quantum = Convert.ToInt32(
                Console.ReadLine());

            RoundRobin(quantum);
        }

        static void AddProcess(
            int id,
            int burst,
            int priority)
        {
            Node n = new Node(
                id,
                burst,
                priority);

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
        }

        static void RoundRobin(int quantum)
        {
            int total = Count();

            Node[] process = new Node[total];

            Node temp = head;

            for (int i = 0; i < total; i++)
            {
                process[i] = temp;
                temp = temp.next;
            }

            Node current = head;
            int time = 0;
            int completed = 0;

            while (completed < total)
            {
                if (current.remaining > 0)
                {
                    int runTime = Math.Min(
                        quantum,
                        current.remaining);

                    current.remaining -= runTime;
                    time += runTime;

                    if (current.remaining == 0)
                    {
                        current.turnaround = time;

                        current.waiting =
                            current.turnaround -
                            current.burst;

                        completed++;
                    }
                }

                Console.WriteLine(
                    "\nAfter running P" +
                    current.id);

                DisplayProcesses();

                current = current.next;
            }

            double totalWaiting = 0;
            double totalTurnaround = 0;

            Console.WriteLine("\nResults:");

            for (int i = 0; i < total; i++)
            {
                Console.WriteLine(
                    "P" + process[i].id +
                    " Waiting = " +
                    process[i].waiting +
                    " Turnaround = " +
                    process[i].turnaround);

                totalWaiting += process[i].waiting;
                totalTurnaround += process[i].turnaround;
            }

            Console.WriteLine(
                "\nAverage Waiting Time = " +
                totalWaiting / total);

            Console.WriteLine(
                "Average Turnaround Time = " +
                totalTurnaround / total);
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
                        head = tail = null;
                        return;
                    }

                    if (temp == head)
                        head = head.next;

                    if (temp == tail)
                        tail = prev;

                    prev.next = temp.next;
                    tail.next = head;

                    return;
                }

                prev = temp;
                temp = temp.next;

            } while (temp != head);
        }

        static int Count()
        {
            if (head == null)
                return 0;

            int count = 0;
            Node temp = head;

            do
            {
                count++;
                temp = temp.next;

            } while (temp != head);

            return count;
        }

        static void DisplayProcesses()
        {
            Node temp = head;

            do
            {
                Console.WriteLine(
                    "P" + temp.id +
                    " Remaining Time = " +
                    temp.remaining);

                temp = temp.next;

            } while (temp != head);
        }
    }
}
