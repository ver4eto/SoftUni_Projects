using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Food;

namespace Wild_Farm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weght,  string livingRegion) : base(name, weght,  livingRegion)
        {
        }

        protected override double WeightMultiplier => 0.10;

        protected override IReadOnlyCollection<Type> PreferedFood => new HashSet<Type>() { typeof(Vegetable), typeof(Fruit) };

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
