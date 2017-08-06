using System;
using System.Text.RegularExpressions;

class HappinessIndex
{
    static void Main()
    {
        Regex happinessRegex = new Regex(@":\)|:D|;\)|:\*|:]|;]|:}|;}|\(:|\*:|c:|\[:|\[;");
        Regex sadnessRegex = new Regex(@":\(|D:|;\(|:\[|;\[|:{|;{|\):|:c|]:|];");

        string input = Console.ReadLine();

        MatchCollection happinessMatches = 
            happinessRegex.Matches(input);
        
        MatchCollection sadnessMatches = 
            sadnessRegex.Matches(input);

        int happyFacesCnt = happinessMatches.Count;
        int sadFacesCnt = sadnessMatches.Count;
        double happinessIndex = ((float)happyFacesCnt) / sadFacesCnt;
        string happinessIndexEmoji = GetHappinessIndexEmoji(happinessIndex);

        Console.WriteLine("Happiness index: {0:F2} {1}",
            happinessIndex,
            happinessIndexEmoji);

        Console.WriteLine("[Happy count: {0}, Sad count: {1}]",
            happyFacesCnt,
            sadFacesCnt);
    }

    static string GetHappinessIndexEmoji(double happinessIndex)
    {
        if (happinessIndex >= 2)
        {
            return ":D";
        }
        else if (happinessIndex > 1)
        {
            return ":)";
        }
        else if (happinessIndex == 1)
        {
            return ":|";
        }
        else
        {
            return ":(";
        }
    }
}