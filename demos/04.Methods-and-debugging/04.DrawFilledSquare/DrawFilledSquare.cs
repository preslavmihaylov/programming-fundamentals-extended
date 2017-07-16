using System;

class DrawFilledSquare
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        PrintHeaderRow(n);
        for (int cnt = 0; cnt < n - 2; cnt++)
        {
            PrintMiddleRow(n);
        }
        PrintHeaderRow(n);
    }

    static void PrintHeaderRow(int n)
    {
        Console.WriteLine(new string('-', n * 2));
    }

    static void PrintMiddleRow(int n)
    {
        Console.Write('-');
        for (int cnt = 0; cnt < n - 1; cnt++)
        {
            Console.Write("\\/");
        }
        Console.WriteLine('-');
    }
}