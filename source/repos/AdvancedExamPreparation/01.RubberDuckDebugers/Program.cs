using System;
using System.Text;

int[] timeInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[] taskInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
Queue<int> timeQueue = new Queue<int>(timeInput);
Stack<int> taskStack = new Stack<int>(taskInput);

//Queue<int> timeQueue = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
//Stack<int> taskStack = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

int dartVaderCount = 0;     //0 - 60
int thorCount = 0;     //61 – 120
int bigBlueRubberCount = 0;    //121 - 180
int smallYellowRubberCount = 0;    //181 - 240

while (timeQueue.Any() && taskStack.Any())    
{
    int currentTime = timeQueue.Dequeue();
    int currentTask = taskStack.Pop();

    int currentAmount = currentTask * currentTime;

    if (currentAmount > 240)
    {
        timeQueue.Enqueue(currentTime);
        currentTask -= 2;
        taskStack.Push(currentTask);
    }
    else if (currentAmount >=0 && currentAmount <= 60)
    {
        dartVaderCount++;
    }
    else if(currentAmount >60 && currentAmount <= 120)
    {
        thorCount++;
    }
    else if((currentAmount>120 && currentAmount <= 180))
    {
        bigBlueRubberCount++;
    }
    else if ((currentAmount>180 && currentAmount<= 240))
    {
        smallYellowRubberCount++;
    }
}

StringBuilder sb= new StringBuilder();
sb.AppendLine("Congratulations, all tasks have been completed! Rubber ducks rewarded:");
sb.AppendLine($"Darth Vader Ducky: {dartVaderCount}");
sb.AppendLine($"Thor Ducky: {thorCount}");
sb.AppendLine($"Big Blue Rubber Ducky: {bigBlueRubberCount}");
sb.AppendLine($"Small Yellow Rubber Ducky: {smallYellowRubberCount}");

Console.WriteLine(sb.ToString().TrimEnd());