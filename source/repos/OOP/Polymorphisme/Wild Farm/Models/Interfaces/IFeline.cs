﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild_Farm.Models.Interfaces
{
    public interface IFeline : IAnimal
    {
        string Breed { get; }
    }
}
