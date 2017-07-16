using System;

class CountOddNumbersInArray
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int[] arr = new int[input.Length];

        int oddNumbersCnt = 0;
        for (int cnt = 0; cnt < input.Length; cnt++)
        {
            arr[cnt] = int.Parse(input[cnt]);
            if (arr[cnt] % 2 != 0)
            {
                ++oddNumbersCnt;
            }
        }

        Console.WriteLine(oddNumbersCnt);
    }
}