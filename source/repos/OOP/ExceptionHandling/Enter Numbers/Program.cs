using System.Linq;
using System.Text;

public class StartUp
{
   public static void Main()
    {
        int [] print = ReadNumbers(1, 100);
        Console.WriteLine(string.Join( ", ",print));
    }

    private static int[] ReadNumbers(int start, int end)
    {
        int[] numbers = new int[10];
        for (int i = 0; i < 10; i++)
        {
            try
            {
                string currentInput = Console.ReadLine();
                if (int.TryParse(currentInput, out int result))
                {
                    numbers[i] = result;
                    if (result <= start || result >= end)
                    {
                        
                        i--;
                        throw new FormatException($"Your number is not in range {start} - {end}!");
                    }

                }
                else
                {
                    i--;
                    throw new ArgumentException("Invalid Number!");
                }
            }
            catch (FormatException aoe)
            {
                Console.WriteLine(aoe.Message);
            }
            catch (ArgumentException ae)
            {

                Console.WriteLine(ae.Message);
            }

        }

        return numbers;
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


