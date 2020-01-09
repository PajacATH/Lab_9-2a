using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Printer
    {
        public EventHandler<OutOfPaperEventArgs> OutOfPaperEvent;
        public EventHandler<OutOfInkEventArgs> OutOfInkEvent;
        private Random rand;
        private int paperCount = 1;

        private double blackInk = 1;
        private double magentaInk = 1;
        private double yellowInk = 1;
        private double cyanInk = 1;



        public void Print()
        {
            if (paperCount<0)
            {
                OutOfPaperEvent.Invoke(this, new OutOfPaperEventArgs(paperCount));
                return;
            }
            ++paperCount;

            if (rand.NextDouble() < 0.01)
            {
                OutOfPaperEvent.Invoke(this, new OutOfPaperEventArgs(paperCount));
            }

            if (blackInk <= 0)
            {

                OutOfInkEvent.Invoke(this, new OutOfInkEventArgs("Black", paperCount));
                return;
            }
            if (magentaInk <= 0)
            {

                OutOfInkEvent.Invoke(this, new OutOfInkEventArgs("Magenta", paperCount));
                return;
            }
            if (yellowInk <= 0)
            {

                OutOfInkEvent.Invoke(this, new OutOfInkEventArgs("Yellow", paperCount));
                return;
            }
            if (cyanInk <= 0)
            {

                OutOfInkEvent.Invoke(this, new OutOfInkEventArgs("Cyan", paperCount));
                return;
            }

            blackInk -= rand.NextDouble() * 0.1;
            magentaInk -= rand.NextDouble() * 0.15;
            yellowInk -= rand.NextDouble() * 0.12;
            cyanInk -= rand.NextDouble() * 0.11;

            Console.WriteLine("Printing...");
        }

        public void OutOfPaperEventHandler(object sender, OutOfPaperEventArgs args)
        {
            Console.WriteLine($"Printer OutOfPaper at {args.Page} page \n{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}");
        }

        public void OutOfInkEventHandler(object sender, OutOfInkEventArgs args)
        {
            Console.WriteLine($"Out of {args.Color} ink at  {args.Page} page \n{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}");
        }

        public Printer()
        {
            OutOfPaperEvent += OutOfPaperEventHandler;
            OutOfInkEvent += OutOfInkEventHandler;
            rand = new Random();
        }
    }
}
