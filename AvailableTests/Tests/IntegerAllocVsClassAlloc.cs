using Library.Benchmark;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Tests
{
    public class IntegerAllocVsClassAlloc: Test, IRunnable
    {
        static readonly int arraySize = 5_000;
        static readonly int n = 5_000;
        static readonly int reps = 5;

        public string FriendlyName => "Allocation - Integer Vs Class";

        public void Compare()
        {
            var a = Execution.Measure("AllocateInteger", reps, () =>
            {
                for (int i = 0; i < n; i++)
                {
                    AllocateInteger(i % n);
                }
            });

            var b = Execution.Measure("AllocateClass", reps, () =>
            {
                for (int i = 0; i < n; i++)
                {
                    AllocateClass();
                }
            });

            Results.Add(FriendlyName, a);
            Results.Add(FriendlyName, b);
        }

        private static void AllocateInteger(int val)
        {
            int[] arr = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                arr[i] = val;
            }
        }

        private static void AllocateClass()
        {
            IntegerAllocVsClassAlloc[] arr = new IntegerAllocVsClassAlloc[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                arr[i] = new IntegerAllocVsClassAlloc();
            }
        }

        
    }
}
