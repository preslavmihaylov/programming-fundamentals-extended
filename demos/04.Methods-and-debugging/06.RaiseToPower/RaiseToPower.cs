using System;

class RaiseToPower
{
    static void Main()
    {
        double number = double.Parse(Console.ReadLine());
        int power = int.Parse(Console.ReadLine());

        Console.WriteLine(RaisePower(number, power));
    }

    static double RaisePower(double number, int power)
    {
        double result = number;
        for (int cnt = 0; cnt < power - 1; cnt++)
        {
            result *= number;
        }

        return result;
    }
}