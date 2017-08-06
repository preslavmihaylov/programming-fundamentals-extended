using System;
using System.Text.RegularExpressions;

class SoftuniMessages
{
    static void Main()
    {
        Regex validInputPattern = new Regex(@"^\d+[A-Za-z]+[^a-zA-Z]+$");
        Regex messagePattern = new Regex(@"[A-Za-z]+");
        Regex indicesPattern = new Regex(@"\d");

        string input = Console.ReadLine();

        while (input != "Decrypt!")
        {
            int messageLength = int.Parse(Console.ReadLine());
            if (validInputPattern.IsMatch(input))
            {
                string message = messagePattern.Match(input).Value;
                MatchCollection indices = indicesPattern.Matches(input);
                if (message.Length == messageLength)
                {
                    string decryptedMessage = "";
                    foreach (Match m in indices)
                    {
                        int index = int.Parse(m.Value);
                        if (index < message.Length)
                        {
                            decryptedMessage += message[index];
                        }
                    }

                    Console.WriteLine("{0} = {1}",
                        message,
                        decryptedMessage);
                }
            }

            input = Console.ReadLine();
        }
    }
}
