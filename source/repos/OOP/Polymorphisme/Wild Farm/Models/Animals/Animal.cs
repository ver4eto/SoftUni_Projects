using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Interfaces;

namespace Wild_Farm.Models.Animals
{
    public abstract class Animal : IAnimal
    {

        protected Animal(string name, double weght)
        {
            Name = name;
            Weight = weght;
            //FoodEaten = foodEaten;
        }
        public string Name { get; protected set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        protected abstract double WeightMultiplier { get; }
        protected abstract IReadOnlyCollection<Type> PreferedFood { get;  }

        public void Eat(IFood food)
        {
            if (!PreferedFood.Any(f=>food.GetType().Name==f.Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            Weight += food.Quantity * WeightMultiplier;
            FoodEaten += food.Quantity;
        }

        public virtual string ProduceSound()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name},";
        }
    }
}
