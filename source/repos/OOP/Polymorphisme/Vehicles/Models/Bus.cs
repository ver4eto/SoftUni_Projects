using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double increasedFuelCons = 1.4;
        private const double amountOfTank = 1;
        public Bus(double fuelQuantity, double fuelConsumption,  double tankCapacity) : base(fuelQuantity, fuelConsumption, increasedFuelCons, amountOfTank, tankCapacity)
        {
        }


    }
}
