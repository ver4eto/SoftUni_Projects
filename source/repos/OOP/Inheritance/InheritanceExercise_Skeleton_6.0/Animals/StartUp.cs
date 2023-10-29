using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();

          
            while (command != "Beast!")
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = command;
                string name = data[0];
                int age = int.Parse(data[1]);
                string gender = data[2];

                Console.WriteLine(type);
                try
                {
                    switch (type)
                    {
                        case "Cat":
                            Cat cat = new(name, age, gender);
                            Console.WriteLine(cat.ToString());
                            Console.WriteLine(cat.ProduceSound()); 
                            break;

                        case "Dog":
                            Dog dog = new(name, age, gender);
                            Console.WriteLine(dog.ToString());
                            Console.WriteLine(dog.ProduceSound()); 
                            break;

                        case "Frog":
                            Frog frog = new(name, age, gender);
                            Console.WriteLine(frog.ToString());
                            Console.WriteLine(frog.ProduceSound());
                            break;

                        case "Kitten":
                            Kitten kitten = new(name, age);
                            Console.WriteLine(kitten.ToString());
                            Console.WriteLine(kitten.ProduceSound());
                            break;

                        case "Tomcat":
                            Tomcat tomcat = new(name, age);
                            Console.WriteLine(tomcat.ToString());
                            Console.WriteLine(tomcat.ProduceSound());
                            break;

                        default: break;
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                
                command = Console.ReadLine();
            }
        }
    }
}
