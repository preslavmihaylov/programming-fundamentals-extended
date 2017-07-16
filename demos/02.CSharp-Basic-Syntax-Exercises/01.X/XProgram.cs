using System;

class XProgram
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());

        for (int row = 0; row < input; row++)
        {
            for (int col = 0; col < input; col++)
            {
                if ((col == row) || (col == input - 1 - row))
                {
                    Console.Write('x');
                }
                else
                {
                    Console.Write(' ');
                }
            }
            Console.WriteLine();
        }
    }
}
