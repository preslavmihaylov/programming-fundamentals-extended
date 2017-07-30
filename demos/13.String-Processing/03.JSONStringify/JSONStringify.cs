using System;
using System.Text;

class JSONStringify
{
    static void Main()
    {
        string input = Console.ReadLine();

        StringBuilder output = new StringBuilder();
        while (input != "stringify")
        {
            string[] tokens = input
                .Split(new string[] { " : ", " ->" },
                       StringSplitOptions.RemoveEmptyEntries);

            string name = tokens[0];
            string age = tokens[1];
            string[] grades = new string[] { };

            if (tokens.Length > 2)
            {
                grades = tokens[2]
                    .Split(new string[] { ",", " " },
                       StringSplitOptions.RemoveEmptyEntries);
            }

            if (output.Length != 0)
            {
                output.Append(",");
            }

            output.Append("{");
            output.Append(
                string.Format("name:\"{0}\",age:{1},grades:[{2}]",
                    name, age, string.Join(", ", grades)));
            output.Append("}");
            
            input = Console.ReadLine();
        }

        Console.WriteLine("[{0}]", output.ToString());
    }
}