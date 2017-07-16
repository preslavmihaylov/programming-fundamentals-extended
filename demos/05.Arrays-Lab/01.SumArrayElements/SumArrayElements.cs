using System;

class SumArrayElements
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        for (int cnt = 0; cnt < n; ++cnt)
        {
            arr[cnt] = int.Parse(Console.ReadLine());
        }

        int sum = 0;
        for (int cnt = 0; cnt < arr.Length; cnt++)
        {
            sum += arr[cnt];
        }

        Console.WriteLine(sum);
    }
}