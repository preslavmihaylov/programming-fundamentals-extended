using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TravelCompany
{
    class TravelCompany
    {
        static Dictionary<string, Dictionary<string, int>> data = 
            new Dictionary<string, Dictionary<string, int>>();
        static void Main()
        {
            StoreTravelData();
            ProcessAccommodations();
        }

        static void StoreTravelData()
        {
            string[] inputTokens = Console.ReadLine().Split(':');
            while (inputTokens[0] != "ready")
            {
                string city = inputTokens[0];
                string busesData = inputTokens[1];

                StoreBusesData(city, busesData);

                inputTokens = Console.ReadLine().Split(':');
            }
        }

        static void StoreBusesData(string city, string input)
        {
            string[] busesData = input.Split(',');
            foreach (var busData in busesData)
            {
                string[] busDataTokens = busData.Split('-');

                string bus = busDataTokens[0];
                int capacity = int.Parse(busDataTokens[1]);

                if (!data.ContainsKey(city))
                {
                    data.Add(city, new Dictionary<string, int>());
                }

                data[city][bus] = capacity;
            }
        }

        static void ProcessAccommodations()
        {
            string[] inputTokens = Console.ReadLine().Split(' ');
            while (inputTokens[0] != "travel")
            {
                string destination = inputTokens[0];
                int passengers = int.Parse(inputTokens[1]);
                Dictionary<string, int> busesData = data[destination];

                ProcessCurrentAccomodation(busesData, destination, passengers);

                inputTokens = Console.ReadLine().Split(' ');
            }
        }

        static void ProcessCurrentAccomodation(
            Dictionary<string, int> busesData,
            string destination,
            int passengers)
        {
            int availableAccomodation =
                    busesData.Select(kvp => kvp.Value).Sum();

            if (availableAccomodation >= passengers)
            {
                Console.WriteLine("{0} -> all {1} accommodated",
                    destination,
                    passengers);
            }
            else
            {
                Console.WriteLine("{0} -> all except {1} accommodated",
                    destination,
                    passengers - availableAccomodation);
            }
        }
    }
}
