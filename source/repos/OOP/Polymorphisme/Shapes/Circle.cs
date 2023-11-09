using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;
        public Circle(double rad)
        {
            Radius = rad;
        }

        public double Radius { get
            {
                return radius;
            } 
        protected set
            {
                radius = value;
            }
        }
        public override double CalculateArea()
        {
            return Math.PI*Math.Sqrt(Radius);
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string Draw()
        {
            Type type = typeof(Circle);
            string typeName = type.Name;
            return $"Drawing {typeName}";
        }
    }
}
