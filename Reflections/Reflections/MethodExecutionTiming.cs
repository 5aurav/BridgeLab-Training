using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflections
{
    public class MethodExecutionTiming
    {
        public static void Run()
        {
            PerformanceCalculator calculator =
                new PerformanceCalculator();

            Type type = calculator.GetType();

            Console.Write("Enter method name (Calculate/Sum): ");
            string methodName = Console.ReadLine();

            MethodInfo method =
                type.GetMethod(methodName ?? "");

            if (method == null)
            {
                Console.WriteLine("Method not found.");
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            object result;

            if (method.GetParameters().Length == 2)
            {
                result = method.Invoke(
                    calculator,
                    new object[] { 1, 1000000 });
            }
            else
            {
                result = method.Invoke(calculator, null);
            }

            stopwatch.Stop();

            Console.WriteLine($"Result: {result}");
            Console.WriteLine(
                $"Execution Time: {stopwatch.ElapsedMilliseconds} ms");
        }
    }

    public class PerformanceCalculator
    {
        public long Calculate(int start, int end)
        {
            long sum = 0;

            for (int i = start; i <= end; i++)
            {
                sum += i;
            }

            return sum;
        }

        public long Sum()
        {
            long sum = 0;

            for (int i = 0; i < 10000000; i++)
            {
                sum += i;
            }

            return sum;
        }
    }
}
