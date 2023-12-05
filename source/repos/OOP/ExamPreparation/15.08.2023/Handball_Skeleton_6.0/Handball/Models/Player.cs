using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Models
{
    public abstract class Player : IPlayer
    {
        protected Player(string name, double rating)
        {
            Name = name;
            Rating = rating;
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PlayerNameNull);
                }
                name = value;
            }
        }

        private double rating;

        public double Rating
        {
            get { return rating; }

            protected set
            {
                if (value > 10 || value<1)
                {
                    return;
                }
                else
                {
                    rating = value;
                }
            } //setva se ot methodi
        }

        private string team;


        public string Team
        {
            get { return team; }
            //set { team = value; }
        }



        public abstract void DecreaseRating();


        public abstract void IncreaseRating();


        public void JoinTeam(string name)
        {
            team = name;
        }

        public override string ToString()
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {Name}");
                sb.AppendLine($"--Rating: { Rating}"
);

            return sb.ToString();
        }
    }
}
