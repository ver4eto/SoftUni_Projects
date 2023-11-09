using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double _increasedConsimption = 1.6;
        private const double _amountOfTank = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, _increasedConsimption, _amountOfTank, tankCapacity )
        {

        }

        public override string Drive(double distance, bool isEmpty)
        {
            return base.Drive(distance);
        }

    }
}
