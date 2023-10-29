using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleInheritance
{
    public class Dog : Animal
    {
        public Dog()
        {
            
        }

        public void Bark()
        {
            Console.WriteLine("barking…");
        }
    }
}
