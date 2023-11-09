using Raiding.Factories;
using Raiding.Models;

public class StartUp
{
    public static void Main()
    {
        int count = int.Parse(Console.ReadLine()); 
        ICollection<IHero> heroes = new List<IHero>();

        try 
        {
            for (int i = 0; i < count; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {
                    HeroFactory factory = new HeroFactory();
                    IHero hero = factory.CreateHero(type, name);
                    heroes.Add(hero);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                
                //Console.WriteLine(hero.CastAbility());
            }

            foreach (IHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int bossPower = int.Parse(Console.ReadLine());

            int powerSumPower = heroes.Sum(h => h.Power);

            if (powerSumPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        
    }
}
     