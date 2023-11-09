using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Core.Interfaces;
using Wild_Farm.Factory.Interfaces;
using Wild_Farm.IO.Interfaces;
using Wild_Farm.Models.Interfaces;

namespace Wild_Farm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;

        private readonly ICollection<IAnimal> animals;

        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;

            animals = new List<IAnimal>();
        }
        public void Run()
        {
            string command;

            while ((command=reader.ReadLine())!="End")
            {
                IAnimal animal = null;
                try
                {
                    animal = CreateAnimal(command);
                    IFood food = CreateFood();
                    writer.WriteLine(animal.ProduceSound());
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {

                    writer.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {

                    writer.WriteLine(ex.Message);
                }
                animals.Add(animal);
            }

            foreach (IAnimal animal in animals)
            {
                Console.WriteLine(animal);
            }
        }

        private IFood CreateFood()
        {
            string[] foodTokens = reader.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            
            string type = foodTokens[0];
            int quantity = int.Parse(foodTokens[1]);

            IFood food = foodFactory.Create(foodTokens);
            return food;
        }

        private IAnimal CreateAnimal(string command)
        {
            string[] args = command.Split(' ');
            IAnimal animal=null;
            animal = animalFactory.Create(args);
            return animal;
        }
    }
}
