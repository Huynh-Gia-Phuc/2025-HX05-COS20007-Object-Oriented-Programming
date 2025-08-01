﻿using System;

namespace ClockTask
{
    internal class Program
    {
        private static void PrintCounters(Counter[] counters)
        {
            foreach (Counter counter in counters)
            {
                Console.WriteLine("Name is " + counter.Name );
                Console.WriteLine("Tick is " + counter.Ticks );
            }
        }

        static void Main(string[] args) 
        {
            Counter[] myCounters = new Counter[3];

            myCounters[0] = new Counter("Counter 1");
            myCounters[1] = new Counter("Counter 2");
            myCounters[2] = myCounters[0];

            for (int i = 0; i < 9; i++)
            {
                myCounters[0].Increment();
            }
            for (int i = 0; i < 14; i++)
            {
                myCounters[1].Increment();
            }

            PrintCounters(myCounters);
            myCounters[2].Reset();
            PrintCounters(myCounters);

            // Memory usage monitoring using alternative methods
            Console.WriteLine("\n=== Memory Usage Statistics ===");
            
            // Method 1: Using GC.GetTotalMemory() - managed heap memory
            long managedMemory = GC.GetTotalMemory(false);
            Console.WriteLine("Managed heap memory: {0:N0} bytes ({1:F2} MB)", managedMemory, managedMemory / 1024.0 / 1024.0);
            
            // Method 2: Using Environment.WorkingSet - process working set
            long workingSet = Environment.WorkingSet;
            Console.WriteLine("Process working set: {0:N0} bytes ({1:F2} MB)", workingSet, workingSet / 1024.0 / 1024.0);
            
            // Method 3: Force garbage collection and measure again
            GC.Collect();
            GC.WaitForPendingFinalizers();
            long memoryAfterGC = GC.GetTotalMemory(true);
            Console.WriteLine("Memory after GC: {0:N0} bytes ({1:F2} MB)", memoryAfterGC, memoryAfterGC / 1024.0 / 1024.0);
            
            // Method 4: Get available system memory
            long availableMemory = GC.GetGCMemoryInfo().TotalAvailableMemoryBytes;
            Console.WriteLine("Available system memory: {0:N0} bytes ({1:F2} MB)", availableMemory, availableMemory / 1024.0 / 1024.0);
        }

    }
}