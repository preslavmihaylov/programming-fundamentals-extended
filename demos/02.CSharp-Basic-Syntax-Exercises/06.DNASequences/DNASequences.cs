using System;

namespace _06.DNASequences
{
    class DNASequences
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            char[] charMappings = { '\0', 'A', 'C', 'G', 'T' };

            for (int cnt1 = 1; cnt1 <= 4; cnt1++)
            {
                for (int cnt2 = 1; cnt2 <= 4; cnt2++)
                {
                    for (int cnt3 = 1; cnt3 <= 4; cnt3++)
                    {
                        char surroundingChar = 'X';
                        if (cnt1 + cnt2 + cnt3 >= number)
                        {
                            surroundingChar = 'O';
                        }

                        Console.Write(surroundingChar);
                        Console.Write(charMappings[cnt1]);
                        Console.Write(charMappings[cnt2]);
                        Console.Write(charMappings[cnt3]);
                        Console.Write(surroundingChar);
                        Console.Write(' ');
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
