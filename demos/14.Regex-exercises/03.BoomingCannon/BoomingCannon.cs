using System;
using System.Collections.Generic;
using System.Linq;

class BoomingCannon
{
    static void Main()
    {
        int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int skip = parameters[0];
        int shotSize = parameters[1];
        int cannonSize = 4;

        string input = Console.ReadLine();

        List<string> destroyedTargets = new List<string>();

        int index = input.IndexOf("\\<<<");
        while (index != -1)
        {
            int destroyedTargetBounds = cannonSize + index + skip + shotSize;
            int nextTargetIndex = input.IndexOf("\\<<<", index + 1);

            if (nextTargetIndex != -1 && nextTargetIndex < destroyedTargetBounds)
            {
                destroyedTargetBounds = nextTargetIndex;
            }

            int startIndex = cannonSize + index + skip;
            int length = destroyedTargetBounds - index - skip - cannonSize;
            
            if (length > 0)
            {
                if (startIndex + length >= input.Length)
                {
                    length = input.Length - startIndex;
                }

                string destroyedTarget = input.Substring(startIndex, length);
                destroyedTargets.Add(destroyedTarget);
            }

            index = input.IndexOf("\\<<<", index + 1);
        }

        Console.WriteLine(string.Join(@"/\", destroyedTargets));
        
    }
}