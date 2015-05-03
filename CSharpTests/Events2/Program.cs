using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events2
{
    class Program
    {
        static void Main(string[] args)
        {
            



        }

        public event NumberReachedEventHandler NumberReached;


        public delegate void NumberReachedEventHandler(object sender, NumberReachedEventArgs e);




    }
}
