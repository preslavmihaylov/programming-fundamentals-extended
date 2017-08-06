using System;
using System.Text.RegularExpressions;

class FishStatistics
{
    static void Main()
    {
        Regex fishPattern = new Regex(@"[>]*<[(]+['\-x]>");

        string input = Console.ReadLine();

        MatchCollection matches = fishPattern.Matches(input);

        int fishIndex = 1;
        foreach (Match m in matches)
        {
            string fish = m.Value;
            int tailLength = 0;
            int bodyLength = 0;
            string status = "";

            for (int i = 0; i < fish.Length; ++i)
            {
                char part = fish[i];
                if (part == '>' && i != fish.Length - 1)
                {
                    tailLength++;
                }
                else if (part == '(')
                {
                    bodyLength++;
                }
                else if (part == '\'')
                {
                    status = "Awake";
                }
                else if (part == '-')
                {
                    status = "Asleep";
                }
                else if (part == 'x')
                {
                    status = "Dead";
                }
            }

            Console.WriteLine("Fish {0}: {1}",
                fishIndex,
                fish);

            Console.Write("Tail type: {0}",
                GetTailType(tailLength));

            if (GetTailType(tailLength) != "None")
            {
                Console.WriteLine(" ({0} cm)", tailLength * 2);
            }
            else
            {
                Console.WriteLine();
            }

            Console.WriteLine("Body type: {0} ({1} cm)",
                GetBodyType(bodyLength),
                bodyLength * 2);
            Console.WriteLine("Status: {0}", status);
            fishIndex++;
        }

        if (fishIndex == 1)
        {
            Console.WriteLine("No fish found.");
        }
    }

    static string GetTailType(int tailLength)
    {
        if (tailLength > 5)
        {
            return "Long";
        }
        else if (tailLength > 1)
        {
            return "Medium";
        }
        else if (tailLength == 1)
        {
            return "Short";
        }
        else
        {
            return "None";
        }
    }

    static string GetBodyType(int bodyLength)
    {
        if (bodyLength > 10)
        {
            return "Long";
        }
        else if (bodyLength > 5)
        {
            return "Medium";
        }
        else
        {
            return "Short";
        }
    }
}