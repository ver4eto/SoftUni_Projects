namespace CustomDataQueue;
using CustomDataQueue;

public class StartUp
{
    public static void Main(string[] args)
    {
        CustomQueue myQueue = new ();

        myQueue.Enqueue(10);
        myQueue.Enqueue(22);
        myQueue.Enqueue(36);
        myQueue.Enqueue(42);
        myQueue.Enqueue(51);

        myQueue.Dequeue();
       // myQueue.Dequeue();
        //myQueue.Dequeue();
        //myQueue.Dequeue();

        Console.WriteLine(myQueue.Peek());

        myQueue.ForEach(
            x => 
            Console.Write($"{x} "));

        Console.WriteLine();

        myQueue.Clear();
        Console.WriteLine(myQueue.Count);

        myQueue.ForEach(
            x => 
        Console.Write($"{x} "));

        Console.WriteLine(  );

        Console.WriteLine(myQueue.Count);

    }
}