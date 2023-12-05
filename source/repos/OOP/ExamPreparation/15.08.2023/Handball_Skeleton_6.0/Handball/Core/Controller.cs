using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handball.Core
{


    public class Controller : IController
    {

        private PlayerRepository players;
        private TeamRepository teams;
        private string[] validPlayers = { "CenterBack", "ForwardWing", "Goalkeeper" };

        public Controller()
        {
            players = new PlayerRepository();
            teams = new TeamRepository();
        }
        public string LeagueStandings()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***League Standings***");
            List<ITeam> sortedTeams = teams.Models.OrderByDescending(t => t.PointsEarned).ThenByDescending(t=>t.OverallRating).ThenBy(t=>t.Name).ToList();

            foreach (var team in sortedTeams)
            {
                sb.AppendLine(team.ToString());
            }
            return sb.ToString().Trim();
        }

        public string NewContract(string playerName, string teamName)
        {
            if (!players.ExistsModel(playerName))
            {
                return String.Format(OutputMessages.PlayerNotExisting,playerName, typeof(PlayerRepository).Name);
            }
            if (!teams.ExistsModel(teamName))
            {
                return String.Format(OutputMessages.TeamNotExisting, teamName, typeof(TeamRepository).Name);
            }

            IPlayer player = players.GetModel(playerName);
            ITeam team = teams.GetModel(teamName);

            if (player.Team != null)
            {
                return String.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }

            player.JoinTeam(teamName);
            team.SignContract(player);
            return String.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam=teams.GetModel(firstTeamName);
            ITeam secondTeam = teams.GetModel(secondTeamName);
            ITeam winner = null;
            ITeam loser =null;
            bool isDraw = false;

            if (firstTeam.OverallRating>secondTeam.OverallRating)
            {
                
                winner = firstTeam;
                loser = secondTeam;
            }
           else if (firstTeam.OverallRating < secondTeam.OverallRating)
            {
                
                winner = secondTeam;
                loser = firstTeam;
            }
            else
            {
                isDraw  = true;
            }

            if (!isDraw)
            {
                winner.Win();
                loser.Lose();
                return String.Format(OutputMessages.GameHasWinner,winner.Name,loser.Name);
            }
            else
            {
                firstTeam.Draw();
                secondTeam.Draw();
                return String.Format(OutputMessages.GameIsDraw, firstTeam.Name, secondTeam.Name);
            }
          
        }

        public string NewPlayer(string typeName, string name)
        {
            if (!validPlayers.Contains(typeName))
            {
                return String.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }
            if (players.ExistsModel(name))
            {
                IPlayer player = players.GetModel(name);
                return String.Format(OutputMessages.PlayerIsAlreadyAdded, name, players.GetType().Name,player.GetType().Name);
            }
            IPlayer newPlayer=null;

            if (typeName =="Goalkeeper")
            {
                newPlayer = new Goalkeeper(name);

            }
            if (typeName == "CenterBack")
            {
                newPlayer = new CenterBack(name);

            }
             if (typeName == "ForwardWing")
            {
                newPlayer = new ForwardWing(name);

            }
            players.AddModel(newPlayer);
            return String.Format(OutputMessages.PlayerAddedSuccessfully,name);
        }

        public string NewTeam(string name)
        {
            Team team = new Team(name);
            if (teams.ExistsModel(name))
            {
                return String.Format(OutputMessages.TeamAlreadyExists, name, "TeamRepository");
            }
            teams.AddModel(team);   
            return String.Format(OutputMessages.TeamSuccessfullyAdded, name, "TeamRepository");
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"***{teamName}***");
           ITeam team = teams.GetModel(teamName);

            foreach (var player in team.Players.OrderByDescending(p=>p.Rating).ThenBy(n=>n.Name))
            {
                sb.Append(player.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
