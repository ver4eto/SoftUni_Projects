using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage
{
    public class Rebel : IPerson, IBuyer
    {
        public Rebel(string name, int age)
        {
            Name = name;
            Age = age;
            Food = 0;
        }
        public string Name { get ; set ; }
        public int Age { get ; set ; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += 5;
        }
    }
}
