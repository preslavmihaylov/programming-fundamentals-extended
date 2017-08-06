using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class GroceryShop
{
    static void Main()
    {
        var data =
            new Dictionary<string, double>();

        Regex productRegex = new Regex(@"^[A-Z][a-z]+:\d+\.\d{2}$");

        string input = Console.ReadLine();
        while (input != "bill")
        {
            if (productRegex.IsMatch(input))
            {
                string[] tokens = input.Split(':');
                string product = tokens[0];
                double price = double.Parse(tokens[1]);
                
                data[product] = price;
            }

            input = Console.ReadLine();
        }

        var orderedData = data
            .OrderByDescending(productData => productData.Value);

        foreach (var productData in orderedData)
        {
            string product = productData.Key;
            double price = productData.Value;

            Console.WriteLine("{0} costs {1:F2}", product, price);
        }

    }
}