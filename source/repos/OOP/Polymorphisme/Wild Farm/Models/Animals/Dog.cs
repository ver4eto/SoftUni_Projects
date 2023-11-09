using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Food;

namespace Wild_Farm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weght, string livingRegion) : base(name, weght, livingRegion)
        {
        }

        protected override double WeightMultiplier => 0.40;

        protected override IReadOnlyCollection<Type> PreferedFood => new HashSet<Type>() { typeof(Meat) };

        public override string ProduceSound()
        {
            return "Woof!";
        }
        public override string ToString()
        {
            return base.ToString()+$" {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
