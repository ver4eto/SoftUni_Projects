using BorderControl;
using System.Data;

public class StartUp
{
    public static void Main()
    {
        List<Robot> robots = new List<Robot>();
        List<Citizen> citizens = new List<Citizen>();
        List<Pet> pets = new List<Pet>();

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string typeOfPerson = tokens[0];
            string nameOrModel = tokens[1];
            switch (typeOfPerson)
            {
                case "Citizen":
                    int age = int.Parse(tokens[2]);
                    string id = tokens[3];
                    string birthday = tokens[4];
                    Citizen citizen = new Citizen(nameOrModel, age, id, birthday);
                    citizens.Add(citizen);
                    break;
                case "Pet":
                    birthday = tokens[2];
                    Pet pet = new Pet(nameOrModel, birthday);
                    pets.Add(pet);
                    break;
                case "Robot":
                    id = tokens[2];
                    Robot robot = new Robot(nameOrModel, id);
                    robots.Add(robot);
                    break;
            }


        }

        string birthdayToFind = Console.ReadLine();
        bool hasPetWithBirthDay = pets.Any(p => p.Birthdate.EndsWith( birthdayToFind));

        bool hasCitizenWithBirthday = citizens.Any(c => c.Birthdate.EndsWith(birthdayToFind));

        if (hasCitizenWithBirthday && citizens.Count>0)
        {
            foreach (Citizen citizen in citizens.Where(c => c.Birthdate.EndsWith(birthdayToFind)))
            {
                Console.WriteLine(citizen.ToString());
            }
        }

        if (hasPetWithBirthDay && pets.Count>0)
        {
            foreach (Pet pet in pets.Where(r => r.Birthdate.EndsWith(birthdayToFind)))
            {
                Console.WriteLine(pet.ToString());
            }
        }   

        


    }
}