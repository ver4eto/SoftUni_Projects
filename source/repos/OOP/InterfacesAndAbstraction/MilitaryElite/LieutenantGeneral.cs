using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int iD, string firstName, string lastName, decimal salary, IReadOnlyCollection<
            IPrivate> privates) : base(iD, firstName, lastName, salary)
        {
            Privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates { get; private set;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine("Privates:");
            foreach (IPrivate priv in Privates)
            {
                result.AppendLine($"  {priv.ToString()}");
            }
            return result.ToString().TrimEnd();
        }
    }
}
