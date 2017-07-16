using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SocialMediaPosts
{
    class SocialMediaPosts
    {
        static Dictionary<string, Dictionary<string, string>> postsData;
        static Dictionary<string, int> postLikes;
        static Dictionary<string, int> postDislikes;

        static void Main()
        {
            postsData = new Dictionary<string, Dictionary<string, string>>();
            postLikes = new Dictionary<string, int>();
            postDislikes = new Dictionary<string, int>();

            string[] inputTokens = ReadInputTokens(Console.ReadLine());
            while (!IsDrop(inputTokens[0]))
            {
                string cmd = inputTokens[0];
                string postName = inputTokens[1];
                switch (cmd)
                {
                    case "post":
                    {
                        CreatePost(postName);
                        break;
                    }
                    case "like":
                    {
                        LikePost(postName);
                        break;
                    }
                    case "dislike":
                    {
                        DislikePost(postName);
                        break;
                    }
                    case "comment":
                    {
                        string commentatorName = inputTokens[2];
                        string commentContent = 
                            string.Join(" ", inputTokens.Skip(3));

                        CommentPost(postName, commentatorName, commentContent);
                        break;
                    }
                }

                inputTokens = ReadInputTokens(Console.ReadLine());
            }

            PrintOutputData();
        }

        static string[] ReadInputTokens(string input)
        {
            return input.Split(' ');
        }

        static bool IsDrop(string input)
        {
            return (input == "drop");
        }

        static void CreatePost(string postName)
        {
            postsData.Add(postName, new Dictionary<string, string>());
            postLikes.Add(postName, 0);
            postDislikes.Add(postName, 0);
        }

        static void LikePost(string postName)
        {
            postLikes[postName]++;
        }

        static void DislikePost(string postName)
        {
            postDislikes[postName]++;
        }

        static void CommentPost(string postName, 
            string commentatorName, 
            string commentContent)
        {
            postsData[postName].Add(commentatorName, commentContent);
        }

        static void PrintOutputData()
        {
            foreach (var postData in postsData)
            {
                string postName = postData.Key;
                Dictionary<string, string> commentsData = postData.Value;

                Console.WriteLine("Post: {0} | Likes: {1} | Dislikes: {2}",
                    postName, postLikes[postName], postDislikes[postName]);

                Console.WriteLine("Comments:");
                if (commentsData.Count == 0)
                {
                    Console.WriteLine("None");
                }

                foreach (var commentData in commentsData)
                {
                    string commentatorName = commentData.Key;
                    string commentContent = commentData.Value;

                    Console.WriteLine("*  {0}: {1}",
                        commentatorName, 
                        commentContent);
                }
            }
        }
    }
}
