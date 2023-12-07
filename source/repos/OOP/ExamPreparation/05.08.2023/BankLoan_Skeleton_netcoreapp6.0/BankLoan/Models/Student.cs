using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class Student : Client
    {
        
        public Student(string name, string id,  double income) 
            : base(name, id, 0, income)
        {
            Interest = 2;
        }

        public override void IncreaseInterest()
        {
            this.Interest++;
        }
    }
}
