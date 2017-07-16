using System;

namespace _03.Megapixels
{
    class Megapixels
    {
        static void Main()
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double result = (double)(width * height) / 1000000;
            Console.WriteLine("{0}x{1} => {2}MP", width, height, Math.Round(result, 1));
        }
    }
}
