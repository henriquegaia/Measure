using System;

namespace Demos
{
    class UserInterface
    {
        public static void ShowMenu()
        {
            IRunnable runnable;

            Console.WriteLine("Enter choice (1-4): ");
            string input = Console.ReadLine();
            int choice = 0;
            int.TryParse(input, out choice);

            switch (choice)
            {
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
    }
}
