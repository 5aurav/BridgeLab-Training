using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    internal class PersonClass
    {
        string name;
        int age;

        public PersonClass(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public PersonClass(PersonClass p)
        {
            this.name = p.name;
            this.age = p.age;
        }

        public void Display()
        {
            Console.WriteLine("Name : " + name);
            Console.WriteLine("Age : " + age);
        }

        public static void display()
        {
            PersonClass p1 = new PersonClass("Saurav", 21);
            PersonClass p2 = new PersonClass(p1);

            Console.WriteLine("Original Object");
            p1.Display();

            Console.WriteLine();

            Console.WriteLine("Copied Object");
            p2.Display();
        }
    }
}
