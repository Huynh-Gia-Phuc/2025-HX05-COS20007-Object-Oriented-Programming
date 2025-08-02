using System;

namespace SimpleClockApp
{
    // Simple Counter class
    public class SimpleCounter
    {
        private long _count;
        private string _name;

        public SimpleCounter(string name) 
        {
            _name = name;
            _count = 0;
        }

        public void Increment() 
        {
            _count += 1;
        }

        public void Reset()
        {
            _count = 0;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public long Ticks 
        {
            get { return _count; }
        }
    }

    internal class Program
    {
        private static void PrintCounters(SimpleCounter[] counters)
        {
            foreach (SimpleCounter counter in counters)
            {
                Console.WriteLine("Name is " + counter.Name);
                Console.WriteLine("Tick is " + counter.Ticks);
            }
        }

        static void Main(string[] args) 
        {
            Console.WriteLine("=== Simple Clock Application with Memory Monitoring ===\n");
            
            SimpleCounter[] myCounters = new SimpleCounter[3];

            myCounters[0] = new SimpleCounter("Counter 1");
            myCounters[1] = new SimpleCounter("Counter 2");
            myCounters[2] = myCounters[0];

            for (int i = 0; i < 9; i++)
            {
                myCounters[0].Increment();
            }
            for (int i = 0; i < 14; i++)
            {
                myCounters[1].Increment();
            }

            Console.WriteLine("Before Reset:");
            PrintCounters(myCounters);
            
            myCounters[2].Reset();
            
            Console.WriteLine("\nAfter Reset:");
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
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
} 