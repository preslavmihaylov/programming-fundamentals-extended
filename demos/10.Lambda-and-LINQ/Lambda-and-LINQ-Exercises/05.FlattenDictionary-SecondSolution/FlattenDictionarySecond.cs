using System;
using System.Linq;
using System.Collections.Generic;

class FlattenDictionarySecond
{
    static void Main()
    {
        var data =
            new Dictionary<string, Dictionary<string, string>>();
        var flattenedData = new Dictionary<string, List<string>>();

        string input = Console.ReadLine();
        while (input != "end")
        {
            string[] inputTokens = input.Split(' ');

            if (inputTokens[0] == "flatten")
            {
                string keyToFlatten = inputTokens[1];

                foreach (var record in data)
                {
                    string key = record.Key;
                    var innerRecords = record.Value;
                    if (key == keyToFlatten)
                    {
                        foreach (var innerRecord in innerRecords)
                        {
                            string flattenedValue =
                                innerRecord.Key + innerRecord.Value;

                            if (!flattenedData.ContainsKey(key))
                            {
                                flattenedData.Add(key, new List<string>());
                            }
                            flattenedData[key].Add(flattenedValue);
                        }
                    }
                }

                data[keyToFlatten] = new Dictionary<string, string>();
            }
            else
            {
                string key = inputTokens[0];
                string innerKey = inputTokens[1];
                string innerValue = inputTokens[2];

                if (!data.ContainsKey(key))
                {
                    data.Add(key, new Dictionary<string, string>());
                }

                if (!data[key].ContainsKey(innerKey))
                {
                    data[key].Add(innerKey, "");
                }

                data[key][innerKey] = innerValue;
            }

            input = Console.ReadLine();
        }

        var orderedData = data
            .OrderByDescending(kvp => kvp.Key.Length);

        foreach (var record in orderedData)
        {
            string key = record.Key;
            var innerRecords = record.Value;
            var orderedInnerRecords = innerRecords
                .OrderBy(kvp => kvp.Key.Length);

            Console.WriteLine("{0}", key);

            int orderId = 1;
            foreach (var innerRecord in orderedInnerRecords)
            {
                Console.WriteLine("{0}. {1} - {2}",
                    orderId,
                    innerRecord.Key,
                    innerRecord.Value);

                orderId++;
            }

            if (flattenedData.ContainsKey(key))
            {
                foreach (var flattenedValue in flattenedData[key])
                {
                    Console.WriteLine("{0}. {1}", orderId, flattenedValue);
                    orderId++;
                }
            }
        }
    }
}
