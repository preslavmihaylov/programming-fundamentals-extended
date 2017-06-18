using System;
using System.Diagnostics;

namespace _08.SMSTyping
{
    class SMSTyping
    {
        static void Main()
        {
            int inputsCnt = int.Parse(Console.ReadLine());

            for (int cnt = 0; cnt < inputsCnt; cnt++)
            {
                string input = Console.ReadLine();
                int currentDigit = 0;
                if (input.Length > 0)
                {
                    currentDigit = input[0] - '0';
                }
                else
                {
                    Debug.Assert(false);
                }

                int charIndex = (currentDigit - 2) * 3 + (input.Length - 1);
                if (currentDigit == 8 || currentDigit == 9)
                {
                    charIndex += 1;
                }

                if (currentDigit == 0)
                {
                    Console.Write(' ');
                }
                else
                {
                    Console.Write((char)(charIndex + 'a'));
                }
            }

            Console.WriteLine();
        }
    }
}
