using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public virtual void DisplayRole()
        {
            Console.WriteLine($"Name : {Name}");
            Console.WriteLine($"Age : {Age}");
        }
    }

    class Teacher : Person
    {
        public string Subject { get; set; }

        public Teacher(string name, int age, string subject)
            : base(name, age)
        {
            Subject = subject;
        }

        public override void DisplayRole()
        {
            Console.WriteLine("Teacher");
            base.DisplayRole();
            Console.WriteLine($"Subject : {Subject}");
        }
    }

    class Student : Person
    {
        public string Grade { get; set; }

        public Student(string name, int age, string grade)
            : base(name, age)
        {
            Grade = grade;
        }

        public override void DisplayRole()
        {
            Console.WriteLine("Student");
            base.DisplayRole();
            Console.WriteLine($"Grade : {Grade}");
        }
    }

    class Staff : Person
    {
        public string Department { get; set; }

        public Staff(string name, int age, string department)
            : base(name, age)
        {
            Department = department;
        }

        public override void DisplayRole()
        {
            Console.WriteLine("Staff");
            base.DisplayRole();
            Console.WriteLine($"Department : {Department}");
        }
    }

    internal class SchoolDisplay
    {
        public static void ShowRoles()
        {
            Person[] people =
            {
                new Teacher("Rahul",35,"Mathematics"),
                new Student("Saurav",20,"B.Tech CSE"),
                new Staff("Amit",40,"Administration")
            };

            foreach (Person person in people)
            {
                person.DisplayRole();
                Console.WriteLine();
            }
        }
    }
}
