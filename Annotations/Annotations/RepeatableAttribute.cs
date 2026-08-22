using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    public class RepeatableAttribute
    {
        public static void Run()
        {
            MethodInfo method =
                typeof(BugTracker).GetMethod("ProcessPayment");

            BugReportAttribute[] reports =
                method.GetCustomAttributes<BugReportAttribute>().ToArray();

            foreach (BugReportAttribute report in reports)
            {
                Console.WriteLine("Bug: " + report.Description);
            }
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class BugReportAttribute : Attribute
    {
        public string Description { get; }

        public BugReportAttribute(string description)
        {
            Description = description;
        }
    }

    public class BugTracker
    {
        [BugReport("Payment fails with invalid card.")]
        [BugReport("Payment button freezes after clicking.")]
        public void ProcessPayment()
        {
            Console.WriteLine("Processing payment.");
        }
    }
}
