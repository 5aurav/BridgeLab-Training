using System;

namespace AccessModifiers
{
    class Employee
    {
        public int employeeID;
        protected string department;
        private double salary;

        public Employee(int employeeID, string department, double salary)
        {
            this.employeeID = employeeID;
            this.department = department;
            this.salary = salary;
        }

        public void SetSalary(double salary)
        {
            this.salary = salary;
        }

        public double GetSalary()
        {
            return salary;
        }
    }

    class Manager : Employee
    {
        public Manager(int employeeID, string department, double salary)
            : base(employeeID, department, salary)
        {
        }

        public void Display()
        {
            Console.WriteLine("Employee ID : " + employeeID);
            Console.WriteLine("Department  : " + department);
            Console.WriteLine("Salary      : " + GetSalary());
        }
    }

    class EmployeeRecords
    {
        public static void display()
        {
            Manager manager = new Manager(101, "Information Technology", 75000);

            Console.WriteLine("Employee Details");
            manager.Display();

            Console.WriteLine();

            manager.SetSalary(85000);

            Console.WriteLine("After Salary Update");
            Console.WriteLine("Salary : " + manager.GetSalary());
        }
    }
}