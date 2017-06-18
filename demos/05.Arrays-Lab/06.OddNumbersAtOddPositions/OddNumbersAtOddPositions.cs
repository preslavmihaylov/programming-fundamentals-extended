using System;

class OddNumbersAtOddPositions
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');

        int oddNumbersAtOddPositionsCnt = 0;
        for (int cnt = 0; cnt < input.Length; cnt++)
        {
            int num = int.Parse(input[cnt]);
            if (num % 2 != 0 && cnt % 2 != 0)
            {
                Console.WriteLine("Index {0} -> {1}", cnt, num);
            }
        }
    }
}