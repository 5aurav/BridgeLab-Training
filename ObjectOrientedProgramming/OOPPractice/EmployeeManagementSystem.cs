using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPractice
{
        interface IDepartment
        {
            void AssignDepartment(string department);
            void GetDepartmentDetails();
        }

        abstract class Employee
        {
            private int employeeId;
            private string name;
            private double baseSalary;

            public int EmployeeId
            {
                get { return employeeId; }
                set { employeeId = value; }
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public double BaseSalary
            {
                get { return baseSalary; }
                set { baseSalary = value; }
            }

            public Employee(int employeeId, string name, double baseSalary)
            {
                EmployeeId = employeeId;
                Name = name;
                BaseSalary = baseSalary;
            }

            public abstract double CalculateSalary();

            public void DisplayDetails()
            {
                Console.WriteLine($"Employee ID : {EmployeeId}");
                Console.WriteLine($"Name        : {Name}");
                Console.WriteLine($"Base Salary : {BaseSalary}");
            }
        }

        class FullTimeEmployee : Employee, IDepartment
        {
            private string department;

            public FullTimeEmployee(int employeeId, string name, double baseSalary)
                : base(employeeId, name, baseSalary)
            {
            }

            public override double CalculateSalary()
            {
                return BaseSalary;
            }

            public void AssignDepartment(string department)
            {
                this.department = department;
            }

            public void GetDepartmentDetails()
            {
                Console.WriteLine($"Department  : {department}");
            }
        }

        class PartTimeEmployee : Employee, IDepartment
        {
            private string department;
            private int workingHours;
            private double hourlyRate;

            public int WorkingHours
            {
                get { return workingHours; }
                set { workingHours = value; }
            }

            public double HourlyRate
            {
                get { return hourlyRate; }
                set { hourlyRate = value; }
            }

            public PartTimeEmployee(int employeeId, string name, double baseSalary,
                int workingHours, double hourlyRate)
                : base(employeeId, name, baseSalary)
            {
                WorkingHours = workingHours;
                HourlyRate = hourlyRate;
            }

            public override double CalculateSalary()
            {
                return WorkingHours * HourlyRate;
            }

            public void AssignDepartment(string department)
            {
                this.department = department;
            }

            public void GetDepartmentDetails()
            {
                Console.WriteLine($"Department  : {department}");
            }
        }

        class EmployeeManagement
        {
            public static void Run()
            {
                List<Employee> employees = new List<Employee>();

                FullTimeEmployee emp1 = new FullTimeEmployee(101, "Rahul", 60000);
                emp1.AssignDepartment("IT");

                PartTimeEmployee emp2 = new PartTimeEmployee(102, "Priya", 0, 80, 500);
                emp2.AssignDepartment("HR");

                employees.Add(emp1);
                employees.Add(emp2);

                foreach (Employee employee in employees)
                {
                    employee.DisplayDetails();

                    if (employee is IDepartment department)
                    {
                        department.GetDepartmentDetails();
                    }

                    Console.WriteLine($"Calculated Salary : {employee.CalculateSalary()}");
                    Console.WriteLine();
                }
            }
        }
    }