﻿using ChristmasPastryShop.Models.Cocktails.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        protected Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
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

        public string Size
        {
            get;
            private set;
        }


       public double Price
        {
            get
            {
               return price;
            }
            private set
            {
                if (Size == "Small")
                {
                    price = (1.0/ 3 * value);
                }
                if (Size == "Middle")
                {
                    price = (2.0 / 3 * value);
                }
               if(Size == "Large")
                {
                    price = value;
                }
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:F2} lv";
        }
    }
}
