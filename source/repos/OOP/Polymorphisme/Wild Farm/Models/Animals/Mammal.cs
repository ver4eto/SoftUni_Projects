using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Interfaces;

namespace Wild_Farm.Models.Animals
{
    public abstract class Mammal : Animal , IMammal
    {
        protected Mammal(string name, double weght,  string livingRegion) : base(name, weght)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; protected set; }
    }
}
