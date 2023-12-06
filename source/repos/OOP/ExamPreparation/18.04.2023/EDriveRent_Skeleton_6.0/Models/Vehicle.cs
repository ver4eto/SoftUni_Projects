using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string brand;
        private string model;
        private string liscence;

        protected Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
            BatteryLevel = 100;
            IsDamaged = false;
        }

        public string Brand
        {
            get { return brand; }
          private  set { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }                
                brand = value; }
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                model = value;
            }
        }

        

        public double MaxMileage { get; private set; }

        public string LicensePlateNumber
        {
            get { return liscence; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                liscence = value;
            }
        }

        public int BatteryLevel { get; private set; }

        public bool IsDamaged { get; private set; }

        public void ChangeStatus()
        {
            if (IsDamaged==false)
            {
                IsDamaged   =true;
            }
            else { IsDamaged =false; }
        }

        public  void Drive(double mileage)
        {

            //int residualBattery = ;
            BatteryLevel -= (int)Math.Round((mileage / MaxMileage) * 100);

            if (this.GetType() == typeof(CargoVan))
            {
                BatteryLevel -= 5;
            }
        }
        

        public void Recharge()
        {
            BatteryLevel = 100;
        }

        public override string ToString()
        {
            string status; 

            if (IsDamaged == false)
            {
                status = "OK";
            }
            else
            {
                status = "damaged";
            }
            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {status}";
        }
    }
}
