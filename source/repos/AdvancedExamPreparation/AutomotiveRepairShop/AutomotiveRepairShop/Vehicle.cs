namespace AutomotiveRepairShop
{
    public class Vehicle
    {
        private string vin;
        private int mileage;
        private string damage;

        public Vehicle(string vin, int mileage, string damage)
        {
                this.vin = vin;
            this.mileage = mileage;
            this.damage = damage;
        }
        public string VIN { get { return vin; } set { vin = value; } }
        public int Mileage {  get { return mileage; } set {  mileage = value; } }
        public string Damage { get { return damage; } set { damage = value; } }

        public override string ToString()
        {
            return $"Damage: {this.Damage}, Vehicle: {this.VIN} ({this.Mileage} km)";
        }

    }
}
