using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Measurements
{
    public class ExecutionTime
    {
        public static void Measure(string what, int reps, Action action)
        {
            System.Runtime.GCSettings.LatencyMode = System.Runtime.GCLatencyMode.Batch;

            action();

            double[] results = new double[reps];

            for (int i = 0; i < reps; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                action();
                sw.Stop();
                results[i] = sw.Elapsed.TotalMilliseconds;
                Console.WriteLine($"repetition {i}: {results[i]} Milliseconds");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{what} - average = {results.Average()}, min = {results.Min()}, max = {results.Max()}");
            Console.ForegroundColor = ConsoleColor.White;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
