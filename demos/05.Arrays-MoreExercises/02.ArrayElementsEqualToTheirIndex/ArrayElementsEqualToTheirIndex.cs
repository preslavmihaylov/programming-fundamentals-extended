using System;

public class ArrayElementsEqualToTheirIndex
{
    public static void Main()
    {
        string[] inputTokens = Console.ReadLine().Split(' ');

        for (int cnt = 0; cnt < inputTokens.Length; ++cnt)
        {
            int currentNum = int.Parse(inputTokens[cnt]);

            if (currentNum == cnt)
            {
                Console.Write(currentNum + " ");
            }
        }

        Console.WriteLine();
    }
}