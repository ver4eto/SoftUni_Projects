using System.Text;

Stack<int> initialFuel = new Stack<int> (Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

Queue<int> additionalConsumption = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

Queue<int> neededFuel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

List<int> countOfReachedAtt = new List<int>();
bool hasStop = false; ;

while (initialFuel.Any() && additionalConsumption.Any() && hasStop==false) 
{
    int fuel = initialFuel.Pop();
    int consuption=additionalConsumption.Dequeue(); ;
    int currentNeededFuel = neededFuel.Dequeue();
    int count=0;
    if (fuel-consuption >= currentNeededFuel)
    {
        count++;
        countOfReachedAtt.Add(count);
        Console.WriteLine($"John has reached: Altitude {countOfReachedAtt.Count}");
    }
    else
    {
        int notReachedAtt = countOfReachedAtt.Count+ 1;
        Console.WriteLine($"John did not reach: Altitude {notReachedAtt}");
        hasStop = true;
        break;
    }
}

StringBuilder sb=new StringBuilder();

if (hasStop && countOfReachedAtt.Count>0)
{
    sb.AppendLine("John failed to reach the top.");
    sb.Append("Reached altitudes: ");
    for (int i = 1; i <= countOfReachedAtt.Count; i++)
    {
        sb.Append($"Altitude ");
        if (i ==countOfReachedAtt.Count)
        {
            sb.Append($"{i}");
        }
        else
        {
            sb.Append($"{i}, ");
        }
    }

    //sb.AppendLine($"Altitude {string.Join(", ", countOfReachedAtt)}");
}
else if (!hasStop)
{
    sb.AppendLine("John has reached all the altitudes and managed to reach the top!");
}
else if (hasStop && countOfReachedAtt.Count ==0)
{
    sb.AppendLine("John failed to reach the top.");
    sb.AppendLine("John didn't reach any altitude.");
}

Console.WriteLine(sb.ToString().TrimEnd());