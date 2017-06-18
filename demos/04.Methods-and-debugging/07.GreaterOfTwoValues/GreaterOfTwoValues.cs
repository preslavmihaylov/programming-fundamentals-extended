using System;

class GreaterOfTwoValues
{
    static void Main()
    {
        string type = Console.ReadLine();
        if (type == "int")
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMax(first, second));
        }
        else if (type == "string")
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            Console.WriteLine(GetMax(first, second));
        }
        else // if (type == "char")
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            Console.WriteLine(GetMax(first, second));
        }
    }

    static int GetMax(int first, int second)
    {
        if (first >= second)
        {
            return first;
        }
        else
        {
            return second;
        }
    }

    static char GetMax(char first, char second)
    {
        if (first >= second)
        {
            return first;
        }
        else
        {
            return second;
        }
    }

    static string GetMax(string first, string second)
    {
        int comparison = first.CompareTo(second);

        if (comparison >= 0)
        {
            return first;
        }
        else
        {
            return second;
        }
    }
}