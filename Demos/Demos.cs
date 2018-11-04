using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Measurements;

namespace Demos
{
    class Demo
    {
        static void Main(string[] args)
        {
            ShowMenu();
        }

        private static void ShowMenu()
        {
            IRunnable runnable;

            Console.WriteLine("Enter choice (1-2): ");
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
                default:
                    runnable = null;
                    break;
            }

            runnable.Compare();
        }
    }
}
