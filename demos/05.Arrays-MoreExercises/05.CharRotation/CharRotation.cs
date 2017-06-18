using System;
using System.Linq;

public class CharRotation
{
    public static void Main()
    {
        char[] chars = Console.ReadLine().ToCharArray();
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        for (int cnt = 0; cnt < numbers.Length; ++cnt)
        {
            if (numbers[cnt] % 2 == 0)
            {
                chars[cnt] -= (char)numbers[cnt];
            }
            else
            {
                chars[cnt] += (char)numbers[cnt];
            }

            Console.Write(chars[cnt]);
        }

        Console.WriteLine();
    }
}