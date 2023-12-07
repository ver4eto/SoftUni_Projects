using BankLoan.Models.Contracts;
using BankLoan.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class BankRepository : IRepository<IBank>
    {
        private List<IBank> banks = new List<IBank>();
        public IReadOnlyCollection<IBank> Models => banks.AsReadOnly();

        public void AddModel(IBank model)
        {
            banks.Add(model);
        }

        public IBank FirstModel(string name)
        {
            IBank bank = banks.FirstOrDefault(b => b.GetType().Name == name);
            if (bank == null) { return null; }
            return bank;
        }

        public bool RemoveModel(IBank model)
        {
            if (banks.Contains(model))
            {
                banks.Remove(model);
                return true;
            }
            return false;
        }
    }
}
