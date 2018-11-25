using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Library.Benchmark
{
    public class Execution
    {
        public Dictionary<int, string> Repetitions { get; private set; }
        public IEnumerable<string> Results { get; set; }

        public Execution() => Repetitions = new Dictionary<int, string>();

        public void Measure(string what, int reps, Action action)
        {
            System.Runtime.GCSettings.LatencyMode = System.Runtime.GCLatencyMode.Batch;
            double[] results = new double[reps];
            double min, max, avg;
            string rep;

            action();

            for (int i = 0; i < reps; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                action();
                sw.Stop();
                results[i] = sw.Elapsed.TotalMilliseconds;
                rep = $"repetition {i}: {results[i]} Milliseconds";
                Repetitions[i] = rep;
                Console.WriteLine(rep);
            }

            min = results.Min();
            max = results.Max();
            avg = results.Average();

            Result result = new Result(what, avg, min, max);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{what} - average = {avg}, min = {min}, max = {max}");
            Console.ForegroundColor = ConsoleColor.White;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
