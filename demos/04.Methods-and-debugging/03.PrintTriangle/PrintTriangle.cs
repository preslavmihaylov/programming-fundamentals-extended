using System;

class PrintTriangle
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        for (int i = 1; i < number; i++)
        {
            PrintLine(1, i);
        }

        for (int i = number; i > 0; i--)
        {
            PrintLine(1, i);
        }
    }

    static void PrintLine(int start, int end)
    {
        for (int cnt = start; cnt <= end; cnt++)
        {
            Console.Write(cnt + " ");
        }
        Console.WriteLine();
    }
}