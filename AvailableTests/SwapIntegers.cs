using Measurements;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AvailableTests
{
    public class SwapIntegers : IRunnable
    {
        static Random rand = new Random();
        static int len = 1_000_000;
        static int reps = 5;
        static int[] arr1 = new int[len];
        static int[] arr2 = new int[len];

        public void Compare()
        {
            SetUp();
            ExecutionTime.Measure("bitwise xor", reps, () =>
            {
                SwapXor();
            });
            SetUp();
            ExecutionTime.Measure("temp var", reps, () =>
            {
                SwapTempVar();
            });
            SetUp();
            ExecutionTime.Measure("tuples", reps, () =>
            {
                SwapTuples();
            });
            SetUp();
            ExecutionTime.Measure("arithmetics", reps, () =>
            {
                SwapArith();
            });
            SetUp();
            ExecutionTime.Measure("Interlocked.Exchange", reps, () =>
            {
                SwapInterlock();
            });
        }

        private static void SwapInterlock()
        {
            for (int i = 0; i < len; i++)
            {
                Interlocked.Exchange(ref arr1[i], arr2[i]);
            }
        }

        private static void SwapArith()
        {
            int a, b;
            for (int i = 0; i < len; i++)
            {
                a = arr1[i];
                b = arr2[i];
                a += b;
                b = a - b;
                a -= b;
            }
        }

        private static void SwapTuples()
        {
            for (int i = 0; i < len; i++)
            {
                (arr1[i], arr2[i]) = (arr2[i], arr1[i]);
            }
        }

        private static void SwapTempVar()
        {
            int temp;
            for (int i = 0; i < len; i++)
            {
                temp = arr1[i];
                arr1[i] = arr2[i];
                arr2[i] = temp;
            }
        }

        private static void SwapXor()
        {
            for (int i = 0; i < len; i++)
            {
                arr1[i] ^= arr2[i];
                arr2[i] ^= arr1[i];
                arr1[i] ^= arr2[i];
            }
        }

        private static void SetUp()
        {
            for (int i = 0; i < len; i++)
            {
                arr1[i] = i;
                arr1[i] = i + 1;
            }
        }

    }
}