using System;
using System.Linq;

namespace _3._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            int[] newNumbers = new int[input.Length];


            for (int i = 0; i < input.Length; i++)
            {
                newNumbers[i] =(int) Math.Round(input[i], MidpointRounding.AwayFromZero);

            }

            for (int i = 0; i < newNumbers.Length; i++)
            {
                Console.WriteLine(input[i] + " => "+ newNumbers[i]);
            }
        }
    }
}
