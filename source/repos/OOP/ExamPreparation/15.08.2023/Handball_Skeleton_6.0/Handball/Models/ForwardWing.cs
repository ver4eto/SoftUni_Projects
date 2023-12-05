using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public class ForwardWing : Player
    {
        private static double _currentRating = 5.5;
        public ForwardWing(string name) : base(name, _currentRating)
        {
        }

        public override void DecreaseRating()
        {
            Rating -= 0.75;
        }

        public override void IncreaseRating()
        {
            Rating += 1.25;
        }
    }
}
