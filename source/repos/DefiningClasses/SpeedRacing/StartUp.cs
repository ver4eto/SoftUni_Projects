using System.Runtime.Serialization.Formatters;

namespace SpeedRacing;

public class StartUp
{
    public static void Main(string[] args)
    {
        int count = int.Parse(Console.ReadLine());

        List<Car> cars = new List<Car>();

        for (int i = 0; i < count; i++)
        {
            string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car();

            string model = data[0];
            double fuelAmount = double.Parse(data[1]);  
            double fuelConsumption = double.Parse(data[2]);

            car.Model = model;
            car.FuelAmount = fuelAmount;
            car.FuelConsumptionPerKilometer = fuelConsumption;

            cars.Add(car);
        }

        string command;

        while ((command =Console.ReadLine()) !="End")
        {
            string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string carModel = data[1];
           // double currentFuelAmount = double.Parse(data[1]);
            double currentTravelledDistance= double.Parse(data[2]);

            Car cuurentCar = cars.FirstOrDefault(c => c.Model == carModel);



            bool canTravel = cuurentCar.CanCarMoves( currentTravelledDistance);

            if (canTravel)
            {
                cuurentCar.CarMoves(currentTravelledDistance);
            }
            else { Console.WriteLine("Insufficient fuel for the drive"); }
        }

        foreach (var car in cars)
        {
            car.PrintCarData();
        }
    }
}