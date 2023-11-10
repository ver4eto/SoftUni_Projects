using System.Security.Principal;
using System.Transactions;

public class StartUp
{
    public static void Main()
    {
        Dictionary<int, double> bankAccounts = new Dictionary<int, double>();

        string[] acountTokens = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

        foreach (string token in acountTokens)
        {
            string[] currentAcountTokens = token.Split("-");
            int number = int.Parse(currentAcountTokens[0]);
            if (!bankAccounts.ContainsKey(number))
            {
                bankAccounts.Add(number,0);
            }
            bankAccounts[number] = double.Parse(currentAcountTokens[1]);
        }

        string command;

        while ((command=Console.ReadLine())!="End")
        {
            string[] actionsComannd = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string action = actionsComannd[0];
            int bankNumber = int.Parse(actionsComannd[1]);
            double amount = double.Parse(actionsComannd[2]);

            try {
                switch (action)
                {
                    case "Deposit":
                        Deposit(bankNumber, amount, bankAccounts);
                        break;
                    case "Withdraw":
                        Withdraw(bankNumber, amount, bankAccounts);
                        break;
                    default:
                        throw new ArgumentException("Invalid command!");

                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            finally
            {
                Console.WriteLine("Enter another command");
            }
            
        }
    }

    private static void Withdraw(int bankNumber, double amount, Dictionary<int, double> bankAccounts)
    {
        if (!bankAccounts.ContainsKey(bankNumber))
        {
            throw new ArgumentOutOfRangeException("Invalid account!");
        }
        else if (bankAccounts[bankNumber] >= amount)
        {
            bankAccounts[bankNumber] -= amount;
            Console.WriteLine($"Account {bankNumber} has new balance: {bankAccounts[bankNumber].ToString("F2")}");
        }
        else
        {
            throw new ArgumentException("Insufficient balance!");
        }
    }

    private static void Deposit(int bankNumber, double amount, Dictionary<int, double> bankAccounts)
    {
        if (!bankAccounts.ContainsKey(bankNumber))
        {
            throw new ArgumentException("Invalid account!");
        }
        bankAccounts[bankNumber] += amount;
        Console.WriteLine($"Account {bankNumber} has new balance: {bankAccounts[bankNumber].ToString("F2")}");
    }
}