using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class Adult : Client
    {
        public Adult(string name, string id,  double income) : base(name, id,0, income)
        {
            this.Interest = 4;
        }

        public override void IncreaseInterest()
        {
            this.Interest += 2;
        }
    }
}
