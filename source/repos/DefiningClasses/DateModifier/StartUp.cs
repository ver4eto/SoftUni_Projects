using System;

namespace DateModifier;

public class StartUp
{
    static void Main(string[] args)
    {
        string startDate = Console.ReadLine();
        string endDate = Console.ReadLine();

        int difference = DateModifier.GetDifferenceInDays(startDate,endDate);

        Console.WriteLine(difference);
    }

}