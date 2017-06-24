using System;
using System.Linq;
using System.Collections.Generic;

public class CamelsBack
{
    public static void Main()
    {
        List<int> inputElements = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        int camelsBackSize = int.Parse(Console.ReadLine());

        int rounds = 0;
        while (inputElements.Count > camelsBackSize)
        {
            inputElements.RemoveAt(0);
            inputElements.RemoveAt(inputElements.Count - 1);
            rounds++;
        }

        if (rounds > 0)
        {
            Console.WriteLine("{0} rounds", rounds);
            Console.WriteLine("remaining: {0}", string.Join(" ", inputElements));
        }
        else
        {
            Console.WriteLine("already stable: {0}", string.Join(" ", inputElements));
        }

    }
}