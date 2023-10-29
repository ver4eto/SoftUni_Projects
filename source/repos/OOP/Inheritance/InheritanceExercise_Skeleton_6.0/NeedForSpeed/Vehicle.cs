using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;
        public int HorsePower {  get; set; }
        public double Fuel { get;set; }

        public Vehicle(int horsePower, double fuel)
        {
                HorsePower= horsePower; 
            Fuel= fuel;
        }

        public virtual double FuelConsumption()
        {
            return DefaultFuelConsumption;
        }

        public virtual void Drive(double kilometers)
        {
            //should have a functionality to reduce the Fuel based on the traveled kilometers.
            this.Fuel -= kilometers*this.FuelConsumption();

        }
    }
}
