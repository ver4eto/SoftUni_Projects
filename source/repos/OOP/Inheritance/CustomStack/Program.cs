namespace CustomStack;

public class StartUp
{
    public static void Main(string[] args)
    {
       StackOfStrings stackOfStrings = new StackOfStrings();

        Console.WriteLine(stackOfStrings.IsEmpty());
        stackOfStrings.Push("djdhi");
        stackOfStrings.Push("9");
        stackOfStrings.Push("gb");
        stackOfStrings.Push("093");
        stackOfStrings.Push("ASHD");
        stackOfStrings.Push("13");

        stackOfStrings.AddRange(stackOfStrings.ToArray());
        Console.WriteLine(stackOfStrings.IsEmpty());
    }
}