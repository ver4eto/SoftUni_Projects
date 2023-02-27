using System;

namespace ArraysLab
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int[] listOfNumbers = new int[number] ;

            for (int i = 0; i < number; i++)
            {
                listOfNumbers[i] = int.Parse(Console.ReadLine());
               
            }

            for (int i = number-1; i >= 0; i--)
            {
                Console.Write(listOfNumbers[i]+ " ");

            }

        }
    }
}
