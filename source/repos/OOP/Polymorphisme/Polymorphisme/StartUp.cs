using Operations;
namespace Operations;

public class StartUp
{
    public static void Main()
    {
        MathOperations mathOperations = new MathOperations();
        Console.WriteLine(mathOperations.Add(23, 16));
        Console.WriteLine(mathOperations.Add(23.56, 234.12,86.77));
        Console.WriteLine(mathOperations.Add(23.42m, 16.635m, 732.23m));
    }
}