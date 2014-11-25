using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEuler
{
    class Program
    {


        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"E:\LocalDocs\Documents\3DS XL ombouw.txt"))
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    Console.WriteLine(line);
                }
            }
            Console.ReadLine();
        }





    }
}
