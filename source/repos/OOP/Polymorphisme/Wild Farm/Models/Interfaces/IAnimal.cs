using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Farm.Models.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight {  get; }
        int FoodEaten { get; }

        string ProduceSound();

        void Eat(IFood food);
    }
}
