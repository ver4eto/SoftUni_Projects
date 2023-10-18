using System.Diagnostics.SymbolStore;
using System.Text;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {

        private int capacity;
        private List<Vehicle> vehicles;

        public RepairShop(int capacity)
        {
            this.Capacity = capacity;
            this.vehicles = new List<Vehicle>();
        }

        public int Capacity { get { return capacity; } set { capacity = value; } }
        public List<Vehicle> Vehicles { get {  return vehicles; } }

        public void AddVehicle(Vehicle vehicle)
        {
            int currentCount = this.Vehicles.Count;
            if (this.Capacity > currentCount)
            {
                this.vehicles.Add(vehicle);

            }
        }

        public bool RemoveVehicle(string vin)
        {
            
             Vehicle current = this.Vehicles.FirstOrDefault(v => v.VIN == vin);

            if (current==null) 
            { 
                return false;
            }
            else
            {
                this.Vehicles.Remove(current);
                return true;
            }
        }

        public int GetCount()
        {
            return this.vehicles.Count;
        }

        public Vehicle GetLowestMileage()
        {
            return this.vehicles.OrderBy(v=>v.Mileage).First();
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Vehicles in the preparatory:");
            foreach (Vehicle v in this.vehicles)
            {
                stringBuilder.AppendLine(v.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
