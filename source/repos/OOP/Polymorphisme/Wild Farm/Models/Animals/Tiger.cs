using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Food;

namespace Wild_Farm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weght,  string livingRegion, string breed) : base(name, weght, livingRegion, breed)
        {
        }

        protected override double WeightMultiplier => 1;

        protected override IReadOnlyCollection<Type> PreferedFood => new HashSet<Type>() { typeof(Meat)};

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
