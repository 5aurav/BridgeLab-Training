using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    public class TaskInfoAttributeExample
    {
        public static void Run()
        {
            Type type = typeof(TaskManager);

            MethodInfo method = type.GetMethod("CompleteTask");

            TaskInfoAttribute attribute =
                method.GetCustomAttribute<TaskInfoAttribute>();

            Console.WriteLine("Task Information");
            Console.WriteLine("Priority: " + attribute.Priority);
            Console.WriteLine("Assigned To: " + attribute.AssignedTo);
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class TaskInfoAttribute : Attribute
    {
        public string Priority { get; }
        public string AssignedTo { get; }

        public TaskInfoAttribute(string priority, string assignedTo)
        {
            Priority = priority;
            AssignedTo = assignedTo;
        }
    }

    public class TaskManager
    {
        [TaskInfo("HIGH", "Saurav")]
        public void CompleteTask()
        {
            Console.WriteLine("Task completed.");
        }
    }
}
