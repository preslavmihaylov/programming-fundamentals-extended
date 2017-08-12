using System;
using System.Linq;

class ArrayManipulator
{
    static void Main()
    {
        int[] arr = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

        string input = Console.ReadLine();
        while (input != "end")
        {
            string[] tokens = input.Split(' ');

            switch (tokens[0])
            {
                case "exchange":
                {
                    int index = int.Parse(tokens[1]);
                    if (index >= 0 && index < arr.Length)
                    {
                        arr = Exchange(arr, index);
                        //Console.WriteLine("[{0}]", string.Join(", ", arr));
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }

                    break;
                }
                case "max":
                {
                    bool isOdd = ParseIsOdd(tokens[1]);
                    int maxIndex = Max(arr, isOdd);
                    if (maxIndex >= 0)
                    {
                        Console.WriteLine(maxIndex);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }

                    break;
                }
                case "min":
                {
                    bool isOdd = ParseIsOdd(tokens[1]);
                    int minIndex = Min(arr, isOdd);
                    if (minIndex >= 0)
                    {
                        Console.WriteLine(minIndex);
                    }
                    else
                    {
                        Console.WriteLine("No matches");
                    }

                    break;
                }
                case "first":
                {
                    int count = int.Parse(tokens[1]);
                    bool isOdd = ParseIsOdd(tokens[2]);

                    if (count <= arr.Length)
                    {
                        int[] firstElements = First(arr, count, isOdd);
                        Console.WriteLine("[{0}]", string.Join(", ", firstElements));
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                    
                    break;
                }
                case "last":
                {
                    int count = int.Parse(tokens[1]);
                    bool isOdd = ParseIsOdd(tokens[2]);

                    if (count <= arr.Length)
                    {
                        int[] lastElements = Last(arr, count, isOdd);
                        Console.WriteLine("[{0}]", string.Join(", ", lastElements));
                    }
                    else
                    {
                        Console.WriteLine("Invalid count");
                    }
                    
                    break;
                }
            }

            input = Console.ReadLine();
        }

        Console.WriteLine("[{0}]", string.Join(", ", arr));
    }

    static bool ParseIsOdd(string oddStr)
    {
        return (oddStr == "odd") ? true : false;
    }

    static int[] Exchange(int[] arr, int index)
    {
        var firstSequence = arr.Take(index + 1);
        var secondSequence = arr.Skip(index + 1);

        return secondSequence
            .Concat(firstSequence).ToArray();
    }

    static int Max(int[] arr, bool isOdd)
    {
        int moduloExpectedResult = isOdd ? 1 : 0;

        var filteredSequence = arr
            .Where(n => n % 2 == moduloExpectedResult);

        int maxElement;
        if (filteredSequence.Count() > 0)
        {
            maxElement = filteredSequence.Max();
        }
        else
        {
            return -1;
        }

        return arr.ToList().LastIndexOf(maxElement);
    }

    static int Min(int[] arr, bool isOdd)
    {
        int moduloExpectedResult = isOdd ? 1 : 0;

        var filteredSequence = arr
            .Where(n => n % 2 == moduloExpectedResult);
 
        int minElement;
        if (filteredSequence.Count() > 0)
        {
            minElement = filteredSequence.Min();
        }
        else
        {
            return -1;
        }

        return arr.ToList().LastIndexOf(minElement);
    }

    static int[] First(int[] arr, int count, bool isOdd)
    {
        int moduloExpectedResult = isOdd ? 1 : 0;
        return arr
            .Where(n => n % 2 == moduloExpectedResult)
            .Take(count)
            .ToArray();
    }

    static int[] Last(int[] arr, int count, bool isOdd)
    {
        int moduloExpectedResult = isOdd ? 1 : 0;
        return arr
            .Where(n => n % 2 == moduloExpectedResult)
            .Reverse()
            .Take(count)
            .Reverse()
            .ToArray();
    }
}