using System;
using System.Collections.Generic;

namespace _02.VaporStore
{
    class VaporStore
    {
        static void Main()
        {
            double balance = double.Parse(Console.ReadLine());
            double startingBalance = balance;

            Dictionary<string, double> data = new Dictionary<string, double>();

            data["OutFall 4"] = 39.99;
            data["CS: OG"] = 15.99;
            data["Zplinter Zell"] = 19.99;
            data["Honored 2"] = 59.99;
            data["RoverWatch"] = 29.99;
            data["RoverWatch Origins Edition"] = 39.99;

            string input = Console.ReadLine();
            while (input != "Game Time")
            {
                if (!data.ContainsKey(input))
                {
                    Console.WriteLine("Not Found");
                }
                else
                {
                    double currentPrice = data[input];
                    if (currentPrice <= balance)
                    {
                        Console.WriteLine("Bought {0}", input);
                        balance -= currentPrice;
                    }
                    else
                    {
                        Console.WriteLine("Too Expensive");
                    }
                }
                
                if (Math.Abs(balance) < 0.00001)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine("Total spent: ${0:F2}. Remaining: ${1:F2}",
                startingBalance - balance,
                balance);
        }
    }
}
