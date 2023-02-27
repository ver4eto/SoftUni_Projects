using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] secondArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int sum = 0;

            bool areIdentical = true;

            string areNotIdentical=string.Empty;

           
                if (firstArray.Length == secondArray.Length)
                {
                    for (int i = 0; i < firstArray.Length; i++)
                    {
                        if (firstArray[i] == secondArray[i])
                        {
                            sum += firstArray[i];
                        }
                        else
                        {
                            areIdentical = false;
                            areNotIdentical = $"Arrays are not identical. Found difference at {i} index";
                        break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Arrays are not identical.");
                }
            

            if (areIdentical)
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
            else
            {
                Console.WriteLine(areNotIdentical);
            }
        }
    }
}
