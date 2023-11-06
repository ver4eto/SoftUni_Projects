using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Pet : IPerson
    {
        public Pet(string name, string birthday)
        {
            Name = name;
            Birthdate = birthday;
        }
        public string Name { get ; set ; }
        public string Birthdate { get ; set ; }

        public override string ToString()
        {
            return Birthdate;
        }
    }
}
