using System.Text;

Queue<int> textiles = new Queue<int> (Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

Stack<int> medicaments = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

Dictionary<string,int> repairValue = new Dictionary<string,int>();
int patchCount = 0;   //30
int bandageCount = 0; //40
int medKitCount = 0;  //100

while (textiles.Any() && medicaments.Any())
{
    int currentTextile = textiles.Dequeue();
    int currentMedicaments = medicaments.Pop();

    int sum = currentMedicaments + currentTextile;

    if (sum == 30)
    {
        if (!repairValue.ContainsKey("Patch"))
        {
            repairValue.Add("Patch",0);
        }
        repairValue["Patch"]++;
    }
    else if(sum == 40)
    {
        if (!repairValue.ContainsKey("Bandage"))
        {
            repairValue.Add("Bandage", 0);
        }
        repairValue["Bandage"]++;
    }
    else if(sum == 100)
    {
        if (!repairValue.ContainsKey("MedKit"))
        {
            repairValue.Add("MedKit", 0);
        }
        repairValue["MedKit"]++;
    }
    else if(sum > 100)
    {
        if (!repairValue.ContainsKey("MedKit"))
        {
            repairValue.Add("MedKit", 0);
        }
        repairValue["MedKit"] ++;
        sum -= 100;
        currentMedicaments = medicaments.Pop() + sum;
        medicaments.Push(currentMedicaments);
    }
    else
    {
        currentMedicaments += 10;
        medicaments.Push(currentMedicaments);
    }
}

StringBuilder sb =new StringBuilder();

if (textiles.Count==0 && medicaments.Any())
{
    sb.AppendLine("Textiles are empty.");
}
if (medicaments.Count == 0 && textiles.Any())
{
    sb.AppendLine("Medicaments are empty.");
}
if(textiles.Count == 0 && medicaments.Count == 0)
{
    sb.AppendLine("Textiles and medicaments are both empty.");
}

foreach (var kvp in repairValue.OrderByDescending(r=>r.Value).ThenBy(p=>p.Key).Where(c=>c.Value>0))
{
    sb.AppendLine($"{kvp.Key} - {kvp.Value}");
}

if (medicaments.Any())
{
    sb.AppendLine($"Medicaments left: {string.Join(", ",medicaments)}");
}
if (textiles.Any())
{
    sb.AppendLine($"Textiles left: {string.Join(", ", textiles)}");
}

Console.WriteLine(sb.ToString().TrimEnd());
