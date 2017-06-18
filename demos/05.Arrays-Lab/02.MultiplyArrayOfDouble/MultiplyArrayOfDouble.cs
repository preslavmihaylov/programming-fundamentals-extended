using System;

class MultiplyArrayOfDouble
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        double p = double.Parse(Console.ReadLine());
        double[] arr = new double[input.Length];

        for (int cnt = 0; cnt < input.Length; ++cnt)
        {
            arr[cnt] = double.Parse(input[cnt]);
        }
        
        for (int cnt = 0; cnt < arr.Length; cnt++)
        {
            arr[cnt] *= p;
            Console.Write(arr[cnt] + " ");
        }

        Console.WriteLine();
    }
}