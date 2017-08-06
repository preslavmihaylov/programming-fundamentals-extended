using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class WordEncounter
{
    static char letterToSearch;
    static int occurences;

    static void Main()
    {
        string input = Console.ReadLine();

        letterToSearch = input[0];
        occurences = input[1] - '0';

        input = Console.ReadLine();
        List<string> outputWords = new List<string>();

        while (input != "end")
        {
            if (IsValidSentence(input))
            {
                Regex wordsPattern = new Regex(@"\b\w+\b");

                MatchCollection matches = wordsPattern.Matches(input);

                foreach (Match m in matches)
                {
                    string word = m.Value;
                    if (IsValidWord(word))
                    {
                        outputWords.Add(word);
                    }
                }
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(string.Join(", ", outputWords));
    }

    static bool IsValidWord(string word)
    {
        int index = word.IndexOf(letterToSearch);
        int cnt = 0;

        while (index != -1)
        {
            index = word.IndexOf(letterToSearch, index + 1);
            cnt++;
        }

        return (cnt >= occurences);
    }

    static bool IsValidSentence(string sentence)
    {
        Regex validSentencePattern = new Regex(@"^[A-Z].*[\.!\?]$");

        return validSentencePattern.IsMatch(sentence);
    }
}
