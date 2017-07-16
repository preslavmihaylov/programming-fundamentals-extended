using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FlattenDictionary
{
    class InnerValue
    {
        public string value;
        public bool flattened;

        public InnerValue(string value, bool flattened)
        {
            this.value = value;
            this.flattened = flattened;
        }
    }

    class FlattenDictionary
    {
        static void Main()
        {
            var data = new Dictionary<string, Dictionary<string, string>>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] inputTokens =
                    input.Split(' ');

                if (inputTokens[0] != "flatten")
                {
                    string key = inputTokens[0];
                    string innerKey = inputTokens[1];
                    string value = inputTokens[2];

                    if (!data.ContainsKey(key))
                    {
                        data.Add(key, new Dictionary<string, string>());
                    }

                    data[key][innerKey] = value;
                }
                else
                {
                    string keyToFlatten = inputTokens[1];

                    data[keyToFlatten] = 
                        data[keyToFlatten].ToDictionary(r => r.Key + r.Value, r => "flattened");
                }

                input = Console.ReadLine();
            }

            var orderedData = data
                .OrderByDescending(r => r.Key.Length)
                .ToDictionary(r => r.Key, r => r.Value);

            foreach (var record in orderedData)
            {
                string key = record.Key;
                Dictionary<string, string> innerRecords = record.Value;

                Console.WriteLine(key);
                var unflattenedRecords = innerRecords
                    .Where(r => r.Value != "flattened")
                    .OrderBy(r => r.Key.Length);

                var flattenedRecords = innerRecords
                    .Where(r => r.Value == "flattened");

                int id = 1;
                foreach (var unflattenedRecord in unflattenedRecords)
                {
                    Console.WriteLine("{0}. {1} - {2}",
                        id++,
                        unflattenedRecord.Key,
                        unflattenedRecord.Value);
                }

                foreach (var flattenedRecord in flattenedRecords)
                {
                    Console.WriteLine("{0}. {1}",
                        id++,
                        flattenedRecord.Key);
                }
            }
        }
    }
}
