using Vehicles.Models;

public class StartUp
{
    public static void Main()
    {
        ICollection<IVehicle> vehicles = new List<IVehicle>();
        //
        //truck.Refuel(10);
        //Console.WriteLine(truck.Drive(10));

        //
        //car.Refuel(10);
        //Console.WriteLine(car.Drive(5));
        //Console.WriteLine(truck.ToString());
        //Console.WriteLine(car.ToString());
        string[] carTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        double fuelQuantityCar = double.Parse(carTokens[1]); 
        double consumptionCar = double.Parse(carTokens[2]);
        double tankCapacityCar = double.Parse(carTokens[3]);

        IVehicle car = new Car(fuelQuantityCar, consumptionCar, tankCapacityCar);
        
        string[] truckTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        double fuelQuantityTruck= double.Parse(truckTokens[1]);
        double consumptionTruck= double.Parse(truckTokens[2]);
        double tankCapacityTruck = double.Parse(truckTokens[3]);

        IVehicle truck = new Truck(fuelQuantityTruck, consumptionTruck, tankCapacityTruck);

        string[] busTokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        double fuelQuantityBus = double.Parse(busTokens[1]);
        double consumptionBus= double.Parse(busTokens[2]);
        double tankCapacityBus = double.Parse(busTokens[3]);

        IVehicle bus = new Bus(fuelQuantityBus, consumptionBus, tankCapacityBus);

        vehicles.Add(car);
        vehicles.Add(truck);
        vehicles.Add(bus);

        int countCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < countCommands; i++)
        {
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string typeOfCommand = commands[0];
            string typeOfVehicle = commands[1];

            try
            {
                IVehicle vehicle =vehicles.FirstOrDefault(v=>v.GetType().Name==typeOfVehicle);

                switch (typeOfCommand)
                {
                    case "Drive":
                       double distance = double.Parse(commands[2]);
                        Console.WriteLine(vehicle.Drive(distance, true)); 
                        break;
                    case "Refuel":
                        double amount = double.Parse(commands[2]);
                        vehicle.Refuel(amount);
                        break;
                    case "DriveEmpty":
                        double emptyBusDistance= double.Parse(commands[2]);
                        Console.WriteLine(bus.Drive(emptyBusDistance, false));
                        break;                            

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        foreach (var item in vehicles)
        {
            Console.WriteLine(item.ToString());
        }
    }
}