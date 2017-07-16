using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    class ShoppingSpree
    {
        static void Main()
        {
            var data = new Dictionary<string, double>();

            double budget = double.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] inputTokens =
                    input.Split(' ');

                string product = inputTokens[0];
                double price = double.Parse(inputTokens[1]);

                if (data.ContainsKey(product))
                {
                    if (data[product] > price)
                    {
                        data[product] = price;
                    }
                }
                else
                {
                    data[product] = price;
                }

                input = Console.ReadLine();
            }

            double totalPrice = data.Sum(r => r.Value);

            if (totalPrice > budget)
            {
                Console.WriteLine("Need more money... Just buy banichka");
            }
            else
            {
                var orderedData = data
                    .OrderByDescending(r => r.Value)
                    .ThenBy(r => r.Key.Length);

                foreach (var item in orderedData)
                {
                    Console.WriteLine("{0} costs {1:F2}", item.Key, item.Value);
                }
            }
        }
    }
}
