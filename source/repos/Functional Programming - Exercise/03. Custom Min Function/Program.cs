HashSet<int> input = Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToHashSet();

Func<HashSet<int>, int> printSmallest = input =>
{

    int min = int.MaxValue; 

    foreach (int i in input)
    {
        if (i < min) min = i;
    }
    return min;
};

Console.WriteLine( printSmallest(input));