using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SoftuniBeerPong
{
    class SoftuniBeerPong
    {
        static void Main()
        {
            var data = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "stop the game")
            {
                string[] inputTokens =
                    input.Split('|');

                string player = inputTokens[0];
                string team = inputTokens[1];
                int score = int.Parse(inputTokens[2]);

                if (!data.ContainsKey(team))
                {
                    data.Add(team, new Dictionary<string, int>());
                }

                if (data[team].Count < 3)
                {
                    data[team].Add(player, score);
                }

                input = Console.ReadLine();
            }

            var orderedData = data
                .Where(r => r.Value.Count == 3)
                .OrderByDescending(r => r.Value.Sum(playerRecord => playerRecord.Value));

            int teamRanking = 1;
            foreach (var teamRecord in orderedData)
            {
                string teamName = teamRecord.Key;
                Dictionary<string, int> playersData = teamRecord.Value;
                var orderedPlayersData = playersData
                    .OrderByDescending(p => p.Value);

                Console.WriteLine("{0}. {1}; Players:", teamRanking, teamName);
                foreach (var playerRecord in orderedPlayersData)
                {
                    Console.WriteLine("###{0}: {1}", playerRecord.Key, playerRecord.Value);
                }

                teamRanking++;
            }
        }
    }
}
