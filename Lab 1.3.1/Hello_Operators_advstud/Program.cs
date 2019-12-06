using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Operators_advstud
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MyMax = 200;

            Random random = new Random();
            // random.Next(MaxValue) returns a 32-bit signed integer that is greater than or equal to 0 and less than MaxValue
            int guessNumber = random.Next(MyMax) + 1;
            // implement input of number and comparison result message in the while circle with  comparison condition
            int inputNumber;
            byte count=0;
            Console.Write("Enter a number between 0 and 200: ");
            int.TryParse(Console.ReadLine(), out inputNumber);
            while (inputNumber != guessNumber)
            {
                count++;
                Console.Write("You don't guess, please enter a number again: ");
                int.TryParse(Console.ReadLine(), out inputNumber);
                if (count > 4)
                {
                    string hint = guessNumber < inputNumber ? $"Number less than {inputNumber}" 
                        : $"Number more than {inputNumber}";
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(hint);
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Congratulation, the number is {guessNumber}");
            Console.ReadLine();


        }
    }
}
