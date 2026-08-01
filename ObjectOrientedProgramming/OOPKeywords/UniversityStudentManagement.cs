using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPKeywords
{
    internal class UniversityStudentManagement
    {
        public string Name;
        public readonly int RollNumber;
        public string Grade;

        static string UniversityName = "Chitkara University";
        static int TotalStudents = 0;

        public UniversityStudentManagement(string Name, int RollNumber, string Grade)
        {
            this.Name = Name;
            this.RollNumber = RollNumber;
            this.Grade = Grade;

            TotalStudents++;
        }

        public void DisplayDetails()
        {
            Console.WriteLine("University  : " + UniversityName);
            Console.WriteLine("Roll Number : " + RollNumber);
            Console.WriteLine("Name        : " + Name);
            Console.WriteLine("Grade       : " + Grade);
        }

        public void UpdateGrade(string Grade)
        {
            this.Grade = Grade;
        }

        public static void DisplayTotalStudents()
        {
            Console.WriteLine("Total Students : " + TotalStudents);
        }

        public static void display()
        {
            UniversityStudentManagement s1 =
                new UniversityStudentManagement("Saurav", 101, "A");

            UniversityStudentManagement s2 =
                new UniversityStudentManagement("Rahul", 102, "B+");

            if (s1 is UniversityStudentManagement)
            {
                Console.WriteLine("Student 1 Details");
                s1.DisplayDetails();
            }

            Console.WriteLine();

            if (s2 is UniversityStudentManagement)
            {
                Console.WriteLine("Student 2 Details");
                s2.DisplayDetails();
            }

            Console.WriteLine();

            s2.UpdateGrade("A+");

            Console.WriteLine("After Updating Grade");

            Console.WriteLine();

            s2.DisplayDetails();

            Console.WriteLine();

            DisplayTotalStudents();
        }
    }
}
