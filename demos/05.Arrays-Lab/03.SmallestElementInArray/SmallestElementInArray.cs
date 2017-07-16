using System;

class SmallestElementInArray
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int[] arr = new int[input.Length];

        for (int cnt = 0; cnt < input.Length; ++cnt)
        {
            arr[cnt] = int.Parse(input[cnt]);
        }

        int smallest = int.MaxValue;
        for (int cnt = 0; cnt < arr.Length; cnt++)
        {
            if (arr[cnt] < smallest)
            {
                smallest = arr[cnt];
            }
        }

        Console.WriteLine(smallest);
    }
}
