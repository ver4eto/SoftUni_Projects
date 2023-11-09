using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Interfaces;

namespace Wild_Farm.Models.Food
{
    public abstract class Food : IFood
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }
        public int Quantity { get; protected set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
