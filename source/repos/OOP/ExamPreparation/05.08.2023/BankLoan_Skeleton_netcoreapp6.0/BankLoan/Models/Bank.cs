using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private List<ILoan> loans;
        private List<IClient> clients;

        protected Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            loans = new List<ILoan>();
            clients = new List<IClient>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                name = value;
            }
        }



        public int Capacity { get; private set; }

        public IReadOnlyCollection<ILoan> Loans => loans.AsReadOnly();

        public IReadOnlyCollection<IClient> Clients => clients.AsReadOnly();

        public void AddClient(IClient Client)
        {
            if (Clients.Count() < Capacity)
            {
                clients.Add(Client);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void AddLoan(ILoan loan)
        {
           loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}, Type: {this.GetType().Name}");
            if (Clients.Count==0)
            {
            sb.AppendLine("Clients: none");

            }
            else
            {
                sb.AppendLine($"Clients: {string.Join(", ",Clients.Select(c=>c.Name))}");
            }
            sb.AppendLine($"Loans: {Loans.Count}, Sum of Rates: {Loans.Sum(l=>l.InterestRate)}");

            return sb.ToString().TrimEnd();   
        }

        public void RemoveClient(IClient Client)
        {
            if (clients.Contains(Client))
            {
                clients.Remove(Client);
            }
        }

        public double SumRates()
        {
            double sum = 0;
            foreach (var loan in Loans)
            {
                sum += loan.InterestRate;
            }
            return sum;
        }
    }
}
