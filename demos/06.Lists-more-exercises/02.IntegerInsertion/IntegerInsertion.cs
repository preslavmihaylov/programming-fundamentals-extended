using System;
using System.Linq;
using System.Collections.Generic;

public class IntegerInsertion
{
    public static void Main()
    {
        List<int> inputElements = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

        string input = Console.ReadLine();
        while (input != "end")
        {
            int currentNumber = int.Parse(input);
            int indexToInsert = input[0] - '0';

            inputElements.Insert(indexToInsert, currentNumber);

            input = Console.ReadLine();
        }

        foreach (int el in inputElements)
        {
            Console.Write(el + " ");
        }

        Console.WriteLine();
    }
}