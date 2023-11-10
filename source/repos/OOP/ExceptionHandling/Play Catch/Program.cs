using System.Collections;
using System.Collections.Generic;
using System.Threading.Channels;

public class StartUp
{
    public static void Main()
    {
        List<int> numbers = new List<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

        int countException = 0;

        while (countException < 3)
        {
            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = tokens[0];

            try
            {
            int startIndex = int.Parse(tokens[1]);
                switch (command)
                {
                    case "Replace":
                        int replacedNumber = int.Parse(tokens[2]);
                        numbers.RemoveAt(startIndex);
                        numbers.Insert(startIndex, replacedNumber);
                        break;
                    case "Show":
                        Console.WriteLine(numbers[startIndex]);
                        break;
                    case "Print":
                        int endIndex = int.Parse(tokens[2]);
                        int count=endIndex - startIndex+1;

                        //for (int i = startIndex; i <= count; i++)
                        //{
                        //    if (i==count)
                        //    {
                        //        Console.WriteLine($"{numbers[i]}");
                        //    }
                        //    else
                        //    {
                        //    Console.Write($"{numbers[i]}, ");

                        //    }
                        //}
                        //Console.WriteLine();
                        Console.WriteLine(string.Join(", ", numbers.GetRange(startIndex, count)/*, startIndex, count*/));


                        break;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("The index does not exist!");
                countException++;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The index does not exist!");
                countException++;
            }
            catch (FormatException)
            {
                Console.WriteLine("The variable is not in the correct format!");
                countException++;
            }

        }

        Console.WriteLine(string.Join(", ", numbers));

    }
}