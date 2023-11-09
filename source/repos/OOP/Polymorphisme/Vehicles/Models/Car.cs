using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double _increasedConsumption = 0.9;
        private const double _amountOfTank = 1;
        public Car(double fuelQuantity, double fuelConsumption, double tankCap) : base(fuelQuantity, fuelConsumption, _increasedConsumption, _amountOfTank, tankCap)
        {
        }
    }
}
