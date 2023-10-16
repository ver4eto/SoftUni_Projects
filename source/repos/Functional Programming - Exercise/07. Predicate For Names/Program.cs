int lenght = int.Parse(Console.ReadLine());
List<string> names = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToList();

Predicate<string> isLess = input=>  input.Length<= lenght;

Func<List<string>, Predicate<string>, List<string>> filteredNames = (names,isLess) => 
{
    List<string> list = new List<string>();

    foreach (string name in names) 
    {
        if (isLess(name))
        {
            list.Add(name);
        }
    }
    return list;
};

names = filteredNames(names,isLess);

Console.WriteLine( string.Join(Environment.NewLine,names));

