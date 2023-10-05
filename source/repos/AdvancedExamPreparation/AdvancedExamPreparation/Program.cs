using System.Collections;
using System.Text;

Queue<int> monsters = new Queue<int>(Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

Stack<int> soldiers = new Stack<int>(Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

int killedMonstersCount = 0;

while (monsters.Count > 0 && soldiers.Count > 0)
{
    int currentMonster = monsters.Dequeue();
    int currentSoldierStrenght = soldiers.Peek();

    if (currentSoldierStrenght >= currentMonster)
    {
        killedMonstersCount++;

        //monsters.Dequeue();

        currentSoldierStrenght -= currentMonster; 
        
        soldiers.Pop();

        if (soldiers.Count > 0 && currentSoldierStrenght>0)
        {
            int lastSoldierStrenght = soldiers.Peek();
           // soldiers.Pop();
            soldiers.Push(lastSoldierStrenght + currentSoldierStrenght);
        }
       
    }
    else if (currentMonster > currentSoldierStrenght)
    {
        //soldiers.Pop();

        currentMonster -= currentSoldierStrenght;

        //monsters.Dequeue();

        if (monsters.Count>0)
        {
            monsters.Enqueue(currentMonster);
        }
        

    }
}
StringBuilder result = new StringBuilder();

if (monsters.Count == 0)
{
    result.AppendLine($"All monsters have been killed!");
}
else if (soldiers.Count == 0)
{
    result.AppendLine($"The soldier has been defeated.");
}

result.AppendLine($"Total monsters killed: {killedMonstersCount}");

Console.WriteLine(result.ToString().TrimEnd());
