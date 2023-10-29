using SingleInheritance;

namespace Farm;

public class StartUp
{
    public static void Main(string[] args)
    {
        Puppy puppy = new Puppy();
        puppy.Bark();
        puppy.Eat();
        puppy.Weep();


    }
}

