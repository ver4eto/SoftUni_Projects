using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Handball.Models
{
    public class Team : ITeam
    {
        private List<IPlayer> players;

        private string name;

        public Team(string name)
        {
            Name = name;
            players = new List<IPlayer>();
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                name = value;
            }
        }

        private int pointsEarned;

       
        public int PointsEarned
        {
            get { return pointsEarned; }
           private set { pointsEarned = value; }
        }


        public double OverallRating
        {
            get
            {
                if (Players.Count == 0)
                {
                    return 0;
                }
                return Math.Round(Players.Average(p => p.Rating),2);
            }
            
        }

        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();

        public void Draw()
        {
            PointsEarned += 1;
           IPlayer goalKeeper = players.FirstOrDefault(p=>p is Goalkeeper);

            if (goalKeeper != null)
            {
                goalKeeper.IncreaseRating();
            }
        }
        
        public void Lose()
        {
            foreach (var player in Players)
            {
                player.DecreaseRating();
            }
        }

        public void SignContract(IPlayer player)
        {
          players.Add(player);
        }

        public void Win()
        {
            PointsEarned += 3;
            foreach (var player in players)
            {
                player.IncreaseRating();
            }
        }

//        "Team: {Name} Points: {PointsEarned}
//--Overall rating: {OverallRating
//    }
//--Players: {name1
//}, { name2}…/ none" 

        public override string ToString()
        {
            string playersToString = "none";
            if (Players.Count > 0)
            {
                playersToString = string.Join(" ", players.Select(p=>p.Name));
            }
            StringBuilder bs = new StringBuilder();
            bs.AppendLine($"Team: {Name} Points: {PointsEarned}");
            bs.AppendLine($"--Overall rating: {OverallRating}");
            bs.AppendLine($"--Players: {playersToString}");

            return bs.ToString().Trim();
        }
    }
}
