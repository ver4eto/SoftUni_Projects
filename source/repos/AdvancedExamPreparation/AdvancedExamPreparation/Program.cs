using System.Collections;
using System.Text;

int [] inputMonster = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

int[] inputSoldier = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();


Queue<int> monsters = new Queue<int>(inputMonster);

Stack<int> soldiers = new Stack<int>(inputSoldier);

int killedMonstersCount = 0;

while (monsters.Any()  && soldiers.Any())
{
    int currentMonster = monsters.Dequeue();
    int currentSoldierStrenght = soldiers.Pop();

    if (currentSoldierStrenght >= currentMonster)
    {
        killedMonstersCount++;
        currentSoldierStrenght -= currentMonster;        
       // soldiers.Pop();
       if (soldiers.Any())
        {
            int nextStrike = soldiers.Pop();
            nextStrike += currentSoldierStrenght;
            soldiers.Push(nextStrike);
        }
       else if (currentSoldierStrenght>0)
        {
          
            soldiers.Push(currentSoldierStrenght);
        }
       
    }
    else 
    {
        //soldiers.Pop();

        currentMonster -= currentSoldierStrenght;

        //monsters.Dequeue();

            monsters.Enqueue(currentMonster);
        
        

    }
}
StringBuilder result = new StringBuilder();

if (monsters.Count == 0)
{
    result.AppendLine($"All monsters have been killed!");
}
if (soldiers.Count == 0)
{
    result.AppendLine($"The soldier has been defeated!");
}

result.AppendLine($"Total monsters killed: {killedMonstersCount}");

Console.WriteLine(result.ToString().TrimEnd());
