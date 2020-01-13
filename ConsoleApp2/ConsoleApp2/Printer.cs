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

        //private double blackInk = 1;
        //private double magentaInk = 1;
        //private double yellowInk = 1;
        //private double cyanInk = 1;

        class Ink
        {
            public double Level { get; set; }
            public string Color { get; set; }

            public Ink(string color)
            {
                Color = color;
                Level = 1;
            }
        }

        private List<Ink> inks;

        public void Print()
        {
            if (paperCount<0)
            {
                OutOfPaperEvent.Invoke(this, new OutOfPaperEventArgs(paperCount));
                return;
            }
            ++paperCount;

            Console.WriteLine("Printing...");

            inks.ForEach(x =>
                {
                    x.Level -= rand.NextDouble() * 0.08;
                    if(x.Level <= 0)
                    {
                        OutOfInkEvent.Invoke(this, new OutOfInkEventArgs(x.Color, paperCount));
                        return;
                    }
                });
                

            //if (OutOfInkEvent. <= 0)
            //{

            //    OutOfInkEvent.Invoke(this, new OutOfInkEventArgs("Black", paperCount));
            //    return;
            //}
            //if (magentaInk <= 0)
            //{

            //    OutOfInkEvent.Invoke(this, new OutOfInkEventArgs("Magenta", paperCount));
            //    return;
            //}
            //if (yellowInk <= 0)
            //{

            //    OutOfInkEvent.Invoke(this, new OutOfInkEventArgs("Yellow", paperCount));
            //    return;
            //}
            //if (cyanInk <= 0)
            //{

            //    OutOfInkEvent.Invoke(this, new OutOfInkEventArgs("Cyan", paperCount));
            //    return;
            //}

            //blackInk -= rand.NextDouble() * 0.1;
            //magentaInk -= rand.NextDouble() * 0.15;
            //yellowInk -= rand.NextDouble() * 0.12;
            //cyanInk -= rand.NextDouble() * 0.11;
        }

        public void OutOfPaperEventHandler(object sender, OutOfPaperEventArgs args)
        {
            Console.WriteLine($"Printer OutOfPaper at {args.Page} page \n{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}");
        }

        public void OutOfInkEventHandler(object sender, OutOfInkEventArgs args)
        {
            Console.WriteLine($"Printer out of {args.Color} ink at  {args.Page} page \n{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}");
        }

        public Printer()
        {
            OutOfPaperEvent += OutOfPaperEventHandler;
            OutOfInkEvent += OutOfInkEventHandler;
            rand = new Random();

            inks = new List<Ink>();
            inks.Add(new Ink("Black"));
            inks.Add(new Ink("Magenta"));
            inks.Add(new Ink("Yellow"));
            inks.Add(new Ink("Cyan"));
        }
    }
}
