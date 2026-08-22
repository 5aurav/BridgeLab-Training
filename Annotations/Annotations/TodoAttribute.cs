using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TodoAttribute : Attribute
    {
        public static void Run()
        {
            MethodInfo[] methods =
                typeof(Project).GetMethods(
                    BindingFlags.Public |
                    BindingFlags.Instance |
                    BindingFlags.DeclaredOnly);

            foreach (MethodInfo method in methods)
            {
                IEnumerable<TodoAttribute> todos =
                    method.GetCustomAttributes<TodoAttribute>();

                foreach (TodoAttribute todo in todos)
                {
                    Console.WriteLine("Method: " + method.Name);
                    Console.WriteLine("Task: " + todo.Task);
                    Console.WriteLine("Assigned To: " + todo.AssignedTo);
                    Console.WriteLine("Priority: " + todo.Priority);
                    Console.WriteLine();
                }
            }
        }

        public string Task { get; }
        public string AssignedTo { get; }
        public string Priority { get; }

        public TodoAttribute(
            string task,
            string assignedTo,
            string priority = "MEDIUM")
        {
            Task = task;
            AssignedTo = assignedTo;
            Priority = priority;
        }
    }

    public class Project
    {
        [Todo("Implement login", "Saurav", "HIGH")]
        public void Login()
        {
        }

        [Todo("Improve validation", "Rahul")]
        public void Validation()
        {
        }

        public void Dashboard()
        {
        }
    }
}
