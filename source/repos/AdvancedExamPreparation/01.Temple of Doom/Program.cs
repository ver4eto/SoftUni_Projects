using System.Diagnostics.SymbolStore;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Collections.Generic;
using System;

public class StartUp
{
    public static void Main(string[] args)
    {
        int[] toolsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        Queue<int> tools = new Queue<int>(toolsInput);

        int[] substancesInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        Stack<int> substances = new Stack<int>(substancesInput);

        List<int> challenges = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        bool hasPassesAllChallenges = false;

        while (hasPassesAllChallenges == false && tools.Count > 0 && substances.Count > 0)
        {
            int currentValue = MultiplyValues(tools, substances);
            bool isEqual = IsEqual(currentValue, challenges);

            if (isEqual)
            {
                tools.Dequeue();
                substances.Pop();
                challenges.Remove(currentValue);
            }
            else
            {
                int currentTool = tools.Peek();
                int currentSubstance = substances.Peek();

                IncreaseToolValue(currentTool, tools);
                DecreaseSubstanceValue(currentSubstance, substances);
            }

            if (challenges.Count <= 0)
            {
                hasPassesAllChallenges = true;
            }
        }


        StringBuilder result = new StringBuilder();

        if (hasPassesAllChallenges)
        {
            result.AppendLine("Harry found an ostracon, which is dated to the 6th century BCE.");
        }
        else
        {
            result.AppendLine("Harry is lost in the temple. Oblivion awaits him.");
        }

        if (tools.Count > 0)
        {
            result.AppendLine($"Tools: {string.Join(", ", tools)}");
        }
        if (substances.Count > 0)
        {
            result.AppendLine($"Substances: {string.Join(", ", substances)}");
        }
        if (challenges.Count > 0)
        {
            result.AppendLine($"Challenges: {string.Join(", ", challenges)}");
        }

        Console.WriteLine(result.ToString().TrimEnd());
    }


    private static void DecreaseSubstanceValue(int currentSubstance, Stack<int> substances)
    {
        substances.Pop();
        if (currentSubstance - 1 > 0)
        {
            substances.Push(currentSubstance - 1);
        }
    }

 private static   void IncreaseToolValue(int currentTool, Queue<int> tools)
    {
        tools.Dequeue();
        tools.Enqueue(currentTool + 1);
    }

   private static bool IsEqual(int currentValue, List<int> challenges)
    {
        if (challenges.Contains(currentValue))
        {
            return true;
        }
        return false;
    }

  private static  int MultiplyValues(Queue<int> tools, Stack<int> substances)
    {
        int currentTool = tools.Peek();
        int currentSubstance = substances.Peek();

        return currentTool * currentSubstance;
    }

}