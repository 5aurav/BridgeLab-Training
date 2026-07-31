using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructors
{
    internal class CircleClass
    {
        double radius;

        public CircleClass() : this(1)
        {
        }

        public CircleClass(double radius)
        {
            this.radius = radius;
        }

        public double Area()
        {
            return 3.14 * radius * radius;
        }

        public void Display()
        {
            Console.WriteLine("Radius : " + radius);
            Console.WriteLine("Area : " + Area());
        }

        public static void display()
        {
            CircleClass c1 = new CircleClass();
            CircleClass c2 = new CircleClass(5);

            Console.WriteLine("Default Constructor");
            c1.Display();

            Console.WriteLine();

            Console.WriteLine("Parameterized Constructor");
            c2.Display();
        }
    }
}
