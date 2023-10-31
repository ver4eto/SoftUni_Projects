using Encapsulation;

double length=double.Parse(Console.ReadLine());
double width=double.Parse(Console.ReadLine());
double height=double.Parse(Console.ReadLine());

try
{
    Box box = new Box(length, width, height);

   string area=box.SurfaceArea().ToString("F2");
    string lateralArea = box.LateralSurfaceArea().ToString("F2");
    string volume = box.Volume().ToString("F2");

    Console.WriteLine($"Surface Area - {area}");
    Console.WriteLine($"Lateral Surface Area - {lateralArea}");
    Console.WriteLine($"Volume - {volume}");
}
catch (Exception ex)
{

	Console.WriteLine(ex.Message);
}
