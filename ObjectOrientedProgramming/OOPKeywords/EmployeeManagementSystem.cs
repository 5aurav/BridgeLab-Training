using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPKeywords
{
    internal class EmployeeManagementSystem
    {
        public string Name;
        public readonly int Id;
        public string Designation;

        static string CompanyName = "BridgeLabz";
        static int TotalEmployees = 0;

        public EmployeeManagementSystem(string Name, int Id, string Designation)
        {
            this.Name = Name;
            this.Id = Id;
            this.Designation = Designation;

            TotalEmployees++;
        }

        public void DisplayDetails()
        {
            Console.WriteLine("Company Name : " + CompanyName);
            Console.WriteLine("Employee ID  : " + Id);
            Console.WriteLine("Name         : " + Name);
            Console.WriteLine("Designation  : " + Designation);
        }

        public static void DisplayTotalEmployees()
        {
            Console.WriteLine("Total Employees : " + TotalEmployees);
        }

        public static void display()
        {
            EmployeeManagementSystem emp1 =
                new EmployeeManagementSystem("Saurav", 101, "Software Engineer");

            EmployeeManagementSystem emp2 =
                new EmployeeManagementSystem("Rahul", 102, "Full Stack Developer");

            if (emp1 is EmployeeManagementSystem)
            {
                Console.WriteLine("Employee 1 Details");
                emp1.DisplayDetails();
            }

            Console.WriteLine();

            if (emp2 is EmployeeManagementSystem)
            {
                Console.WriteLine("Employee 2 Details");
                emp2.DisplayDetails();
            }

            Console.WriteLine();

            DisplayTotalEmployees();
        }
    }
}
