using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelleddistance;

        public Car()
        {
                
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public double FuelAmount
        {
            get
            {
                return this.fuelAmount;
            }
            set { this.fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return this.fuelConsumptionPerKilometer; }
            set { this.fuelConsumptionPerKilometer = value; }
        }

        public double Travelleddistance
        {
            get { return this.travelleddistance; }
            set { this.travelleddistance = value;}
        }

        public bool  CanCarMoves( double travelledDistance)
        {
            bool canTRavel = true;

            double neededFuel = this.FuelConsumptionPerKilometer * travelledDistance;

            if (neededFuel>this.FuelAmount)
            {
                canTRavel = false;
            }
            return canTRavel;
        }

        public void CarMoves(double currentTravelledDistance)
        {
            this.Travelleddistance += currentTravelledDistance;
            double currentConsumedAmount = FuelConsumptionPerKilometer * currentTravelledDistance;

            this.FuelAmount -=currentConsumedAmount;

        }

        public void PrintCarData()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append($"{this.Model} ");
            stringBuilder.Append($"{this.FuelAmount.ToString("0.00"):F2} ");
            stringBuilder.AppendLine($"{this.Travelleddistance.ToString():F2}");

            Console.WriteLine(stringBuilder.ToString().TrimEnd()); 
        }
    }
}
