using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    public class DynamicMethodInvocation
    {
        public static void Run()
        {
            MathOperations operations = new MathOperations();

            Console.Write("Enter method name (Add/Subtract/Multiply): ");
            string methodName = Console.ReadLine();

            MethodInfo method = typeof(MathOperations).GetMethod(methodName ?? "");

            if (method == null)
            {
                Console.WriteLine("Method not found.");
                return;
            }

            Console.Write("Enter first number: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int b = Convert.ToInt32(Console.ReadLine());

            object result = method.Invoke(
                operations,
                new object[] { a, b });

            Console.WriteLine($"Result: {result}");
        }
    }

    public class MathOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
