string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Action<string[],string> print = (currentInput, command) =>
{
    foreach (var name in input) 
    {
        Console.WriteLine($"{command} {name}");
    }
};

print(input,"Sir");