using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Fish : MainDish
    {
        private const double fishGrams = 22;
        public Fish(string name, decimal price) : base(name, price, fishGrams)
        {
           
        }

        //public override double Grams { get => base.Grams; set => base.Grams = fishGrams; }
    }
}
