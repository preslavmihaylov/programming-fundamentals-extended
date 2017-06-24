using System;
using System.Linq;
using System.Collections.Generic;

public class UnunionLists
{
    public static void Main()
    {
        List<int> primalList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        int otherListsCnt = int.Parse(Console.ReadLine());

        for (int cnt = 0; cnt < otherListsCnt; ++cnt)
        {
            int[] currentList = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            foreach (int number in currentList)
            {
                if (!primalList.Contains(number))
                {
                    primalList.Add(number);
                }
                else
                {
                    primalList.RemoveAll(e => e == number);
                }
            }
        }

        primalList.Sort();
        Console.WriteLine(string.Join(" ", primalList));
    }
}