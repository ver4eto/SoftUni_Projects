using System;
using System.Runtime.CompilerServices;

namespace OpinionPoll;
public class StartUp
{
    static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());
        List<Person> personOver30 = new List<Person>();

        for (int i = 0; i < count; i++)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = data[0];
            int age = int.Parse(data[1]);
            Person person = new Person(name,age);
            if (age>= 30)
            {
                personOver30.Add(person);
            }
        }

        foreach (var person in personOver30.OrderBy(p=>p.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}
