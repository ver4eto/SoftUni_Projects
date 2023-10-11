using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;

        public Engine()
        {
                
        }

        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, int power, int displacement)
            :this(model,power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power,  string efficiency)
           : this(model, power)
        {            
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency) 
            : this(model,power)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Power { get { return power; } set { power = value; } }
        public int Displacement { get { return displacement; } set { displacement = value; } }
        public string Efficiency { get { return efficiency; } set { efficiency = value; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" {this.Model.ToString()}:");
            sb.AppendLine($"    Power: {this.Power.ToString()}");
            if (this.Displacement != 0)
            {
                sb.AppendLine($"    Displacement: {this.Displacement.ToString()}");
            }
            else
            {
                sb.AppendLine("    Displacement: n/a");
            }

            if (this.Efficiency != null)
            {
                sb.AppendLine($"    Efficiency: {this.Efficiency}");
            }
            else { sb.AppendLine("    Efficiency: n/a"); }

            return sb.ToString().TrimEnd();

        }

        //        Model: a string property
        // Power: an int property
        // Displacement: an int property, it is optional
        // Efficiency: a string property, it is optiona
    }
}
