using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {

        private string model;
        private int convertionCapacityIndex;
        private int batteryCapacity;
        private List<int> interfaceStandarts;

        protected Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            ConvertionCapacityIndex = convertionCapacityIndex;
            BatteryLevel = BatteryCapacity;
            interfaceStandarts = new List<int>();
        }

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
                }
                model = value;
            }
        }

        public int BatteryCapacity
        {
            get { return batteryCapacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
                }
                batteryCapacity = value;
            }
        }


        public int ConvertionCapacityIndex
        {
            get { return convertionCapacityIndex; }
            private set { convertionCapacityIndex = value; }
        }


        public int BatteryLevel { get; private set; }


        public IReadOnlyCollection<int> InterfaceStandards {
            get { return interfaceStandarts.AsReadOnly(); }
            private set { }
        } 

        public void Eating(int minutes)
        {
            int energyProduced = ConvertionCapacityIndex * minutes;
            if (energyProduced + BatteryLevel <= BatteryCapacity)
            {
                BatteryLevel += energyProduced;
            }
            else
            {
                BatteryLevel = BatteryCapacity;
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (BatteryLevel>=consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;
                return true;
            }
            return false;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            interfaceStandarts.Add(supplement.InterfaceStandard);
            batteryCapacity -= supplement.BatteryUsage;
            BatteryLevel -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{this.GetType().Name} {Model}:");
            stringBuilder.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            stringBuilder.AppendLine($"--Current battery level: {BatteryLevel}");
            if (InterfaceStandards.Count()==0)
            {
                stringBuilder.AppendLine("--Supplements installed: none");
            }
            else
            {
                stringBuilder.Append($"--Supplements installed: {string.Join(" ",InterfaceStandards)}");
                //foreach (var item in InterfaceStandards)
                //{
                //stringBuilder.Append($"{item.ToString()}");

                //}
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
