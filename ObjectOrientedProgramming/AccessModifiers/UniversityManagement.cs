using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    class Student
    {
        public int rollNumber;
        protected string name;
        private double cgpa;

        public Student(int rollNumber, string name, double cgpa)
        {
            this.rollNumber = rollNumber;
            this.name = name;
            this.cgpa = cgpa;
        }

        public void SetCGPA(double cgpa)
        {
            this.cgpa = cgpa;
        }

        public double GetCGPA()
        {
            return cgpa;
        }
    }

    class PostgraduateStudent : Student
    {
        public PostgraduateStudent(int rollNumber, string name, double cgpa)
            : base(rollNumber, name, cgpa)
        {
        }

        public void Display()
        {
            Console.WriteLine("Roll Number : " + rollNumber);
            Console.WriteLine("Name        : " + name);
            Console.WriteLine("CGPA        : " + GetCGPA());
        }
    }

    class UniversityManagement
    {
        public static void display()
        {
            PostgraduateStudent student = new PostgraduateStudent(101, "Saurav", 8.7);

            Console.WriteLine("Student Details");
            student.Display();

            Console.WriteLine();

            student.SetCGPA(9.2);

            Console.WriteLine("After Updating CGPA");
            Console.WriteLine("CGPA : " + student.GetCGPA());
        }
    }
}
