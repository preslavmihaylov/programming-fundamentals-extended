using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Exercises
{
    class Exercise
    {
        public string Topic { get; set; }
        public string ClassName { get; set; }
        public string JudgeLink { get; set; }
        public List<string> Problems { get; set; }

        public Exercise(string topic, string className, string judgeLink, List<string> problems)
        {
            this.Topic = topic;
            this.ClassName = className;
            this.JudgeLink = judgeLink;
            this.Problems = problems;
        }
    }

    class Exercises
    {
        static void Main()
        {
            List<Exercise> exercises = new List<Exercise>();

            string input = Console.ReadLine();
            while (input != "go go go")
            {
                string[] inputTokens = input
                    .Split(new string[] { " -> " },
                           StringSplitOptions.RemoveEmptyEntries);

                string topic = inputTokens[0];
                string courseName = inputTokens[1];
                string judgeLink = inputTokens[2];
                List<string> problems = inputTokens[3]
                    .Split(new string[] { ", " },
                           StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                exercises.Add(new Exercise(topic, courseName, judgeLink, problems));

                input = Console.ReadLine();
            }

            foreach (var exercise in exercises)
            {
                Console.Write("Exercises: ");
                Console.WriteLine(exercise.Topic);
                Console.WriteLine("Problems for exercises and homework for the \"{0}\" course @ SoftUni.", 
                                  exercise.ClassName);
                Console.WriteLine("Check your solutions here: {0}", exercise.JudgeLink);

                int cnt = 1;
                foreach (var problem in exercise.Problems)
                {
                    Console.WriteLine("{0}. {1}", cnt, problem);
                    ++cnt;
                }
            }
        }
    }
}
