﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    public class Pokemon
    {
        private string name;
        private string element;
        private int health;

        public Pokemon(string name, string element, int health)
        {
            this.Name = name;   
            this.Element = element;
            this.Health = health;
        }

        public string Name {  get { return name; } set { this.name = value; } }
        public string Element { get { return element; } set { this.element = value; } }
        public int Health { get { return health; } set { health = value; } }

       
    }
}