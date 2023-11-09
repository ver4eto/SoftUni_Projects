using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Interfaces;

namespace Wild_Farm.Models.Animals
{
    public abstract class Feline : Mammal, IFeline
    {
        protected Feline(string name, double weght,  string livingRegion, string breed) : base(name, weght,  livingRegion)
        {
            Breed = breed;
        }

        public string Breed {  get; protected set; }

        public override string ToString()
        {
            return base.ToString()+$" {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
