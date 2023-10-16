using System.Diagnostics.Contracts;
using System.Globalization;

List<int> input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

string command;



Func<string, List<int>, List<int>> actionList = (action, input) =>
{
    List<int> result = new List<int>();

    foreach (var number in input)
    {
        switch (action)
        {
            case "add":
                result.Add(number+1);
                break;
            case "multiply":
                result.Add(number*2);
                break;
            case "subtract":
                result.Add(number - 1);
                break;
            default:
                break;
        }
    }

    return result;
};

Action<List<int>> print = input =>
Console.WriteLine(string.Join(" ", input));

while ((command = Console.ReadLine()) != "end")
{
    if (command =="print")
    {
        print(input); 
    }
    else
    {
       input = actionList(command, input);
    }    
}
