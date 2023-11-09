using Animals;

public class StartUp
{
    public static void Main()
    {
        Animal dog = new Dog("Pesho", "PedigreePaw");
        Animal cat = new Cat("Misha", "Whiskas");
        Console.WriteLine(dog.ExplainSelf());
        Console.WriteLine(cat.ExplainSelf());
    }
}