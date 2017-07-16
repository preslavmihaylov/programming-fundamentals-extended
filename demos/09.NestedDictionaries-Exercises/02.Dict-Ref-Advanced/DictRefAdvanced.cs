using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Dict_Ref_Advanced
{
    class DictRefAdvanced
    {
        static void Main()
        {
            Dictionary<string, List<int>> data =
                new Dictionary<string, List<int>>();

            string[] inputTokens = ReadInputTokens();
            while (!IsEnd(inputTokens[0]))
            {
                string name = inputTokens[0];
                string argument = inputTokens[1];

                List<int> numsToAdd = ExtractNumbers(data, argument);
                StoreNumbers(data, name, numsToAdd);

                inputTokens = ReadInputTokens();
            }

            PrintOutput(data);
        }

        static string[] ReadInputTokens()
        {
            return Console.ReadLine()
                    .Split(new string[] { " -> " },
                           StringSplitOptions.RemoveEmptyEntries);
        }

        static bool IsEnd(string input)
        {
            return (input == "end");
        }

        static List<int> ExtractNumbers(
            Dictionary<string, List<int>> data,
            string input)
        {
            if (IsName(input))
            {
                string otherName = input;
                if (data.ContainsKey(otherName))
                {
                    return data[otherName];
                }
                else
                {
                    return new List<int>();
                }
            }
            else
            {
                return ParseNumbers(input);
            }
        }

        static List<int> ParseNumbers(string input)
        {
            return input
                .Split(new char[] { ',' },
                       StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
        }

        static bool IsName(string input)
        {
            foreach (var ch in input)
	        {
		        if (char.IsLetter(ch))
                {
                    return true;
                }
	        }

            return false;
        }

        static void StoreNumbers(
            Dictionary<string, List<int>> data, 
            string name, 
            List<int> numsToAdd)
        {
            if (numsToAdd.Count == 0)
            {
                return;
            }

            if (!data.ContainsKey(name))
            {
                data.Add(name, new List<int>());
            }

            data[name].AddRange(numsToAdd);
        }

        static void PrintOutput(Dictionary<string, List<int>> data)
        {
            foreach (var record in data)
            {
                string name = record.Key;
                List<int> nums = record.Value;

                Console.WriteLine("{0} === {1}",
                    name,
                    string.Join(", ", nums));
            }
        }
    }
}
