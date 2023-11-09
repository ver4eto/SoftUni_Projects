using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Factory.Interfaces;
using Wild_Farm.Models.Animals;
using Wild_Farm.Models.Interfaces;

namespace Wild_Farm.Factory
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal Create(string[] animalTokens)
        {
           // IAnimal animal = null;
            string type = animalTokens[0];
            string name = animalTokens[1];
            double weight = double.Parse(animalTokens[2]);

            switch (type) {
                case "Cat":
                   return new Cat(name, weight, animalTokens[3], animalTokens[4]); 
                case "Dog":
                    return new Dog(name, weight, animalTokens[3]);
                case "Owl":
                    return new Owl(name, weight, double.Parse(animalTokens[3]));
                case "Hen":
                    return new Hen(name, weight, double.Parse(animalTokens[3]));
                case "Mouse":
                    return new Mouse(name, weight, animalTokens[3]);
                case "Tiger":
                    return new Tiger(name, weight, animalTokens[3], animalTokens[4]);
                default:
                    throw new Exception();
            }
        }
    }
}
