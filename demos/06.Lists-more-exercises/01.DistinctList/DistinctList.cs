using System;
using System.Linq;
using System.Collections.Generic;

public class DistinctList
{
    public static void Main()
    {
        int[] inputElements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        List<int> nonRepeatingElements = new List<int>();

        foreach (int number in inputElements)
        {
            if (!nonRepeatingElements.Contains(number))
            {
                nonRepeatingElements.Add(number);
                Console.Write(number + " ");
            }
        }

        Console.WriteLine();
    }
}