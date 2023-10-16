int[] range = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

string condition = Console.ReadLine();


Func<int[], List<int>> allNumbers = range =>
{
    List<int> numbers = new List<int>();

    for (int i = range[0]; i <= range[1]; i++)
    {
        numbers.Add(i);
    }
    return numbers;
};

List<int> numbers = allNumbers(range);

Func<string, int, bool> evenOrOddMatch = (condition, i) =>
{
    if (condition == "even")
    {
        return (i % 2 == 0);
    }
    else
    {
        return (i % 2 != 0);
    }
};


foreach (var number in numbers)
{
    if (evenOrOddMatch(condition,number))
    {
        Console.Write($"{number} " );
    }
}