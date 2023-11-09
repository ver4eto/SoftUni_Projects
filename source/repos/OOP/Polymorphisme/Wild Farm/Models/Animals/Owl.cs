using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Food;

namespace Wild_Farm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weght,  double wingSize) : base(name, weght,  wingSize)
        {
        }

        protected override double WeightMultiplier => 0.25;

        protected override IReadOnlyCollection<Type> PreferedFood => new HashSet<Type>() { typeof(Meat) };

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
