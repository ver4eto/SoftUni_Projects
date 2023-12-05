using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class CenterBack : Player
    {
        private static double _currentRating = 4;
        public CenterBack(string name) : base(name, _currentRating)
        {
        }

        public override void DecreaseRating()
        {
            Rating -= 1;
        }

        public override void IncreaseRating()
        {
          Rating += 1;
        }
    }
}
