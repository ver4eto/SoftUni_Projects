using Shapes;

public class StartUp
{
    public static void Main()
    {
        Shape rectangle = new Rectangle(3.34, 4.58);
        Shape circle = new Circle(7.18);
        Console.WriteLine(rectangle.CalculatePerimeter().ToString("F2"));
        Console.WriteLine(rectangle.CalculateArea().ToString("F2"));
        Console.WriteLine(rectangle.Draw());
        Console.WriteLine(circle.CalculatePerimeter().ToString("F2"));
        Console.WriteLine(circle.CalculateArea().ToString("F2"));
        Console.WriteLine(circle.Draw());

    }
}