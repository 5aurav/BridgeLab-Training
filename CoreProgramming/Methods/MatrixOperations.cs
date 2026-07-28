using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class MatrixOperations
    {
        public static void display()
        {
            Console.WriteLine("Matrix A");
            double[,] matrixA = CreateRandomMatrix(3, 3);

            Console.WriteLine("Matrix B");
            double[,] matrixB = CreateRandomMatrix(3, 3);

            Console.WriteLine("\nAddition");
            DisplayMatrix(AddMatrices(matrixA, matrixB));

            Console.WriteLine("\nSubtraction");
            DisplayMatrix(SubtractMatrices(matrixA, matrixB));

            Console.WriteLine("\nMultiplication");
            DisplayMatrix(MultiplyMatrices(matrixA, matrixB));

            Console.WriteLine("\nTranspose of Matrix A");
            DisplayMatrix(TransposeMatrix(matrixA));

            Console.WriteLine("\nDeterminant of Matrix A");
            Console.WriteLine(Determinant3x3(matrixA));

            Console.WriteLine("\nInverse of Matrix A");
            double[,] inverse = Inverse3x3(matrixA);

            if (inverse == null)
            {
                Console.WriteLine("Inverse does not exist.");
            }
            else
            {
                DisplayMatrix(inverse);
            }
        }

        public static double[,] CreateRandomMatrix(int rows, int cols)
        {
            Random random = new Random();

            double[,] matrix = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = random.Next(1, 10);
                }
            }

            DisplayMatrix(matrix);

            return matrix;
        }

        public static double[,] AddMatrices(double[,] a, double[,] b)
        {
            int rows = a.GetLength(0);
            int cols = a.GetLength(1);

            double[,] result = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }

            return result;
        }

        public static double[,] SubtractMatrices(double[,] a, double[,] b)
        {
            int rows = a.GetLength(0);
            int cols = a.GetLength(1);

            double[,] result = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }

            return result;
        }

        public static double[,] MultiplyMatrices(double[,] a, double[,] b)
        {
            int rows = a.GetLength(0);
            int cols = b.GetLength(1);
            int common = a.GetLength(1);

            double[,] result = new double[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    for (int k = 0; k < common; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return result;
        }

        public static double[,] TransposeMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            double[,] transpose = new double[cols, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    transpose[j, i] = matrix[i, j];
                }
            }

            return transpose;
        }

        public static double Determinant2x2(double[,] matrix)
        {
            return matrix[0, 0] * matrix[1, 1] -
                   matrix[0, 1] * matrix[1, 0];
        }

        public static double Determinant3x3(double[,] matrix)
        {
            return
                matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1])
              - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])
              + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);
        }

        public static double[,] Inverse2x2(double[,] matrix)
        {
            double determinant = Determinant2x2(matrix);

            if (determinant == 0)
            {
                return null;
            }

            double[,] inverse = new double[2, 2];

            inverse[0, 0] = matrix[1, 1] / determinant;
            inverse[0, 1] = -matrix[0, 1] / determinant;
            inverse[1, 0] = -matrix[1, 0] / determinant;
            inverse[1, 1] = matrix[0, 0] / determinant;

            return inverse;
        }

        public static double[,] Inverse3x3(double[,] matrix)
        {
            double determinant = Determinant3x3(matrix);

            if (determinant == 0)
            {
                return null;
            }

            double[,] inverse = new double[3, 3];

            inverse[0, 0] = ((matrix[1, 1] * matrix[2, 2]) - (matrix[1, 2] * matrix[2, 1])) / determinant;
            inverse[0, 1] = ((matrix[0, 2] * matrix[2, 1]) - (matrix[0, 1] * matrix[2, 2])) / determinant;
            inverse[0, 2] = ((matrix[0, 1] * matrix[1, 2]) - (matrix[0, 2] * matrix[1, 1])) / determinant;

            inverse[1, 0] = ((matrix[1, 2] * matrix[2, 0]) - (matrix[1, 0] * matrix[2, 2])) / determinant;
            inverse[1, 1] = ((matrix[0, 0] * matrix[2, 2]) - (matrix[0, 2] * matrix[2, 0])) / determinant;
            inverse[1, 2] = ((matrix[0, 2] * matrix[1, 0]) - (matrix[0, 0] * matrix[1, 2])) / determinant;

            inverse[2, 0] = ((matrix[1, 0] * matrix[2, 1]) - (matrix[1, 1] * matrix[2, 0])) / determinant;
            inverse[2, 1] = ((matrix[0, 1] * matrix[2, 0]) - (matrix[0, 0] * matrix[2, 1])) / determinant;
            inverse[2, 2] = ((matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0])) / determinant;

            return inverse;
        }

        public static void DisplayMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(Math.Round(matrix[i, j], 2) + "\t");
                }

                Console.WriteLine();
            }
        }
    }
}

