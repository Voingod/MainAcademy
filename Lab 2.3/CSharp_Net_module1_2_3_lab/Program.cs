using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Net_module1_2_3_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 10) declare 2 objects
            Money dollar = new Money(30, CurrencyTypes.USD);
            Money euro = new Money(50, CurrencyTypes.EU);
            // 11) do operations
            // add 2 objects of Money
            Console.WriteLine(dollar + euro);
            // add 1st object of Money and double
            Console.WriteLine(dollar + 20.15);
            // decrease 2nd object of Money by 1 
            Console.WriteLine(euro--);
            // increase 1st object of Money
            Console.WriteLine(euro * 3);
            // compare 2 objects of Money
            Console.WriteLine(euro > dollar);
            Console.WriteLine(euro < dollar);
            // compare 2nd object of Money and string
            Console.WriteLine(euro > "13");
            Console.WriteLine(euro < "13");
            Console.WriteLine(euro > "1g3");
            Console.WriteLine(euro < "13f");
            // check CurrencyType of every object
            if (dollar)
            {
                Console.WriteLine(dollar);
            }
            if (euro)
            {
                Console.WriteLine(euro);
            }
            dollar.CurrencyType = CurrencyTypes.UAH;
            if (dollar)
            {
                Console.WriteLine("Working");
            }
            else
            {
                Console.WriteLine("No working");
            }
            // convert 1st object of Money to string
            string dolString = dollar.ToString();
            Console.WriteLine(dolString);

            double money = (double)euro;
            Console.WriteLine(money);

            string moneyString = (string)euro;
            Console.WriteLine(moneyString);

            euro = (Money)89.93;
            Console.WriteLine(euro);

            euro = (Money)"99,93";
            Console.WriteLine(euro);

            euro = (Money)"89.93";
            Console.WriteLine(euro);
            Console.ReadLine();

        }
    }
}
