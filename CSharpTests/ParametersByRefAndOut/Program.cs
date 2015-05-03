using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersByRefAndOut
{
    class Program
    {
        static void Main(string[] args)
        {
            int Getal = 34;


            PrintByValue(Getal);
            Console.WriteLine("Parameter by Val: " + Getal.ToString());

            PrintValueByRef(out Getal);
            Console.WriteLine("Parameter by Ref: " + Getal.ToString());

            int i = 33;
            string s1 = "Hello";
            string s2 = "Ronald";
            Method(out i,out s1,out s2);

            Console.ReadKey();

        }

        private static void PrintValueByRef(out int Value)
        {
            Value = 8;
            
        }

        private static void PrintByValue(int Value)
        {
            Value = 10;
           
        }

        static void Method(out int i, out string s1, out string s2)
        {
            i = 44;
            s1 = "I've been returned";
            s2 = null;
        }



    }
}
