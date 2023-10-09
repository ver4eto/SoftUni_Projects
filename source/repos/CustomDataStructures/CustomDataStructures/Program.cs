
using CustomDataStructures;

namespace CustomDataStructures;


public class StartUp
{
    public static void Main(string[] args)
    {
        CustomList myList = new();

        myList.Add(111);
        myList.Add(222);
        myList.Add(333);
        myList.Add(444);
        myList.Add(555);

        myList[2] = 22;

        myList.AddRange(new int[] { 6, 9, 27 });

        Console.WriteLine(myList.RemoveAt(4));
        Console.WriteLine(myList.RemoveAt(6));
        Console.WriteLine(myList.RemoveAt(1));
        Console.WriteLine(myList.RemoveAt(1));
        Console.WriteLine(myList.RemoveAt(1));
        Console.WriteLine(myList.RemoveAt(0));

        Console.WriteLine(  );
        Console.WriteLine(myList.Contains(22));
        Console.WriteLine(myList.Contains(876));

        myList.InsertAt(0, 152);
        myList.InsertAt(3,39);
       // myList.InsertAt(10,2);

        myList.Swap(1,3);

        Console.WriteLine(myList.Count);
    }
    
}
 
       
    


