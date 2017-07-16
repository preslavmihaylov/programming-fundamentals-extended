using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Wardrobe
    {
        static Dictionary<string, Dictionary<string, int>> data =
            new Dictionary<string, Dictionary<string, int>>();
        static void Main()
        {
            StoreClothesData();
            ProcessClothSearchQuery();
        }

        static void StoreClothesData()
        {
            int inputCnt = int.Parse(Console.ReadLine());

            for (int cnt = 0; cnt < inputCnt; cnt++)
            {
                string[] inputTokens = Console.ReadLine()
                    .Split(new string[] { " -> " },
                           StringSplitOptions.RemoveEmptyEntries);

                string color = inputTokens[0];
                string[] clothes = inputTokens[1].Split(',');

                StoreColorData(color, clothes);
            }
        }

        static void StoreColorData(string color, string[] clothes)
        {
            if (!data.ContainsKey(color))
            {
                data.Add(color, new Dictionary<string, int>());
            }

            foreach (var cloth in clothes)
            {
                if (!data[color].ContainsKey(cloth))
                {
                    data[color].Add(cloth, 0);
                }

                data[color][cloth]++;
            }
        }

        static void ProcessClothSearchQuery()
        {
            string[] inputTokens = Console.ReadLine().Split(' ');
            string searchedColor = inputTokens[0];
            string searchedCloth = inputTokens[1];

            foreach (var colorsData in data)
            {
                string color = colorsData.Key;
                Dictionary<string, int> clothesData = colorsData.Value;

                PrintColorData(color, 
                    clothesData, 
                    searchedColor, 
                    searchedCloth);
            }
        }

        static void PrintColorData(
            string color, 
            Dictionary<string, int> clothesData,
            string searchedColor,
            string searchedCloth)
        {

            Console.WriteLine("{0} clothes:", color);
            foreach (var clothData in clothesData)
            {
                string cloth = clothData.Key;
                int quantity = clothData.Value;

                Console.Write("* {0} - {1}",
                    cloth,
                    quantity);

                if (searchedColor == color &&
                    searchedCloth == cloth)
                {
                    Console.Write(" (found!)");
                }

                Console.WriteLine();
            }
        }
    }
}
