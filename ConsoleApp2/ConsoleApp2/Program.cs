using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static bool ReadyToPrint = true;
        static void Main()
        {
            var printer = new Printer();
            printer.OutOfPaperEvent += OutOfPaperEventHandler2;
            printer.OutOfInkEvent += OutOfInkEventHandler2;

            for (int i = 0; i < 50; i++)
            {
                printer.Print();
                if (!ReadyToPrint)
                {
                    break;
                }
            }
        }

        static void OutOfPaperEventHandler2(object sender, OutOfPaperEventArgs args)
        {
            Console.WriteLine("Main out of paper event handler");
            ReadyToPrint = false;
        }

        static void OutOfInkEventHandler2(object sender, OutOfInkEventArgs args)
        {
            Console.WriteLine("Main out of ink event handler");
            ReadyToPrint = false;
        }
    }
}
