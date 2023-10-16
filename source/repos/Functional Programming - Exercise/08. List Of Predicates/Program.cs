int endOfRange = int.Parse(Console.ReadLine());

HashSet<int> dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();

List<Predicate<int>> predicates = new List<Predicate<int>>();

int[] numbers = Enumerable.Range(1, endOfRange).ToArray();

foreach (int divider in dividers)
{
    predicates.Add(n=>
    n % divider == 0);
}

foreach (int number in numbers)
{
    bool isDivisibe = true;
    foreach (var match in predicates)
    {
        if (!match(number))
        {
            isDivisibe = false; 
            break;
        }
    }
    if (isDivisibe)
    {
        Console.Write($"{number} ");
    }
}

