using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_fact_advstud
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define parameters to calculate the factorial of
            //Call fact() method to calculate

            uint number = 10;
            Console.WriteLine(Factorial(number));
            Console.ReadLine();
        }

        //Create fact() method  with parameter to calculate factorial
        //Use ternary operator
        public static uint Factorial(uint number)
        {
            return number == 0 ? 1 : Factorial(number - 1) * number;
        }
    }

    

}
