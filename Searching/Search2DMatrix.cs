using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    internal class Search2DMatrix
    {
        public static void Run()
        {
            int[,] matrix =
            {
                { 1, 3, 5 },
                { 7, 9, 11 },
                { 13, 15, 17 }
            };

            int target = 9;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int left = 0;
                int right = matrix.GetLength(1) - 1;

                while (left <= right)
                {
                    int mid = (left + right) / 2;

                    if (matrix[row, mid] == target)
                    {
                        Console.WriteLine(
                            "Found at row " + row +
                            ", column " + mid);
                        return;
                    }

                    if (matrix[row, mid] < target)
                        left = mid + 1;
                    else
                        right = mid - 1;
                }
            }

            Console.WriteLine("Target not found.");
        }
    }
}
