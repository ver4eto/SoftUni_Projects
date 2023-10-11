using System.Runtime.CompilerServices;
using System;

namespace DefiningClasses;


public class StartUp
{
    static void Main(string[] args)
    {

        int count = int.Parse(Console.ReadLine());

        Family family = new Family();   

        for (int i = 0; i < count; i++)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string name = data[0];
            int age = int.Parse(data[1]);

            Person person = new Person(name,age);

            family.AddMember(person);
        }

        Person oldPerson = family.GetOldestMember();

        Console.WriteLine( $"{oldPerson.Name} {oldPerson.Age}");

        //Person peter = new();
        //Console.WriteLine($"{peter.Name} : {peter.Age}");

        //Person personGosho = new(34);
        //Console.WriteLine(  $"{personGosho.Name} -- {personGosho.Age}");

        //Person personIvan = new("ivan",17);
        //Console.WriteLine($"{personIvan.Name} -- {personIvan.Age}");
        //peter.Name = "Peter";
        //peter.Age = 20;

        //Person george = new();
        //peter.Name = "George";
        //peter.Age = 18;

    }

}
