namespace MilitaryElite
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int iD, string firstName, string lastName, int codenumber) : base(iD, 
firstName, lastName)
        {

            CodeNumber = codenumber;
        }

        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"{Environment.NewLine}Code Number: {CodeNumber}";
        }
    }
}
