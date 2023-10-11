using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int countOfBadges;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            this.Name = name;
            this.Pokemons = new List<Pokemon>();
            this.CountOfBadges = 0;
        }

        public string Name { get { return name; } set { this.name = value; } }
        public int CountOfBadges { get { return countOfBadges; } set { countOfBadges = value; } }
        public List<Pokemon> Pokemons { get { return pokemons; } set { pokemons = value; } }

        public void AddPokemon(Pokemon pokemon)
        {
            if (!this.Pokemons.Contains(pokemon))
            {
                this.Pokemons.Add(pokemon);
            }
        }

        public void AddBadge()
        {
            this.CountOfBadges++;
        }

        public void PokemonsLooseHealth()
        {
            foreach (var pokemon in Pokemons)
            {
                pokemon.Health -= 10;
            }
        }

        public void CheckPokemonsHealth()
        {
            if (this.Pokemons.Any(p => p.Health <= 0))
            {

                pokemons.RemoveAll(p => p.Health <= 0);


            }
        }

        public bool HasSuchTrainer(string name)
        {
            if (this.Name == name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{this.Name} {countOfBadges.ToString()} {this.Pokemons.Count.ToString()}");

            return stringBuilder.ToString();
        }
    }
}
