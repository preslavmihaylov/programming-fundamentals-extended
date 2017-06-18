using System;

public class LastThreeConsecutiveStrings
{
    public static void Main()
    {
        string[] strings = Console.ReadLine().Split(' ');

        int currentOccurences = 0;

        string lastStr = strings[0];
        string strToPrint = strings[0];

        for (int cnt = 0; cnt < strings.Length; ++cnt)
        {
            if (strings[cnt] == lastStr)
            {
                currentOccurences++;
            }
            else
            {
                if (currentOccurences == 3)
                {
                    strToPrint = lastStr;
                }

                currentOccurences = 1;
            }

            lastStr = strings[cnt];
        }

        if (currentOccurences == 3)
        {
            strToPrint = lastStr;
        }

        for (int cnt = 0; cnt < 3; ++cnt)
        {
            Console.Write(strToPrint + " ");
        }

        Console.WriteLine();
    }
}