using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class _2DArrayTo1DArray
    {
        public static void Run()
        {
            Console.Write("Enter the no of rows: ");
            int rows = int.Parse(Console.ReadLine());
            Console.Write("Enter the no of cols: ");
            int cols = int.Parse(Console.ReadLine());
            int[,] matrix = new int[rows, cols];
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            int[] arr = new int[rows * cols];
            int index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    arr[index++] = matrix[i, j];
                }
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j]+" ");
                }
                Console.Write("\n");
            }
            for (int i = 0; i < rows * cols; i++)
            {
                Console.Write(arr[i]+" ");
            }
        }
    }
}
