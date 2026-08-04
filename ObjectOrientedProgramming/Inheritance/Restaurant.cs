using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    interface Worker
    {
        void PerformDuties();
    }

    internal class Employees
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Employees(string name, int id)
        {
            Name = name;
            Id = id;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"ID : {Id}");
        }
    }

    class Chef : Employees, Worker
    {
        public Chef(string name, int id)
            : base(name, id)
        {
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Chef");
            base.DisplayInfo();
        }

        public void PerformDuties()
        {
            Console.WriteLine("Preparing food for customers.");
        }
    }

    class Waiter : Employees, Worker
    {
        public Waiter(string name, int id)
            : base(name, id)
        {
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Waiter");
            base.DisplayInfo();
        }

        public void PerformDuties()
        {
            Console.WriteLine("Serving food to customers.");
        }
    }

    internal class RestaurantDisplay
    {
        public static void ShowRestaurant()
        {
            Worker[] workers =
            {
                new Chef("Rahul", 101),
                new Waiter("Saurav", 102)
            };

            foreach (Worker worker in workers)
            {
                if (worker is Employees employee)
                {
                    employee.DisplayInfo();
                }

                worker.PerformDuties();
                Console.WriteLine();
            }
        }
    }
}
