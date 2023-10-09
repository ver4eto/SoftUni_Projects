namespace CustomStack;

public class StartUp
{
    public static void Main(string[] args)
    {
        CustomStack myStack = new CustomStack();

        //Console.WriteLine(myStack.Peek()); 
        myStack.Push(2);
        myStack.Push(7);
        myStack.Push(16);
        myStack.Push(43);
        myStack.Push(256);

        Console.WriteLine(myStack.Pop());
        Console.WriteLine(myStack.Pop());

        myStack.Push(77);
        myStack.Push(98);

        Console.WriteLine(myStack.Peek());

        myStack.ForEach(i=> 
        Console.Write(i + " "));

    }
}
