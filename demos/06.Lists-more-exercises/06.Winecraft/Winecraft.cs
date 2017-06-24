using System;
using System.Collections.Generic;
using System.Linq;

public class Winecraft
{
    static List<int> grapes;
    public static void Main()
    {
        grapes = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        int roundLength = int.Parse(Console.ReadLine());

        do
        {
            for (int cnt = 0; cnt < roundLength; ++cnt)
            {
                for (int index = 0; index < grapes.Count; ++index)
                {
                    if (!IsAlive(index))
                    {
                        continue;
                    }

                    if (IsGreaterGrape(index))
                    {
                        if (IsAlive(index - 1))
                        {
                            grapes[index]++;
                            grapes[index - 1]--;
                        }

                        if (IsAlive(index + 1))
                        {
                            grapes[index]++;
                            grapes[index + 1]--;
                        }

                        grapes[index]++;
                    }
                    else if (IsGreaterGrape(index - 1) || IsGreaterGrape(index + 1))
                    {
                        // do nothing. Lesser grape
                    }
                    else
                    {
                        // Normal grape
                        grapes[index]++;
                    }
                }
            }

            RemoveWeakGrapes(roundLength);
        } while (HasMoreStrongGrapesThan(roundLength));

        Console.WriteLine(string.Join(" ", grapes.Where(g => g > 0).ToArray()));
    }

    static bool HasMoreStrongGrapesThan(int threshold)
    {
        return grapes.Where(g => g > threshold).Count() >= threshold;
    }

    static void RemoveWeakGrapes(int threshold)
    {
        for (int index = 0; index < grapes.Count; ++index)
        {
            if (grapes[index] <= threshold)
            {
                grapes[index] = 0;
            }
        }
    }

    static bool IsAlive(int index)
    {
        if (index < 0 || index >= grapes.Count)
        {
            return false;
        }

        if (grapes[index] > 0)
        {
            return true;
        }

        return false;
    }

    static bool IsGreaterGrape(int index)
    {
        if ((index <= 0) || (index >= grapes.Count - 1))
        {
            return false;
        }

        if (grapes[index] > grapes[index - 1] && grapes[index] > grapes[index + 1])
        {
            return true;
        }

        return false;
    }
}