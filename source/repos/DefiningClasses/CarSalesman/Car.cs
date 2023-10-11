using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weght;
        private string color;
        public Car()
        {
            
        }
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }
        public Car(string model, Engine engine, int weight) :this(model,engine)
        {
            this.Weght = weight;
        }

        public Car(string model, Engine engine, string color):this (model,engine)
        {
                this.Color = color;
        }
        public Car(string model, Engine engine,int weight,string color):this(model, engine) 
        {
            this.Weght = weight;
            this.Color = color;
        }
        public string Model {  get { return model; } set {  model = value; } }
        public Engine Engine { get { return engine; } set { engine = value; } } 
        public int Weght { get {  return weght; } set {  weght = value; } }
        public string Color { get { return color; } set { color = value; } }

//        Model: a string property
// Engine: a property holding the engine object
// Weight: an int property, it is optional
// Color: a string property, it is optional

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" {this.Model.ToString()}:");
            sb.AppendLine($" {this.Engine.ToString()}");
            if (this.Weght !=0)
            {
                sb.AppendLine($"  Weight: {this.Weght.ToString()}");
            }
            else
            {
                sb.AppendLine("  Weight: n/a");
            }

            if (this.Color != null)
            {
                sb.AppendLine($"  Color: {this.Color}");
            }
            else { sb.AppendLine("  Color: n/a"); }

            return sb.ToString().TrimEnd();


        }
    }
}
