using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class OutOfPaperEventArgs
    {
        public int Page { get; set; }
        public OutOfPaperEventArgs(int page)
        {
            Page = Page;
        }
    }
}
