using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new MySentence();

            {
                Console.WriteLine(s[3]);
            }
            
            Console.Read();
        }

        class MySentence
        {
            string[] words = "Het is vandaag Zondag 3 Mei, over 2 dagen is het bevrijdingsdag!".Split();

            public string this[int index]
            {
                get { return words[index]; }
                set { words[index] = value; }
            }

        }




    }
}
