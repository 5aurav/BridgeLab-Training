using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparative_Analysis
{
    internal class FibonacciCompare
    {
        static long FibonacciRecursive(int n)
        {
            if (n <= 1)
                return n;

            return FibonacciRecursive(n - 1) +
                   FibonacciRecursive(n - 2);
        }

        static long FibonacciIterative(int n)
        {
            if (n <= 1)
                return n;

            long a = 0;
            long b = 1;

            for (int i = 2; i <= n; i++)
            {
                long sum = a + b;
                a = b;
                b = sum;
            }

            return b;
        }

        public static void TestFibonacci(int n)
        {
            Console.WriteLine($"N = {n}");

            Stopwatch stopwatch = Stopwatch.StartNew();

            long recursiveResult = FibonacciRecursive(n);

            stopwatch.Stop();

            double recursiveTime = stopwatch.Elapsed.TotalMilliseconds;

            stopwatch.Restart();

            long iterativeResult = FibonacciIterative(n);

            stopwatch.Stop();

            double iterativeTime = stopwatch.Elapsed.TotalMilliseconds;

            Console.WriteLine($"Recursive Result: {recursiveResult}");
            Console.WriteLine($"Recursive Time: {recursiveTime:F6} ms");

            Console.WriteLine($"Iterative Result: {iterativeResult}");
            Console.WriteLine($"Iterative Time: {iterativeTime:F6} ms");
        }
    }
}
