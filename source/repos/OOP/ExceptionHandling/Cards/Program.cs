using Cards;
using System.Net.Security;

public class StartUp
{
    public static void Main()
    {
        List<Card> cards = new List<Card>();
       
        string[] input = Console.ReadLine().Split(
            new string[]{","," "},StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < input.Length; i+=2)
        {
            try
            {
                string face = input[i];
                string suit = input[i + 1];
                Card card = new Card(face, suit);
                cards.Add(card);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            
        }

        foreach (Card card in cards)
        {
            Console.Write($"{card.ToString()} ");
        }
    }
}