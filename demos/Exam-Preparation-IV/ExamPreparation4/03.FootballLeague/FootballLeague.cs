using System;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

class Team
{
    public int Points { get; set; }
    public int Goals { get; set; }

    public Team(int points, int goals)
    {
        this.Points = points;
        this.Goals = goals;
    }
}

class FootballLeague
{
    static void Main()
    {
        var standingsTable =
            new Dictionary<string, Team>();

        string key = Console.ReadLine();
        string escapedKey = Regex.Escape(key);
        Regex teamsPattern = new Regex(
            string.Format(@"{0}(?<teamA>[a-zA-Z]*){0}.*{0}(?<teamB>[a-zA-Z]*){0}[^ ]* (?<score1>\d+):(?<score2>\d+)", escapedKey));

        string input = Console.ReadLine();
        while (input != "final")
        {
            Match match = teamsPattern.Match(input);
            
            string firstTeam =
                Reverse(match.Groups["teamA"].Value).ToUpper();
            string secondTeam =
                Reverse(match.Groups["teamB"].Value).ToUpper();
            int firstTeamScore = int.Parse(match.Groups["score1"].Value);
            int secondTeamScore = int.Parse(match.Groups["score2"].Value);

            if (!standingsTable.ContainsKey(firstTeam))
            {
                standingsTable.Add(firstTeam, new Team(0, 0));
            }

            if (!standingsTable.ContainsKey(secondTeam))
            {
                standingsTable.Add(secondTeam, new Team(0, 0));
            }

            standingsTable[firstTeam].Goals += firstTeamScore;
            standingsTable[secondTeam].Goals += secondTeamScore;

            if (firstTeamScore > secondTeamScore)
            {
                standingsTable[firstTeam].Points += 3;
            }
            else if (secondTeamScore > firstTeamScore)
            {
                standingsTable[secondTeam].Points += 3;
            }
            else if (firstTeamScore == secondTeamScore)
            {
                standingsTable[firstTeam].Points += 1;
                standingsTable[secondTeam].Points += 1;
            }

            input = Console.ReadLine();
        }

        var orderedByPoints = standingsTable
            .OrderByDescending(t => t.Value.Points)
            .ThenBy(t => t.Key);

        var topThreeByGoals = standingsTable
            .OrderByDescending(t => t.Value.Goals)
            .ThenBy(t => t.Key)
            .Take(3);

        int standingsPos = 1;

        Console.WriteLine("League standings:");
        foreach (var teamData in orderedByPoints)
        {
            string teamName = teamData.Key;
            Team team = teamData.Value;
            Console.WriteLine("{0}. {1} {2}",
                standingsPos,
                teamName,
                team.Points);

            standingsPos++;
        }

        Console.WriteLine("Top 3 scored goals:");
        foreach (var teamData in topThreeByGoals)
        {
            string teamName = teamData.Key;
            Team team = teamData.Value;

            Console.WriteLine("- {0} -> {1}",
                teamName,
                team.Goals);
        }
    }

    static string Reverse(string input)
    {
        string result = "";
        for (int cnt = input.Length - 1; cnt >= 0; --cnt)
        {
            result += input[cnt];
        }

        return result;
    }
}