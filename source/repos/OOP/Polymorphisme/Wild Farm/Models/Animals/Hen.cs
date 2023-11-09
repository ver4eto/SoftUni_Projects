using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Food;
using Wild_Farm.Models.Interfaces;

namespace Wild_Farm.Models.Animals
{
    public class Hen : Bird
    {

        //Hens eat everything

        public Hen(string name, double weght,  double wingSize) : base(name, weght,  wingSize)
        {
        }

        protected override double WeightMultiplier => 0.35;

        protected override IReadOnlyCollection<Type> PreferedFood =>
            new HashSet<Type>() { 
                typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) 
            };

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
