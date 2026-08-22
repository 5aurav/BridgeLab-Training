using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    public class LogExecutionTimeRunner
    {
        public static void Run()
        {
            ExecuteMethod("FastMethod");
            ExecuteMethod("SlowMethod");
        }

        private static void ExecuteMethod(string methodName)
        {
            PerformanceTest test = new PerformanceTest();

            MethodInfo method =
                typeof(PerformanceTest).GetMethod(methodName);

            LogExecutionTimeAttribute attribute =
                method.GetCustomAttribute<LogExecutionTimeAttribute>();

            if (attribute == null)
            {
                method.Invoke(test, null);
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            method.Invoke(test, null);

            stopwatch.Stop();

            Console.WriteLine(
                method.Name +
                " execution time: " +
                stopwatch.ElapsedMilliseconds +
                " ms");
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class LogExecutionTimeAttribute : Attribute
    {
    }

    public class PerformanceTest
    {
        [LogExecutionTime]
        public void FastMethod()
        {
            for (int i = 0; i < 100000; i++)
            {
                int x = i * i;
            }
        }

        [LogExecutionTime]
        public void SlowMethod()
        {
            for (int i = 0; i < 10000000; i++)
            {
                int x = i * i;
            }
        }
    }
}
