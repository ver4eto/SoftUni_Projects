using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitaryElite.Enums;


namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(int iD, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<Mission> missions) : base(iD, firstName, lastName, salary, corps)
        {
            Missions = missions;
        }

        public IReadOnlyCollection<IMission> Missions { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine("Missions:");
            foreach (IMission mis in Missions)
            {
                result.AppendLine($"  {mis.ToString()}");
            }
            return result.ToString().TrimEnd();
        }
    }
}
