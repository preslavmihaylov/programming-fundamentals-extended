using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Camping
{
    class Camping
    {
        static void Main()
        {
            var campersData =
                new Dictionary<string, List<string>>();
            var daysData =
                new Dictionary<string, int>();


            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] inputTokens = input.Split(' ');
                string name = inputTokens[0];
                string camperName = inputTokens[1];
                int daysStayed = int.Parse(inputTokens[2]);

                if (!campersData.ContainsKey(name))
                {
                    campersData.Add(name, new List<string>());
                }

                campersData[name].Add(camperName);

                if (!daysData.ContainsKey(name))
                {
                    daysData.Add(name, 0);
                }

                daysData[name] += daysStayed;

                input = Console.ReadLine();
            }

            var orderedCampersData = campersData
                .OrderByDescending(item => item.Value.Count)
                .ThenBy(item => item.Key.Length);

            foreach (var item in orderedCampersData)
            {
                string key = item.Key;
                List<string> campers = item.Value;

                Console.WriteLine("{0}: {1}", key, campers.Count);
                foreach (var camper in campers)
                {
                    Console.WriteLine("***{0}", camper);
                }

                Console.WriteLine("Total stay: {0} nights", daysData[key]);
            }
        }
    }
}
