using CodedHomes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedHomes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Klik op willekeurige toets om de database te genereren.");
            Console.ReadLine();

            Console.WriteLine("Initializing Database...");

            DataContext context = new DataContext();
            context.Database.Initialize(true);

            Console.WriteLine("Initialize Done...");
            Console.WriteLine("...druk op toets om dit scherm te sluiten.");
            Console.ReadLine();

        }
    }
}
