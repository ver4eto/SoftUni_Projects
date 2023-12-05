﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class Hibernation : Cocktail
    {
        private const double hibernationPrice = 10.50;
        public Hibernation(string name, string size) : base(name, size, hibernationPrice)
        {
        }
    }
}
