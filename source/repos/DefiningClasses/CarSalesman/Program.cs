namespace   CarSalesman;

public class StartUp
{
    public static void Main(string[] args)
    {
        int countOfEngine = int.Parse(Console.ReadLine());

        List<Engine>engines = new List<Engine>();
        List<Car> cars = new List<Car>();

        for (int i = 0; i < countOfEngine; i++)
        {
            Engine engine = new Engine();

            string[] data = Console.ReadLine().Split(" ");
            string model= data[0];
            int power = int.Parse(data[1]);

            engine.Model = model;
            engine.Power = power;

            if (data.Length == 3)
            {
                int displacement;
                string efficiency;
                bool isSuccesful= int.TryParse(data[2], out displacement);

                if (isSuccesful)
                {
                    displacement = int.Parse(data[2]);
                    engine.Displacement = displacement;
                }
                else
                {
                    efficiency = data[2];
                    engine.Efficiency = efficiency;
                }

            }
           else if (data.Length == 4)
            {
                int displacement = int.Parse(data[2]);
                string efficiency= data[3];
                engine.Efficiency = efficiency;
                engine.Displacement = displacement;
            }
           engines.Add(engine);
        }

        int countOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfCars; i++)
        {
            Car car = new Car();

            string[] data = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string model = data[0];
            string engineModel = data[1];
            car.Model = model;
            car.Engine = engines.First(e => e.Model == engineModel);

            if (data.Length==3)
            {
                int weight;
                string color;

                bool isNumber = int.TryParse(data[2], out weight);
                if (isNumber)
                {
                    weight = int.Parse(data[2]);
                    car.Weght = weight;
                }
                else
                {
                    color = data[2];
                    car.Color = color;
                }
            }
            else if (data.Length==4)
            {
                int weight = int.Parse(data[2]);
                string color = data[3];
                car.Weght= weight;
                car.Color= color;
            }

            cars.Add(car);
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car.ToString());
        }
    }
}