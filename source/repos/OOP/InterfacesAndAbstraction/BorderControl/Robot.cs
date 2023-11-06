using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Robot : IRobot
    {
        public Robot(string model, string id)
        {
            ID = id;
            Model = model;
        }
        public string ID { get ; set; }
        public string Model { get ; set ; }

        public override string ToString()
        {
            return "<empty output>";
        }
    }
}
