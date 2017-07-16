using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ForumTopics
{
    class ForumTopics
    {
        static void Main()
        {
            var data = 
                new Dictionary<string, HashSet<string>>();

            string[] inputTokens = 
                ParseInputTokens(Console.ReadLine());
            
            while (inputTokens[0] != "filter")
            {
                string topic = inputTokens[0];
                string[] tags = ParseTags(inputTokens[1]);

                StoreTags(data, topic, tags);

                inputTokens = ParseInputTokens(Console.ReadLine());
            }

            string[] filteredTags = ParseTags(Console.ReadLine());
            PrintTopicsByFilteredTags(data, filteredTags);
        }

        static string[] ParseInputTokens(string input)
        {
            return input
                .Split(new string[] { " -> " },
                       StringSplitOptions.RemoveEmptyEntries);
        }

        static string[] ParseTags(string input)
        {
            return input
                .Split(new string[] { ", " },
                       StringSplitOptions.RemoveEmptyEntries);
        }

        static void StoreTags(
            Dictionary<string, HashSet<string>> data,
            string topic,
            string[] tags)
        {
            if (!data.ContainsKey(topic))
            {
                data.Add(topic, new HashSet<string>());
            }

            foreach (var tag in tags)
            {
                data[topic].Add(tag);
            }
        }

        static void PrintTopicsByFilteredTags(
            Dictionary<string, HashSet<string>> data,
            string[] filteredTags)
        {
            foreach (var topicData in data)
            {
                string topic = topicData.Key;
                HashSet<string> tags = topicData.Value;
                if (ContainsAllTags(tags, filteredTags))
                {
                    var hashtaggedTags = tags.Select(t => "#" + t);
                    Console.WriteLine("{0} | {1}",
                        topic,
                        string.Join(", ", hashtaggedTags));
                }            
            }
        }

        static bool ContainsAllTags(
            HashSet<string> tags, 
            string[] filteredTags)
        {
            foreach (var ft in filteredTags)
            {
                if (!tags.Contains(ft))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
