using System;
using System.Linq;

namespace Multidimensional_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputData = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = inputData[0];
            int cols = inputData[1];
            int sum = 0;

            int[,] matrix = new int[rows,cols];

            for (int i = 0; i < rows; i++)
            {
                int[] currentCol = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i,j] = currentCol[j];
                    sum += matrix[i,j];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));

            Console.WriteLine(sum);        
        }
    }
}
