using System;

class SignOfSignedNumber
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        PrintSign(num);
    }

    static void PrintSign(int number)
    {
        Console.Write("The number {0} is ", number);
        if (number > 0)
        {
            Console.WriteLine("positive.");
        }
        else if (number < 0)
        {
            Console.WriteLine("negative.");
        }
        else
        {
            Console.WriteLine("zero.");
        }
    }
}