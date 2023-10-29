
namespace CustomRandomList;

public class StartUp
{
    public static void Main(string[] args)
    {
        RandomList strings = new RandomList();
        strings.Add("fvgveg");
        strings.Add("dedg32ah");
        strings.Add("fvgveg");
        strings.Add("ded456geah"); strings.Add("fv-3=gveg");
        strings.Add("dedwwgeah");
        Console.WriteLine(strings.RandomString()); 
    }
}