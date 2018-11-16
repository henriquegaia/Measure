using System;
using System.Collections.Generic;
using AvailableTests;

namespace Demos
{
    class UserInterface
    {
        public static void Menu2()
        {
            IRunnable runnable = null;
            Console.WriteLine("Tests Available:");
            var tests = Tests();
            int n = 0;
            string choice = "-1";

            while(choice != "0")
            {
                foreach (IRunnable test in tests)
                {
                    Console.WriteLine($"{++n}: {test.GetType().Name}");
                    runnable = test;
                }
                n = 0;
                Console.WriteLine("0: quit");
                Console.WriteLine();
                Console.Write("> ");
                choice = Console.ReadLine();
                TryExecuteTest(runnable, tests, choice);
            }
            Environment.Exit(0);
        }

        private static void TryExecuteTest(IRunnable runnable, List<IRunnable> tests, string choice)
        {
            int.TryParse(choice, out int choiceInt);
            if (choiceInt > 0 && choiceInt < tests.Count + 1)
            {
                runnable.Compare();
            }
        }

        public static void Menu()
        {
            IRunnable runnable;

            Console.WriteLine("Enter choice (1-4): ");
            string input = Console.ReadLine();
            int choice = 0;
            int.TryParse(input, out choice);

            switch (choice)
            {
                case 0:
                    runnable = null;
                    Environment.Exit(0);
                    break;
                case 1:
                    runnable = new IntegerAllocVsClassAlloc();
                    break;
                case 2:
                    runnable = new SwapIntegers();
                    break;
                case 3:
                    runnable = new LazyDictionary();
                    break;
                case 4:
                    runnable = new Memoization();
                    break;
                default:
                    runnable = null;
                    break;
            }

            runnable.Compare();
        }

        private static List<IRunnable> Tests()
        {
            return new List<IRunnable>()
            {
                new IntegerAllocVsClassAlloc(),
                new SwapIntegers(),
                new LazyDictionary(),
                new Memoization()
            };
        }
    }
}
