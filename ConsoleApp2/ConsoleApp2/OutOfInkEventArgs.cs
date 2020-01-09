using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    public class OutOfInkEventArgs : EventArgs
    {
        public OutOfInkEventArgs(string color, int page)
        {
            Color = color;
            Page = page;
        }

        public string Color { get; set; }
        public int Page { get; set; }

    }
}
