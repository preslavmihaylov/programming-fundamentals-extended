using System;

class PriceChangeAlert
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double significanceThreshold = double.Parse(Console.ReadLine());
        double last = double.Parse(Console.ReadLine());

        for (int i = 0; i < n - 1; i++)
        {
            double price = double.Parse(Console.ReadLine());
            double difference = CalculateDifference(last, price);
            bool isSignificantDifference = IsSignificantDifference(difference, significanceThreshold);

            PrintPriceChangeMessage(price, last, difference, isSignificantDifference);
            
            last = price;
        }
    }

    private static void PrintPriceChangeMessage(double currentPrice, 
        double lastPrice, 
        double difference, 
        bool isSignificantDifference)
    {
        double percentDifference = difference * 100;

        if (difference == 0)
        {
            Console.WriteLine("NO CHANGE: {0}", currentPrice);
        }
        else if (!isSignificantDifference)
        {
            Console.WriteLine("MINOR CHANGE: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, percentDifference);
        }
        else if (difference > 0)
        {
            Console.WriteLine("PRICE UP: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, percentDifference);
        }
        else if (difference < 0)
        {
            Console.WriteLine("PRICE DOWN: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, percentDifference);
        }
    }

    private static bool IsSignificantDifference(double significanceThreshold, double difference)
    {
        return difference <= Math.Abs(significanceThreshold);
    }

    private static double CalculateDifference(double lastPrice, double currentPrice)
    {
        double difference = (currentPrice - lastPrice) / lastPrice;
        return difference;
    }
}
