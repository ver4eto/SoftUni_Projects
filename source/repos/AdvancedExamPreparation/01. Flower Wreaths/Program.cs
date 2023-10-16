using System.Security.Cryptography.X509Certificates;
using System.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


public class StartUp
{
    public static void  Main(char[] args)
    {
        int[] inputLilies = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int[] inputRoses = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        int wreathsCount = 0;
        int minWreaths = 5;
        int neededSum = 15;
        int storedFlowersSum = 0;

        Stack<int> lilies = new Stack<int>(inputLilies);
        Queue<int> roses = new Queue<int>(inputRoses);

        while (true)
        {
            int currentLily = lilies.Peek();
            int currentRose = roses.Peek();
            bool isReady = IsWreathReady(wreathsCount);

            if (currentLily + currentRose == neededSum)
            {
                wreathsCount++;
                lilies.Pop();
                roses.Dequeue();
                
            }
            else if (currentLily + currentRose > neededSum)
            {
                lilies.Pop();
                currentLily -= 2;
                lilies.Push(currentLily);
            }
            else if(currentLily + currentRose < 15)
            {
                storedFlowersSum += currentLily;
                lilies.Pop();

                storedFlowersSum += currentRose;
                roses.Dequeue();
            }

            if (isReady || lilies.Count==0 || roses.Count ==0)
            {
                break;
            };
        }

        StringBuilder result = new StringBuilder();

        if (wreathsCount==5)
        {
            result.AppendLine("You made it, you are going to the competition with 5 wreaths!");
        }
        else
        {
            
                while (storedFlowersSum >=15)
                {
                    storedFlowersSum -= 15;
                    wreathsCount++;
                }

                int neededMoreWreaths = minWreaths - wreathsCount;
            result.AppendLine($"You didn't make it, you need {neededMoreWreaths} wreaths more!");
        }

        Console.WriteLine(result.ToString().TrimEnd());
    }

    private static bool IsWreathReady(int wreathsCount)
    {
        
            if (wreathsCount == 5)
                return true;
            else
                return false;
        
    }
}

