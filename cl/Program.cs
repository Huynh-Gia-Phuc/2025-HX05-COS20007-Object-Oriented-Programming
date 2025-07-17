using System;

namespace cl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            Console.WriteLine("Initial time: " + clock);
            for (int i = 0; i < 10; i++)
            {
                clock.ClockTick();
                Console.WriteLine($"After tick {i + 1}: {clock}");
            }
        }
    }
}