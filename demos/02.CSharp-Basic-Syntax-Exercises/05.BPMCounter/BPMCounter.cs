using System;

namespace _05.BPMCounter
{
    class BPMCounter
    {
        static void Main()
        {
            double bpm = int.Parse(Console.ReadLine());
            double beats = int.Parse(Console.ReadLine());
            int minutes = 0;
            int seconds = 0;

            double bars = beats / 4.0;
            seconds = (int)((beats / bpm) * 60);
            minutes = seconds / 60;
            seconds = seconds % 60;

            Console.WriteLine("{0} bars - {1}m {2}s", 
                Math.Round(bars, 1), minutes, seconds);
        }
    }
}
