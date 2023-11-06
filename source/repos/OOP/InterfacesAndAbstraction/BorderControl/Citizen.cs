using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public class Citizen : ICitizen, IPerson
    {

        public Citizen(string name, int age,string id, string birthdate)
        {
            Name = name;
            ID = id;
            Age = age;
            Birthdate = birthdate;

        }
        public string Name { get ; set ; }
        public string ID { get ; set; }
        public int Age { get; set; }
        public string Birthdate { get; set ; }

        public override string ToString()
        {
            return Birthdate;
        }
    }
}
