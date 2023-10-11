namespace RawData;

public class StartUp
{
    public static void Main(string[] args)
    {
        int countOfCar=int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int i=0; i<countOfCar; i++)
        {
            Car car = new Car();
            Engine engine = new Engine();
            Cargo cargo = new Cargo();
            List<Tire> tires = new List<Tire>();

            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string model = data[0];
            int engineSpeed = int.Parse(data[1]);
            int enginePower = int.Parse(data[2]);
            int cargoWeight = int.Parse(data[3]);
            string cargoType = data[4];


            for (int j  = 5; j < data.Length; j+=2)
            {
                Tire tire = new Tire();

                double tirePressure = double.Parse(data[j]);
                int tireAge = int.Parse(data[ j + 1]);
                tire.Age = tireAge;
                tire.Pressure= tirePressure;

                tires.Add(tire);

            }
           car.Model= model;

            engine.Speed = engineSpeed;
            engine.Power = enginePower;

            car.Engine = engine;

            cargo.Weight = cargoWeight;
            cargo.Type = cargoType;

            car.Tires= tires;

            cars.Add(car);
        }

        string typeForPrint = Console.ReadLine();

        if (typeForPrint== "fragile")
        {
            // have a pressure of a single tire < 1.

            List<Car> fragileCars = cars.Where(c => c.Tires.Any(t => t.Pressure < 1)).ToList();

            foreach (var car in fragileCars )
            {
                Console.WriteLine(  car.Model);
            }
        }
        else if(typeForPrint== "flammable")
        {
            List<Car> flammableCars = cars.Where(c => c.Engine.Power > 250).ToList();
            foreach (var car in flammableCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}