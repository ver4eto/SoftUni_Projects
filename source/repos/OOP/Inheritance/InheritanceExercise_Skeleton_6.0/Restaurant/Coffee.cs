using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    
    public class Coffee : HotBeverage
    {
        private const decimal CoffeePrice = 3.50m;
        private const double CoffeeMilliliters = 50;
        public Coffee(string name,  double caffeine) : base(name, CoffeePrice, CoffeeMilliliters) 
        {
           // price = CoffeePrice;
           // millilitres = CoffeeMilliliters;
            Caffeine = caffeine;
        }

        public double Caffeine {  get; set; }
        //public override double Milliliters { get => base.Milliliters; set => base.Milliliters = CoffeeMilliliters; }
        //public override decimal Price { get => base.Price; set => base.Price = CoffeePrice; }

    }
}
