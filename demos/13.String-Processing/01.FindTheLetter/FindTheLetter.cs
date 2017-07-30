using System;

class FindTheLetter
{
    static void Main()
    {
        string text = Console.ReadLine();
        string[] tokens = Console.ReadLine().Split();

        string letter = tokens[0];
        int skippedIndices = int.Parse(tokens[1]);

        int index = -1;
        do
        {
            skippedIndices--;
            index = text.IndexOf(letter, index + 1);
        } while (index != -1 && skippedIndices > 0);

        if (index != -1)
        {
            Console.WriteLine(index);
        }
        else
        {
            Console.WriteLine("Find the letter yourself!");
        }
    }
}