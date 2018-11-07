using Measurements;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Demos
{
    class Memoization:IRunnable
    {
        public void Compare()
        {
            int reps = 5;
            int its = 50000;
            int n = 45;

            Console.WriteLine($"n = {n}");
            Console.WriteLine();

            ExecutionTime.Measure("baseline", reps, () =>
            {
                for (int i = 0; i < its; i++)
                {
                    Utils.FindPrime(n);
                }
            });

            var memFunc = Utils.Memoize<long, long>(Utils.FindPrime);

            ExecutionTime.Measure("memo", reps, () =>
            {
                for (int i = 0; i < its; i++)
                {
                    memFunc(n);
                }
            });

        }

    }
}
