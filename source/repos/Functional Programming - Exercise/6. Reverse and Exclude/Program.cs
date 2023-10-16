List<int> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
int divider = int.Parse(Console.ReadLine());

Func<List<int>, List<int>> reverse = input =>
{
    List<int> result = new List<int>();

    for (int i = input.Count - 1; i >= 0; i--)
    {
        result.Add(input[i]);
    }
    return result;
};

Predicate<int> checkIsEven = number => number % divider == 0;

Func<List<int>, Predicate<int>, List<int>> exclude = (input, checkIsEven) =>
{
   List<int> result = new List<int>();

    foreach (int i in input)
    {
        if (!checkIsEven(i))
        {
            result.Add(i);
        }
      
    }
    return result;
};

input=exclude(input,checkIsEven);
input = reverse(input);

Console.WriteLine( string.Join(" ",input));