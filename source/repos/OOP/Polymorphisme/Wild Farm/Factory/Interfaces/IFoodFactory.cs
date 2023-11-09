using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Farm.Models.Interfaces;

namespace Wild_Farm.Factory.Interfaces
{
    public interface IFoodFactory
    {
        IFood Create(string[] foodTokens);
    }
}
