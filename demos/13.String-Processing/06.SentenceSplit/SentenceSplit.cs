using System;

class SentenceSplit
{
    static void Main()
    {
        string text = Console.ReadLine();
        string delimiter = Console.ReadLine();
        string[] tokens = text
            .Split(new string[] { delimiter },
                   StringSplitOptions.None);

        Console.WriteLine("[{0}]", string.Join(", ", tokens));
    }
}