using System;
using System.Collections.Generic;
using System.Reflection;
using Library.Tests;

namespace Presentation.ConsoleUI
{
    internal class UserInterface
    {
        internal static void Menu()
        {
            IRunnable runnable = null;
            Console.WriteLine("Tests Available:");
            var tests = Tests();
            int n = 0;
            string choice = "-1";
            Type type = null;

            while (choice != "0")
            {
                foreach (IRunnable test in tests)
                {
                    //type = test.GetType();
                    //PropertyInfo property = type.GetProperty("FriendlyName");
                    //Console.WriteLine(property.GetValue(type));
                    //Console.WriteLine(type.GetProperty("FriendlyName").GetValue(type, null));

                    //var prop = typeof(IRunnable).GetProperty("friendlyname");
                    //string friendlyname = prop.GetValue(type, new object[] { });
                    //Console.WriteLine($"{++n}: {friendlyname}");

                    Console.WriteLine($"{++n}: {test.GetType().Name}");
                    runnable = test;
                }
                n = 0;
                Console.WriteLine("0: quit");
                Console.WriteLine();
                Console.Write("> ");
                choice = Console.ReadLine();
                TryExecuteTest(runnable, tests, choice);

                // get results
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
