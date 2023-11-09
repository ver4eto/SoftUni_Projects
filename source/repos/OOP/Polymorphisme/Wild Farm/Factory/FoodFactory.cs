using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Factory.Interfaces;
using Wild_Farm.Models.Food;
using Wild_Farm.Models.Interfaces;

namespace Wild_Farm.Factory
{
    public class FoodFactory : IFoodFactory
    {
        public IFood Create(string[] foodTokens)
        {
            string type = foodTokens[0];
            int quantity = int.Parse(foodTokens[1]);

            switch (type)
            {
                case "Fruit":
                    return new Fruit(quantity);
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Meat":
                    return new Meat(quantity);
                case "Seeds":
                    return new Seeds(quantity);
                default:
                    throw new Exception();
            }
        }
    }
}
