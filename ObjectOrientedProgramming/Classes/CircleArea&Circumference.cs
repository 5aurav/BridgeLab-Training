using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class CircleArea_Circumference
    {
        double radius;

        public CircleArea_Circumference(double radius)
        {
            this.radius = radius;
        }

        public double Area()
        {
            return Math.PI * radius * radius;
        }

        public double Circumference()
        {
            return 2 * Math.PI * radius;
        }

        public void ShowDetails()
        {
            Console.WriteLine("Radius: " + radius);
            Console.WriteLine("Area: " + Area());
            Console.WriteLine("Circumference: " + Circumference());
        }

        public static void display()
        {
            CircleArea_Circumference circle = new CircleArea_Circumference(5);

            circle.ShowDetails();
        }
    }
}
