using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int _power = 100;
        public Paladin(string name) : base(name, _power)
        {
        }

        public override string CastAbility()
        {
            return  $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
