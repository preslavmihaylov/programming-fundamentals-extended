using System;

class Phonebook
{
    static string[] numbers;
    static string[] names;

    static void Main()
    {
        numbers = Console.ReadLine().Split(' ');
        names = Console.ReadLine().Split(' ');

        string[] inputTokens = Console.ReadLine().Split(' ');
        while (inputTokens[0] != "done")
        {
            string cmd = inputTokens[0];
            string called = inputTokens[1];
            string name;
            string number;

            if (IsNumber(called))
            {
                number = called;
                name = GetEntryFor(called);
                called = name;
            }
            else
            {
                number = GetEntryFor(called);
                name = called;
                called = number;
            }

            int digitSum = GetSumOfDigits(number);

            if (cmd == "call")
            {
                Console.WriteLine("calling {0}...", called);
                if (digitSum % 2 == 0)
                {
                    int minutes = digitSum / 60;
                    int seconds = digitSum % 60;
                    Console.WriteLine("call ended. duration: {0}:{1}", 
                        minutes.ToString().PadLeft(2, '0'), 
                        seconds.ToString().PadLeft(2, '0'));
                }
                else
                {
                    Console.WriteLine("no answer");
                }
            }
            else if (cmd == "message")
            {
                Console.WriteLine("sending sms to {0}...", called);
                if (digitSum % 2 == 0)
                {
                    Console.WriteLine("meet me there");
                }
                else
                {
                    Console.WriteLine("busy");
                }
            }
            else
            {
                throw new ArgumentException();
            }

            inputTokens = Console.ReadLine().Split(' ');
        }
    }

    static int GetSumOfDigits(string number)
    {
        int sum = 0;
        for (int cnt = 0; cnt < number.Length; cnt++)
        {
            if (IsDigit(number[cnt]))
            {
                sum += number[cnt] - '0';
            }
        }

        return sum;
    }

    static string GetEntryFor(string entry)
    {
        for (int cnt = 0; cnt < numbers.Length; cnt++)
        {
            if (numbers[cnt] == entry)
            {
                return names[cnt];
            }
            else if (names[cnt] == entry)
            {
                return numbers[cnt];
            }
        }

        return "Not found";
    }

    static bool IsNumber(string input)
    {
        for (int cnt = 0; cnt < input.Length; ++cnt)
        {
            if (IsDigit(input[cnt]))
            {
                return true;
            }
        }

        return false;
    }

    static bool IsDigit(char ch)
    {
        return ch >= '0' && ch <= '9';
    }
}