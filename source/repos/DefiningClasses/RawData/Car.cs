using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private List<Tire> tires;

        //        Model: a string property
        // Engine: a class with two properties – speed and power,
        // Cargo: a class with two properties – type and weight
        // Tires: a collection of exactly 4 tires.Each tire should have two properties: age and pressure.

        public Car()
        {
            List<Tire> tires
              = new List<Tire>(4);
        }

        public Car(string model, Engine engine, List<Tire> tires, Cargo cargo)
        {
            this.tires = tires;
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        public List<Tire> Tires
        {
            get { return tires; }
            set { tires = value; }
        }

        public Cargo Cargo 
        {
            get { return cargo; } 
            set {  cargo = value; } 
        }

    }
}
