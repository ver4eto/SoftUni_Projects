
using MilitaryElite.Enums;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(int iD, string firstName, string lastName, decimal salary, Corps corps, IReadOnlyCollection<IRepair> repairs) : base(iD, firstName, lastName, salary, corps)
        {
            Repairs = repairs;
        }

       public IReadOnlyCollection<IRepair> Repairs { get; private set; }


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine("Repairs:");
            foreach (IRepair rep in Repairs)
            {
                result.AppendLine($"  {rep.ToString()}");
            }
            return result.ToString().TrimEnd();
        }

    }
}
