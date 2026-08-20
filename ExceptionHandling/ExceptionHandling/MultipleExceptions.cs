using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    internal class MultipleExceptions
    {
        public static void Run()
        {
            int[] numbers = null;

            try
            {
                Console.Write("Enter array size: ");
                int size = int.Parse(Console.ReadLine());

                numbers = new int[size];

                Console.WriteLine("Enter array elements:");

                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = int.Parse(Console.ReadLine());
                }

                Console.Write("Enter index: ");
                int index = int.Parse(Console.ReadLine());

                Console.WriteLine(
                    $"Value at index {index}: {numbers[index]}"
                );
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid index!");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Array is not initialized!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
