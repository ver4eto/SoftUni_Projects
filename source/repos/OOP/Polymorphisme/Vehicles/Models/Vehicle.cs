using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        private  double increasedConsumption;
        private double amountOfTank;

        private double _fuelQuantty;
        private double _fuelConsumption;
        private double _tankCapacity;
        public Vehicle(double fuelQuantity, double fuelConsumption,double increasedConsumption,double amountOfTank, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelConsumption = fuelConsumption;
            FuelQuantity = fuelQuantity;
            this.increasedConsumption = increasedConsumption;
            this.amountOfTank = amountOfTank;
        }
        public double FuelQuantity
        {
            get => _fuelQuantty; 
            private set
            {
                if (value <= TankCapacity)
                { 
                    this._fuelQuantty = value; 
                }
                
                else { _fuelQuantty = 0; }
            }
        }

        public double FuelConsumption
        {
            get => _fuelConsumption; private set
            {
                _fuelConsumption = value;
            }
        }

        public double TankCapacity
        {
            get { return this._tankCapacity; }
            private set
            {
                this._tankCapacity = value;
            }
        }

        public virtual string Drive(double distance, bool isIncreasedConsumption = true)
        {
            StringBuilder sb=new StringBuilder();
            Type type = this.GetType();
            string typeName = type.Name;
             
            double fuelConsuptionTotal = isIncreasedConsumption 
                ?FuelConsumption + increasedConsumption 
                : FuelConsumption;

            if (HasEnoughtFuel(distance, fuelConsuptionTotal, FuelQuantity))
            {
                FuelQuantity -= distance*fuelConsuptionTotal;
                return $"{typeName} travelled {distance} km";
            }
            else { throw new ArgumentException($"{typeName} needs refueling"); }

           
        }

        private bool HasEnoughtFuel(double distance, double fuelConsumption, double fuelQuantity)
        {
            if (fuelConsumption  * distance <= fuelQuantity)
            {
                return true;
            } 
            return false;
        }

        public virtual void Refuel(double amount)
        {
            if (amount<=0)
            {
                throw new Exception("Fuel must be a positive number");
            }
            else if (FuelQuantity + amount > TankCapacity)
            {
                throw new Exception($"Cannot fit {amount} fuel in the tank");
            }
            FuelQuantity += amount*amountOfTank;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity.ToString("F2")}";
        }
    }
}
