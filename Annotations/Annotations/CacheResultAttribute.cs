using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Annotations
{
    public class CacheResultDemo
    {
        public static void Run()
        {
            Calculator calculator = new Calculator();

            Execute(calculator, "Calculate", 10);
            Execute(calculator, "Calculate", 10);
            Execute(calculator, "Calculate", 20);
            Execute(calculator, "Calculate", 20);
        }

        private static Dictionary<string, object> cache =
            new Dictionary<string, object>();

        private static void Execute(
            object target,
            string methodName,
            params object[] parameters)
        {
            Type type = target.GetType();

            MethodInfo method =
                type.GetMethod(methodName);

            CacheResultAttribute attribute =
                method.GetCustomAttribute<CacheResultAttribute>();

            string key = methodName;

            foreach (object parameter in parameters)
            {
                key += "_" + parameter;
            }

            if (attribute != null && cache.ContainsKey(key))
            {
                Console.WriteLine(
                    "Returning cached result: " +
                    cache[key]);

                return;
            }

            object result =
                method.Invoke(target, parameters);

            if (attribute != null)
            {
                cache[key] = result;
            }

            Console.WriteLine(
                "Calculated result: " +
                result);
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class CacheResultAttribute : Attribute
    {
    }

    public class Calculator
    {
        [CacheResult]
        public int Calculate(int number)
        {
            Console.WriteLine(
                "Executing expensive calculation...");

            int result = 0;

            for (int i = 0; i < 100000000; i++)
            {
                result += number;
            }

            return result;
        }
    }
}
