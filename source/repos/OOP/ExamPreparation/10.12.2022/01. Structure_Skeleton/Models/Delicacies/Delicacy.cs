using ChristmasPastryShop.Models.Delicacies.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {
        private string name;
        private double price;

        protected Delicacy(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }
        public double Price
        {
            get { return price; }
            private set
            {
                price = value;
            }
        }

        public override string ToString()
        {
            //"{delicacyName} - {current price - formatted to the second decimal place} lv"
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Name} - {price:f2} lv");
            return sb.ToString().Trim();
        }
    }
}
