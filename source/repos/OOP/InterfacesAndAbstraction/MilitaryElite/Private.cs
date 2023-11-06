namespace MilitaryElite
{
    public class Private :Soldier, IPrivate
    {
        public Private(int iD, string firstName, string lastName, decimal salary) : base(iD, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; private set; }


        public override string ToString()
        {
            string result = base.ToString() + $" Salary: {Salary:f2}";
            return result;
        }
    }
}
