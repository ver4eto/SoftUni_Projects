using Cards;
using System.Net.Security;
using System.Text;

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

public class Card
{

    private readonly string[] validChars = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
    private readonly string[] validSuits = { "H", "C", "D", "S" };

    private string face;
    private string suit;

    public Card(string face, string suit)
    {
        Face = face;
        Suit = suit;

    }
    public string Face
    {
        get => this.face;
        private set
        {
            if (validChars.Contains(value))
            {

                this.face = value;
            }
            else
            {
                throw new ArgumentException("Invalid card!");

            }
        }

    }

    public string Suit
    {
        get { return suit; }
        private set
        {
            if (validSuits.Contains(value))
            {
                this.suit = value;
            }
            else
            {

                throw new ArgumentException("Invalid card!");
            }
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append($"[{Face}");
        switch (Suit)
        {
            case "H":
                sb.Append('\u2665'.ToString()); break;
            case "C":
                sb.Append('\u2663'.ToString()); break;
            case "D":
                sb.Append('\u2666'); break;
            case "S":
                sb.Append('\u2660'.ToString()); break;
            default:
                break;

        }
        sb.AppendLine("]");
        return sb.ToString().TrimEnd();
    }
}