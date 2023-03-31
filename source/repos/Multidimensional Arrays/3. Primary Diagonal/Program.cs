using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int data = int.Parse(Console.ReadLine());

            int[,] matrix = new int[data, data];
            int primaryDiagonalSum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int j  = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];

                    if (i==j)
                    {
                        primaryDiagonalSum += matrix[i, j];
                    }
                }
            }
            Console.WriteLine(primaryDiagonalSum);
        }
    }
}
