using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    public class InvokePrivateMethod
    {
        public static void Run()
        {
            Calculator calculator = new Calculator();

            Type type = typeof(Calculator);

            MethodInfo method = type.GetMethod(
                "Multiply",
                BindingFlags.NonPublic | BindingFlags.Instance);

            if (method == null)
            {
                Console.WriteLine("Method not found.");
                return;
            }

            object result = method.Invoke(
                calculator,
                new object[] { 10, 5 });

            Console.WriteLine($"Result: {result}");
        }
    }

    public class Calculator
    {
        private int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
