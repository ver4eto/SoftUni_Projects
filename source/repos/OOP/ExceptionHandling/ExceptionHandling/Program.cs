
try
{
    int number = int.Parse(Console.ReadLine());
    if (number < 0)
    {
        throw new ArithmeticException("Invalid number.");
    }
    double result = Math.Sqrt(number);
   
    Console.WriteLine(result);
}
catch (ArithmeticException ex)
{

    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Goodbye.");
}