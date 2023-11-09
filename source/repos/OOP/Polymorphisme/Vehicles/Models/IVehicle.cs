using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public interface IVehicle
    {
        //have fuel quantity, fuel consumption in liters per km, and can be driven a given distance and refueled with a given amount of fuel.

        double FuelQuantity { get; }
        double FuelConsumption { get; }
        double TankCapacity {  get; }
        string Drive(double distance, bool isIncreasedConsumption = true);
        void Refuel(double amount);
    }
}
