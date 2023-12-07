using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private BankRepository banks = new BankRepository();
        private LoanRepository loans = new LoanRepository();

        public string AddBank(string bankTypeName, string name)
        {
            if (bankTypeName != "BranchBank" && bankTypeName != "CentralBank")
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }
            IBank bank;
            if (bankTypeName == "BranchBank")
            {
                bank = new BranchBank(name);

            }
            else
            {
                bank = new CentralBank(name);
            }
            banks.AddModel(bank);
            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            if (clientTypeName != "Adult" && clientTypeName != "Student")
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }
            IBank bank = banks.Models.FirstOrDefault(b => b.Name == bankName);
            IClient client;
            string bankType = bank.GetType().Name;

            // student=>branch bank
            //adut=>centralbank
            if (clientTypeName == "Adult" && bankType != "CentralBank" || clientTypeName == "Student" && bankType != "BranchBank")
            {
                return string.Format(OutputMessages.UnsuitableBank);
            }
            if (clientTypeName == "Adult")
            {
                client = new Adult(clientName, id, income);
            }
            else
            {
                client = new Student(clientName, id, income);
            }
            bank.AddClient(client);
            return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
        }

        public string AddLoan(string loanTypeName)
        {
            if (loanTypeName != "MortgageLoan" && loanTypeName != "StudentLoan")
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }
            ILoan loan;
            if (loanTypeName == "MortgageLoan")
            {
                loan = new MortgageLoan();
            }
            else
            {
                loan = new StudentLoan();
            }
            loans.AddModel(loan);
            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = banks.Models.First(b=>b.Name == bankName);
            double sum = bank.Loans.Sum(b=>b.Amount);
            sum += bank.Clients.Sum(c => c.Income);
            string totalSum = $"{sum:f2}";
           

            return string.Format(OutputMessages.BankFundsCalculated, bankName,totalSum );
        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan = loans.Models.FirstOrDefault(l => l.GetType().Name == loanTypeName);
            if (loan == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }
            IBank bank = banks.Models.First(b => b.Name == bankName);
            bank.AddLoan(loan);
            loans.RemoveModel(loan);
            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var bank in banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
