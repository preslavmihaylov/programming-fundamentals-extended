using System;

namespace _04.PhotoGallery
{
    class PhotoGallery
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int hour = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            string orientation = "";
            double transformedSize = 0;
            string unit = "";

            if (size < 1000)
            {
                transformedSize = size;
                unit = "B";
            }
            else if (size < 1000 * 1000)
            {
                transformedSize = size / 1000.0;
                unit = "KB";
            }
            else if (size < 1000 * 1000 * 1000)
            {
                unit = "MB";
                transformedSize = size / (1000 * 1000.0);
            }

            if (width > height)
            {
                orientation = "landscape";
            }
            else if (width < height)
            {
                orientation = "portrait";
            }
            else
            {
                orientation = "square";
            }


            Console.WriteLine("Name: DSC_{0}.jpg", number.ToString().PadLeft(4, '0'));
            Console.WriteLine("Date Taken: {0}/{1}/{2} {3}:{4}",
                day.ToString().PadLeft(2, '0'), 
                month.ToString().PadLeft(2, '0'), 
                year, 
                hour.ToString().PadLeft(2, '0'), 
                minutes.ToString().PadLeft(2, '0'));

            Console.WriteLine("Size: {0}{1}", 
                transformedSize, unit);
            Console.WriteLine("Resolution: {0}x{1} ({2})",
                width, height, orientation);
        }
    }
}
