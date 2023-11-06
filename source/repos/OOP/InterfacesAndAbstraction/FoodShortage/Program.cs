using FoodShortage;

public class StartUp
{
    public static void Main()
    {
        List<Rebel> rebels = new List<Rebel>();
        List<Citizen> citizens = new List<Citizen>();

        int number = int.Parse(Console.ReadLine());

        for (int i = 0; i < number; i++)
        {
            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[0];
            int age = int.Parse(tokens[1]);

            if (tokens.Length==3)
            {
                
                Rebel rebel = new Rebel(name, age);
                rebels.Add(rebel);
              
            }
            else if(tokens.Length==4)
            {
                string id = tokens[2];
                string birthday = tokens[3];

                Citizen citizen = new Citizen(name, age, id, birthday);
                citizens.Add(citizen);
            }
        }

        string command = Console.ReadLine();

        while (true)
        {
         if (command == "End")
            {
                break;
            }
            string nameTofind = command;

            if (citizens.Any(c=>c.Name==nameTofind))
            {
                Citizen currentCitizen = citizens.Find(c => c.Name == nameTofind);
                currentCitizen.BuyFood();
            }
            if (rebels.Any(c => c.Name == nameTofind))
            {
                Rebel currentRebel = rebels.Find(r=>r.Name == nameTofind);
                currentRebel.BuyFood();
            }

            command = Console.ReadLine();
        }

        int sum = citizens.Sum(f => f.Food) + rebels.Sum(f => f.Food);
        Console.WriteLine(sum);
    }
}