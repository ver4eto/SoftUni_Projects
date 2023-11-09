using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Interfaces;

namespace Wild_Farm.Models.Animals
{
    public abstract class Bird : Animal, IBird
    {
        protected Bird(string name, double weght,double wingSize) : base(name, weght)
        {
            WingSize = wingSize;
    
       }     
        public double WingSize { get;protected set; }

        public override string ToString()
        {
            return base.ToString()+$" {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
