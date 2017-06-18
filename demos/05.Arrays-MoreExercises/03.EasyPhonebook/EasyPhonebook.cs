using System;

public class EasyPhonebook
{
    public static void Main()
    {
        string[] numbers = Console.ReadLine().Split(' ');
        string[] names = Console.ReadLine().Split(' ');

        string input = Console.ReadLine();
        while (input != "done")
        {
            for (int cnt = 0; cnt < names.Length; ++cnt)
            {
                if (names[cnt] == input)
                {
                    Console.WriteLine("{0} -> {1}", names[cnt], numbers[cnt]);
                }
            }

            input = Console.ReadLine();
        }
    }
}