using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.OrderedBankingSystem
{
    class OrderedBankingSystem
    {
        static void Main()
        {
            var data =
                new Dictionary<string, Dictionary<string, decimal>>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] inputTokens = input
                    .Split(new string[] { " -> " },
                           StringSplitOptions.RemoveEmptyEntries);

                string bank = inputTokens[0];
                string bankAccount = inputTokens[1];
                decimal balance = decimal.Parse(inputTokens[2]);

                if (!data.ContainsKey(bank))
                {
                    data.Add(bank, new Dictionary<string, decimal>());
                }

                if (!data[bank].ContainsKey(bankAccount))
                {
                    data[bank].Add(bankAccount, 0);
                }

                data[bank][bankAccount] += balance;

                input = Console.ReadLine();
            }

            var orderedData = data
                .OrderByDescending(bankData => bankData.Value.Sum(balanceData => balanceData.Value))
                .ThenByDescending(bankData => bankData.Value.Max(balanceData => balanceData.Value));

            foreach (var bankData in orderedData)
            {
                string bank = bankData.Key;
                Dictionary<string, decimal> balancesData = bankData.Value;
                var orderedBalancesData = balancesData
                    .OrderByDescending(balanceData => balanceData.Value);

                foreach (var balanceData in orderedBalancesData)
                {
                    string balanceName = balanceData.Key;
                    decimal balance = balanceData.Value;

                    Console.WriteLine("{0} -> {1} ({2})",
                        balanceName,
                        balance,
                        bank);
                }
            }
        }
    }
}
