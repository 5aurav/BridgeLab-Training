using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class EmployeeDetails
    {
        string name;
        int id;
        double salary;

        public EmployeeDetails(string name, int id, double salary)
        {
            this.name = name;
            this.id = id;
            this.salary = salary;
        }

        public void ShowDetails()
        {
            Console.WriteLine("Employee Name : " + name);
            Console.WriteLine("Employee ID   : " + id);
            Console.WriteLine("Salary        : " + salary);
        }

        public static void display()
        {
            EmployeeDetails emp = new EmployeeDetails("Saurav", 101, 50000);

            emp.ShowDetails();
        }
    }
}
