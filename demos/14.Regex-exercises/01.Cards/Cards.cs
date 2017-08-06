using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Cards
{
    static void Main()
    {
        Regex pattern = new Regex(@"(?<=[SHDC]|^)([2-9JQKA]|10)[SHDC]");

        string text = Console.ReadLine();

        MatchCollection matches = pattern.Matches(text);

        List<Match> result = matches
            .Cast<Match>()
            .ToList();

        Console.WriteLine(string.Join(", ", result));
    }
}
