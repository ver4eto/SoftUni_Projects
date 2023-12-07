using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class LoanRepository : IRepository<ILoan>
    {
        private List<ILoan> loans=new List<ILoan>();
        public IReadOnlyCollection<ILoan> Models => loans.AsReadOnly();

        public void AddModel(ILoan model)
        {
            loans.Add(model);
        }

        public ILoan FirstModel(string name)
        {
            ILoan loan = loans.FirstOrDefault(l => l.GetType().Name == name);
            if (loan == null)
            {
                return null;
            }
            else return loan;
        }

        public bool RemoveModel(ILoan model)
        {
            if (loans.Contains(model))
            {
                loans.Remove(model);
                return true;
            }
            return false;
        }
    }
}
