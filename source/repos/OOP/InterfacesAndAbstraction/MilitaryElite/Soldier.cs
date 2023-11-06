namespace MilitaryElite
{
    public abstract class Soldier : ISoldier
    {
        protected Soldier(int iD, string firstName, string lastName)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
        }
        public int ID { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public override string ToString()
        {
            string
                 result = $"Name: {FirstName} {LastName} Id: {ID}";
            return result;
        }

    }
}
