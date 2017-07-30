using System;

class Placeholders
{
    static void Main()
    {
        string input = Console.ReadLine();
        while (input != "end")
        {
            string[] inputTokens = input
                .Split(new string[] { " -> " },
                       StringSplitOptions.RemoveEmptyEntries);

            string text = inputTokens[0];
            string[] parameters = inputTokens[1]
                .Split(new string[] { ", " },
                       StringSplitOptions.RemoveEmptyEntries);

            for (int index = 0; index < parameters.Length; ++index)
            {
                string parameter = parameters[index];
                string placeholder = "{" + index + "}";
               
                text = text.Replace(placeholder, parameter);
            }

            Console.WriteLine(text);
            input = Console.ReadLine();
        }
    }
}
