using System;

namespace _1._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string[] daysOfWeek = new string [] { 
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
                    };

            if (number >0 && number <= 7)
            {
                Console.WriteLine(string.Join(" ",daysOfWeek[number - 1]));
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
