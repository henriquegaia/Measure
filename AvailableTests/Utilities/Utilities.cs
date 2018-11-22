using System;
using System.Collections.Concurrent;

namespace Library.Tests
{
    internal static class Utilities
    {
        public static Func<Argu, Ret> Memoize<Argu, Ret>(this Func<Argu, Ret> functor)
        {
            var memoTable = new ConcurrentDictionary<Argu, Ret>();
            return (arg0) =>
            {
                if (!memoTable.TryGetValue(arg0, out Ret funcReturnVal))
                {
                    funcReturnVal = functor(arg0);
                    memoTable.TryAdd(arg0, funcReturnVal);
                }
                return funcReturnVal;
            };
        }

        public static long FindPrime(long num)
        {
            long count = 0;

            for (long i = 0; i <= num; i++)
            {
                bool isPrime = true; // Move initialization to here
                for (long j = 2; j < i; j++) // you actually only need to check up to sqrt(i)
                {
                    if (i % j == 0) // you don't need the first condition
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    count++;
                    //Console.WriteLine("Prime:" + i);
                }
                // isPrime = true;
            }
            return count;
        }

    }
}
