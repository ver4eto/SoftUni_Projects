namespace PokemonTrainer;

public class StartUp
{
    public static void Main(string[] args)
    {
        List<Trainer> trainers = new List<Trainer>();

        string command;

        while ((command = Console.ReadLine()) != "Tournament")
        {
            string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string trainerName = data[0];
            string pokemonName = data[1];
            string element = data[2];
            int pokemonHealth = int.Parse(data[3]);

            Pokemon pokemon = new Pokemon(pokemonName, element, pokemonHealth);

            bool hasSuchTrainer = trainers.Any(t => t.HasSuchTrainer(trainerName));

            if (!hasSuchTrainer)
            {
                Trainer trainer = new Trainer(trainerName);
                trainers.Add(trainer);
                trainer.AddPokemon(pokemon);
            }
            else
            {
                Trainer currentTrainer = trainers.First(t => t.Name == trainerName);
                currentTrainer.AddPokemon(pokemon);
            }

        }

        while ((command = Console.ReadLine()) != "End")
        {
            bool hasSuchPokemon = trainers.Any(t => t.Pokemons.Any(p => p.Element == command));


            if (hasSuchPokemon)
            {
                Trainer currentTrainer = trainers.First(t => t.Pokemons.Any(t => t.Element == command));
                currentTrainer.AddBadge();
            }
            else
            {
                foreach (var trainer in trainers)
                {
                    trainer.PokemonsLooseHealth();
                    trainer.CheckPokemonsHealth();
                }
            }
        }

        foreach (var trainer in trainers.OrderByDescending(t => t.CountOfBadges))
        {
            Console.WriteLine(trainer.ToString().TrimEnd());
        }
    }
}