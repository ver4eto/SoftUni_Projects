using MilitaryElite;
using MilitaryElite.Enums;

public class StartUp
{
    public static void Main()
    {
       Dictionary<int,ISoldier> soldiers = new Dictionary<int, ISoldier>();

        try
        {
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string typeOfSoldier = tokens[0];
                int ID = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];
                decimal salary = decimal.Parse(tokens[4]);
                ISoldier soldier = null;

                switch (typeOfSoldier)
                {
                    case "Private":
                        ISoldier currentPrivate = CreatePrivate(ID, firstName, lastName, salary);
                        soldier = currentPrivate;
                        break;
                    case "Commando":
                        ISoldier commando = CreateCommando(ID, firstName, lastName, salary, tokens);
                        soldier = commando;
                        break;
                    case "LieutenantGeneral":
                        ISoldier lieutenant = CreateLieutenant(ID, firstName, lastName, salary, tokens, soldiers);
                        soldier = lieutenant;
                        break;
                    case "Engineer":
                        ISoldier engineer = CreateEngineer(ID, firstName, lastName, salary, tokens);
                        soldier = engineer;
                        break;
                    case "Spy":
                        int codeNumber = int.Parse(tokens[4]);
                        ISoldier spy = CreateSpy(ID, firstName, lastName, salary, codeNumber);
                        soldier= spy;
                        break;

                }

                soldiers.Add(ID, soldier);
                Console.WriteLine(soldier.ToString());
                command = Console.ReadLine();
            }
        }
        catch (Exception ex)
        {

            
        }
        
    }

    private static ISoldier CreateSpy(int iD, string firstName, string lastName, decimal salary, int codeNumber)
    {
        Spy spy = new Spy(iD, firstName, lastName, codeNumber);
        return spy;
    }

    private static ISoldier CreateEngineer(int iD, string firstName, string lastName, decimal salary, string[] tokens)
    {
        
        bool isValidCorps = Enum.TryParse(tokens[5], out Corps corps);

        if (!isValidCorps)
        {
            throw new Exception();
        }

        List<Repair> repairs = new List<Repair>();

         for (int i = 6; i < tokens.Length; i+=2)
        {
            string repairPart = tokens[i];
            int hoursWorked = int.Parse(tokens[i + 1]);

            Repair repair = new Repair(repairPart, hoursWorked);
            repairs.Add(repair);
        }

        Engineer engineer = new Engineer(iD, firstName, lastName, salary,corps, repairs);
        return engineer;

    }

    private static LieutenantGeneral CreateLieutenant(int iD, string firstName, string lastName, decimal salary, string[] tokens, Dictionary<int,  ISoldier> soldiers)
    {
        List<IPrivate> privates = new List<IPrivate>();

        for (int i = 5; i < tokens.Length; i++)
        {
            int soldierId = int.Parse(tokens[i]);
            IPrivate soldier = (IPrivate)soldiers[soldierId];

            privates.Add(soldier);
        }
        LieutenantGeneral general = new LieutenantGeneral(iD, firstName, lastName, salary, privates);
        return general;
    }

    private static Commando CreateCommando(int iD, string firstName, string lastName, decimal salary, string[]tokens)
    {
        bool isValidCorps = Enum.TryParse(tokens[5], out Corps corps);
        if (!isValidCorps)
        {
            throw new Exception();
        }
        List<Mission> missions = new List<Mission>();
        for (int i = 6; i < tokens.Length; i+=2)
        {
            string missionName = tokens[i];
            string missionState = tokens[i+1];

            bool isValidState = Enum.TryParse(missionState, out State state);

            if (!isValidState)
            {
                continue;
            }
            Mission mission = new Mission(missionName, state);
            missions.Add(mission);
        }
        Commando commando=new Commando(iD, firstName, lastName, salary, corps,missions);

        return commando;
    }

    private static Private CreatePrivate(int iD, string firstName, string lastName, decimal salary)
    {
        Private currentSoldier = new Private(iD,firstName, lastName, salary);
        return currentSoldier;
    }
}