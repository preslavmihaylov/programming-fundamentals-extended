using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OptimizedBankingSystem
{
    class Account
    {
        public string Bank { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public Account(string bank, string name, decimal balance)
        {
            this.Bank = bank;
            this.Name = name;
            this.Balance = balance;
        }
    }

    class OptimizedBankingSystem
    {
        static void Main()
        {
            List<Account> accounts = new List<Account>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] inputTokens = input
                    .Split(new string[] { " | " },
                           StringSplitOptions.RemoveEmptyEntries);

                string bank = inputTokens[0];
                string bankAccount = inputTokens[1];
                decimal balance = decimal.Parse(inputTokens[2]);
                Account acc = new Account(bank, bankAccount, balance);

                accounts.Add(acc);

                input = Console.ReadLine();
            }

            var orderedAccounts = accounts
                .OrderByDescending(a => a.Balance)
                .ThenBy(a => a.Bank.Length);

            foreach (var account in orderedAccounts)
            {
                Console.WriteLine("{0} -> {1} ({2})",
                    account.Name, account.Balance, account.Bank);
            }
        }
    }
}
