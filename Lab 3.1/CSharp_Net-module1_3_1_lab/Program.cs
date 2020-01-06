using System;
using System.IO;

namespace CSharp_Net_module1_3_1_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            CatchExceptionClass cec = new CatchExceptionClass();
            cec.CatchExceptionMethod();

            // 11) Make some unhandled exception and study Visual Studio debugger report – 
            // read description and find the reason of exception

            int value = 780000000;
            {
                int square = value * value;
                Console.WriteLine(square);
            }
            unchecked
            {
                int square = value * value;
                Console.WriteLine(square);
            }
            checked
            {
                int square = value * value;
                Console.WriteLine(square);
            }
            Console.ReadLine();
        }
    }
}
