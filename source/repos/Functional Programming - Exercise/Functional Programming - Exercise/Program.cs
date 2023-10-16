string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

Action<string[]> print = currentInput => 
Console.WriteLine(string.Join(Environment.NewLine, currentInput));

print(input);