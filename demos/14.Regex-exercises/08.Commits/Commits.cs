using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

class Commit
{
    public string Hash { get; set; }
    public string Message { get; set; }
    public int Additions { get; set; }
    public int Deletions { get; set; }

    public Commit(string hash, string message, int additions, int deletions)
    {
        this.Hash = hash;
        this.Message = message;
        this.Additions = additions;
        this.Deletions = deletions;
    }

    public override string ToString()
    {
        string result = string.Format(
            "commit {0}: {1} ({2} additions, {3} deletions)",
            this.Hash,
            this.Message,
            this.Additions,
            this.Deletions);

        return result;
    }
}

class Commits
{
    static void Main()
    {
        var data =
            new SortedDictionary<string, SortedDictionary<string, List<Commit>>>();

        Regex urlPattern = 
            new Regex(@"^https:\/\/github\.com\/(?<user>[a-zA-Z0-9-]+)\/(?<repo>[a-zA-Z-_]+)\/commit\/(?<hash>[A-Fa-f0-9]{40}),(?<message>[^\n]+),(?<additions>[0-9]+),(?<deletions>[0-9]+)$");
        
        string input = Console.ReadLine();
        while (input != "git push")
        {
            if (urlPattern.IsMatch(input))
            {
                Match match = urlPattern.Match(input);
                string user = match.Groups["user"].Value;
                string repo = match.Groups["repo"].Value;
                string hash = match.Groups["hash"].Value;
                string message = match.Groups["message"].Value;
                int additions = int.Parse(match.Groups["additions"].Value);
                int deletions = int.Parse(match.Groups["deletions"].Value);

                Commit commit = new Commit(hash, message, additions, deletions);

                if (!data.ContainsKey(user))
                {
                    data.Add(user, new SortedDictionary<string, List<Commit>>());
                }

                if (!data[user].ContainsKey(repo))
                {
                    data[user].Add(repo, new List<Commit>());
                }

                data[user][repo].Add(commit);
            }

            input = Console.ReadLine();
        }

        foreach (var userData in data)
        {
            string user = userData.Key;
            var reposData = userData.Value;

            Console.WriteLine("{0}:", user);
            foreach (var repoData in reposData)
            {
                string repo = repoData.Key;
                List<Commit> commits = repoData.Value;

                Console.WriteLine("  {0}:", repo);

                int totalAdditions =
                    commits.Sum(c => c.Additions);
                int totalDeletions =
                    commits.Sum(c => c.Deletions);

                foreach (Commit commit  in commits)
                {
                    // NOTE: Using ToString() in class Commit
                    Console.WriteLine("    {0}", commit);
                }

                Console.WriteLine("    Total: {0} additions, {1} deletions",
                    totalAdditions,
                    totalDeletions);
            }
        }
    }
}