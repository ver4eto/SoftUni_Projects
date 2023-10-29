using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal cakePrice = 5;
        private const double cakeCalories = 1000;
        private const double cakeGrams = 250;

//        Grams = 250

//· Calories = 1000

//· CakePrice = 5
        public Cake(string name ) : base(name, cakePrice,cakeGrams, cakeCalories)
        {
            //price = cakePrice;
          //  grams=cakeGrams; 
            //calories=cakeCalories;
        }

        //public override double Grams { get => base.Grams; set => base.Grams = cakeGrams; }

        //public override decimal Price { get => base.Price; set => base.Price = cakePrice; }

        //public override double Calories { get => base.Calories; set => base.Calories = cakeCalories; }
    }
}
