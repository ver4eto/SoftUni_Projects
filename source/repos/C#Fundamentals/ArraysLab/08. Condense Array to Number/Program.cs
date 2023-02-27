using System;
using System.Linq;

namespace _08._Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();

            
            if (input.Length==1)
            {
                Console.WriteLine(input[0]);
                
            }
            else
            {
                int[] adjArray = new int[input.Length - 1];



                while (adjArray.Length >= 1)
                {
                    for (int i = 0; i < adjArray.Length; i++)
                    {
                        adjArray[i] = input[i] + input[i + 1];
                    }

                    input = adjArray;

                    if (adjArray.Length == 1)
                    {
                        break;
                    }

                    adjArray = new int[input.Length - 1];

                }



                Console.WriteLine(adjArray[0]);
            }

           
        
        }
    }
}
