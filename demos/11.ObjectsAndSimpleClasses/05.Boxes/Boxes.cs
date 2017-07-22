using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Boxes
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static double CalculateDistance(Point first, Point second)
        {
            int deltaX = first.X - second.X;
            int deltaY = first.Y - second.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }

    class Box
    {
        public Point UpperLeft { get; set; }
        public Point UpperRight { get; set; }
        public Point BottomLeft { get; set; }
        public Point BottomRight { get; set; }

        public int Width 
        { 
            get 
            {
                return (int)Point.CalculateDistance(UpperLeft, UpperRight);
            }
        }

        public int Height
        {
            get
            {
                return (int)Point.CalculateDistance(UpperLeft, BottomLeft);
            }
        }
        
        public Box(Point upperLeft, Point upperRight, Point bottomLeft, Point bottomRight)
        {
            this.UpperLeft = upperLeft;
            this.UpperRight = upperRight;
            this.BottomLeft = bottomLeft;
            this.BottomRight = bottomRight;
        }

        public static int CalculatePerimeter(int width, int height)
        {
            return 2 * width + 2 * height;
        }

        public static int CalculateArea(int width, int height)
        {
            return width * height;
        }
    }

    class Boxes
    {
        static void Main()
        {
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] inputTokens = input
                    .Split(new string[] { " | " },
                           StringSplitOptions.RemoveEmptyEntries);

                List<Point> points = new List<Point>();
                foreach (var token in inputTokens)
                {
                    int[] dimensions = token
                        .Split(':')
                        .Select(int.Parse)
                        .ToArray();

                    points.Add(new Point(dimensions[0], dimensions[1]));
                }

                Box box = new Box(points[0], points[1], points[2], points[3]);
                Console.WriteLine("Box: {0}, {1}",
                    box.Width,
                    box.Height);

                Console.WriteLine("Perimeter: {0}",
                    Box.CalculatePerimeter(box.Width, box.Height));

                Console.WriteLine("Area: {0}",
                    Box.CalculateArea(box.Width, box.Height));

                input = Console.ReadLine();
            }
        }
    }
}
