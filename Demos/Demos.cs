using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Measurements;

namespace Demos
{
    class IntegerAllocVsClassAlloc
    {
        static readonly int arraySize = 5_000;
        static readonly int n = 5_000;

        static void Main(string[] args)
        {
            ExecutionTime.Measure("AllocateInteger", 5, () =>
            {
                for (int i = 0; i < n; i++)
                {
                    AllocateInteger(i % n);
                }
            });

            ExecutionTime.Measure("AllocateClass", 5, () =>
            {
                for (int i = 0; i < n; i++)
                {
                    AllocateClass();
                }
            });
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
