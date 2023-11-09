using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.IO.Interfaces;

namespace Wild_Farm.IO
{
    public class Reader : IReader
    {
        public string ReadLine() =>  
           Console.ReadLine();
        
    }
}
