using System.Xml.Linq;

public class StartUp
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        int sum = 0;


        for (int i = 0; i < input.Length; i++)
        {
            try
            {
                if (int.TryParse(input[i], out int result))
                {
                    sum += result;

                }
                else if (int.Parse(input[i]) > int.MaxValue)
                {
                    throw new OverflowException();
                }
                else 
                { 
                    throw new FormatException();
                
                }
            }
            catch (OverflowException oe)
            {
                Console.WriteLine($"The element '{input[i]}' is out of range!");
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"The element '{input[i]}' is in wrong format!");
            }
            catch (Exception)
            {

            }
            finally { Console.WriteLine($"Element '{input[i]}' processed - current sum: {sum}"); }
            
        }
        Console.WriteLine($"The total sum of all integers is: {sum}");
    }
}