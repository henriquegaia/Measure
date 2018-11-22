using Library.Benchmark;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Library.Tests
{
    public class Memoization:Test, IRunnable
    {
        public string FriendlyName => "Recurring Results - Memoization or Not";

        public void Compare()
        {
            int reps = 5;
            int its = 50000;
            int n = 45;

            Console.WriteLine($"n = {n}");
            Console.WriteLine();

            Execution.Measure("baseline", reps, () =>
            {
                for (int i = 0; i < its; i++)
                {
                    Utilities.FindPrime(n);
                }
            });

            var memFunc = Utilities.Memoize<long, long>(Utilities.FindPrime);

            Execution.Measure("memo", reps, () =>
            {
                for (int i = 0; i < its; i++)
                {
                    memFunc(n);
                }
            });

        }

    }
}
