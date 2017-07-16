using System;

namespace LiveDemo
{
    public class Program
    {
        public static void Main()
        {
            int inputCnt = int.Parse(Console.ReadLine());

            for (int cnt = 0; cnt < inputCnt; cnt++)
            {
                string currentInput = Console.ReadLine();
                int currentDigit = 0;
                int repetitions = 0;

                if (currentInput.Length > 0)
                {
                    currentDigit = currentInput[0] - '0';
                }

                int characterToPrint = (currentDigit - 2) * 3;
                if (currentDigit >= 8)
                {
                    characterToPrint += 1;
                }

                characterToPrint += (currentInput.Length - 1);

                characterToPrint += 'a';

                if (currentDigit == 0)
                {
                    characterToPrint = ' ';
                }

                Console.Write((char)characterToPrint);
            }

            Console.WriteLine();
        }
    }
}
