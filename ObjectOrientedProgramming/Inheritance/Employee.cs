using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Employee
    {
        public String Name { get; set; }
        public int Id { get; set; }
        public double Salary { get; set; }
        public Employee(string name, int id, double salary)
        {
            Name = name;
            Id = id;
            Salary = salary;
        }
        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Salary: {Salary}");
        } 
    }
    class Manager : Employee
    {
        public int TeamSize { get; set; }
        public Manager(string name, int id, double salary, int teamSize)
            : base(name, id, salary)
        {
            TeamSize = teamSize;
        }
        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Team Size: {TeamSize}");
        }
    }

    class Developer : Employee
    {
        public String ProgrammingLanguage { get; set; }
        public Developer(string name, int id, double salary, string language)
            : base(name, id, salary)
        {
            ProgrammingLanguage = language;
        }
        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Programming Language: {ProgrammingLanguage}");
        }
    }

    class Intern : Employee
    {
        public String InternshipDuration { get; set; }
        public Intern(string name, int id, double salary, string duration)
            : base(name, id, salary)
        {
            InternshipDuration = duration;
        }
        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Internship Duration: {InternshipDuration}");
        }
    }

    internal class EmployeeDisplay
    {
        public static void ShowEmployees()
        {
            Employee manager = new Manager("Rahul", 101, 90000, 10);
            Employee developer = new Developer("Saurav", 102, 70000, "C#");
            Employee intern = new Intern("Aman", 103, 15000, "6 Months");

            manager.DisplayDetails();
            Console.WriteLine();

            developer.DisplayDetails();
            Console.WriteLine();

            intern.DisplayDetails();
        }
    }
}
