using System;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            char[,] matrix = new char[count, count];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            char symbolToFind =Console.ReadLine()[0];
            int[] symbolCoordinates = new int[2];
            bool isFound = false;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j]==symbolToFind)
                    {
                        symbolCoordinates[0] = i;
                        symbolCoordinates[1] = j;
                        isFound = true;
                        break;
                    }
                    if (isFound)
                    {
                        break;
                    }
                }
                if (isFound)
                {
                    break;
                }
            }
            string result = string.Empty;
            if (isFound)
            {
                result = $"({string.Join(", ", symbolCoordinates)})";
            }
            else
            {
                result = $"{symbolToFind} does not occur in the matrix";
            }
            Console.WriteLine(result);
        }
    }
}
