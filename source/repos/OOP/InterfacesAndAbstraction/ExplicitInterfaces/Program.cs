using ExplicitInterfaces;

string command = Console.ReadLine();

while (command != "End")
{
    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string name = tokens[0];
    string country = tokens[1];
    int age = int.Parse(tokens[2]);

    Citizen citizen = new Citizen(name, country, age);
    Console.WriteLine(((IPerson)citizen).GetName());
    Console.WriteLine(((IResident)citizen).GetName());
    command = Console.ReadLine();
}