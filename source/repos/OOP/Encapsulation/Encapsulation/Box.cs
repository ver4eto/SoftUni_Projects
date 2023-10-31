using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double len, double wid, double hig)
        {
            this.Width = wid;
            this.Height = hig;
            this.Length = len;
        }
        public double Length  {
            get
            {
                return this.length;
            }

           private set
            {
                if ( value>0)
                {
                    this.length = value;
                }
                else
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
            }
        }
        public double Width {
            get
            {
                return this.width;
            }

          private  set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
            }
        }
        public double Height {
            get
            {
                return this.height;
            }

          private  set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
            }
        }

        public double SurfaceArea()
        {
            return (2 * this.Length*this.Width) + (2 * this.Width*this.Height) +( 2 * this.Length*this.Height);
        }

        public double LateralSurfaceArea()
        {
            return (2 * this.Length*this.Height) + (2 * this.Width*this.Height);
        }

        public double Volume()
        {
            return this.Length*this.Height*this.Width;
        }
    }
}
