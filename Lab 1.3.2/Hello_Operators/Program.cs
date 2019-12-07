using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloOperators_stud
{
    class Program
    {
        static void Main(string[] args)
        {
            long a;
            Console.WriteLine(@"Please,  type the number:
            1. Farmer, wolf, goat and cabbage puzzle
            2. Console calculator
            3. Factirial calculation
            ");
            
            a = long.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    Farmer_puzzle();
                    Console.WriteLine("");
                    break;
                case 2:
                    Calculator();
                    Console.WriteLine("");
                    break;
                case 3:
                    Factorial_calculation();
                    Console.WriteLine("");
                    break;
                default:
                    Console.WriteLine("Exit");
                    break;
            }
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
        #region farmer
        static void Farmer_puzzle()
        {
            //Key sequence: 3817283 or 3827183
            // Declare 7 int variables for the input numbers and other variables
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"From one bank to another should carry a wolf, goat and cabbage. 
At the same time can neither carry nor leave together on the banks of a wolf and a goat, 
a goat and cabbage. You can only carry a wolf with cabbage or as each passenger separately. 
You can do whatever how many flights. How to transport the wolf, goat and cabbage that all went well?");
            Console.WriteLine("There: farmer and wolf - 1");
            Console.WriteLine("There: farmer and cabbage - 2");
            Console.WriteLine("There: farmer and goat - 3");
            Console.WriteLine("There: farmer  - 4");
            Console.WriteLine("Back: farmer and wolf - 5");
            Console.WriteLine("Back: farmer and cabbage - 6");
            Console.WriteLine("Back: farmer and goat - 7");
            Console.WriteLine("Back: farmer  - 8");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Please,  type numbers by step ");
            // Implement input and checking of the 7 numbers in the nested if-else blocks with the  Console.ForegroundColor changing
            
            int input = int.Parse(Console.ReadLine());
            if (input == 3) 
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                input = int.Parse(Console.ReadLine());
                if (input == 8) 
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    int inputVariant= int.Parse(Console.ReadLine());
                    if (inputVariant == 1 || inputVariant == 2) 
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        input = int.Parse(Console.ReadLine());
                        if (input == 7) 
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            input = int.Parse(Console.ReadLine());
                            if (input == 2 && inputVariant != 2) 
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                input = int.Parse(Console.ReadLine());
                                if (input == 8)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    input = int.Parse(Console.ReadLine());
                                    if (input == 3)
                                    {
                                        Console.WriteLine("Congratulation, you are winner!!!");
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Sorry, but you are lose");
                                }
                            }
                            else if (input == 1 && inputVariant != 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                input = int.Parse(Console.ReadLine());
                                if (input == 8)
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    input = int.Parse(Console.ReadLine());
                                    if (input == 3)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Congratulation, you are winner!!!");
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Sorry, but you are lose");
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Sorry, but you are lose");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry, but you are lose");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, but you are lose");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry, but you are lose");
                }
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, but you are lose");
            }
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        #endregion

        #region calculator
        static void Calculator()
        {
            // Set Console.ForegroundColor  value
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"Select the arithmetic operation:
1. Multiplication 
2. Divide 
3. Addition 
4. Subtraction
5. Exponentiation ");
            // Implement option input (1,2,3,4,5)
            //     and input of  two or one numbers
            //  Perform calculations and output the result 

            int number;
            double result = 0;
            double number_one = 0;
            double number_two = 0;
            
            if(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Enter the inneger number");
                return;
            }
            Console.WriteLine();            
            switch(number)
            {
                case 1:
                    {
                        if(Enter(ref number_one, ref number_two))
                            result = number_one * number_two;
                        break;
                    }
                case 2:
                    {
                        if (Enter(ref number_one, ref number_two))
                        {
                            if (number_two != 0)
                                result = number_one / number_two;
                            else
                            { 
                                Console.WriteLine("number_two can't be zero");
                                return;
                            }
                        }                    
                        break;
                    }
                case 3:
                    {
                        if(Enter(ref number_one, ref number_two))
                            result = number_one + number_two;
                        break;
                    }
                case 4:
                    {
                        if(Enter(ref number_one, ref number_two))
                            result = number_one - number_two;
                        break;
                    }
                case 5:
                    {
                        Console.Write("Enter number: ");
                        if(!double.TryParse(Console.ReadLine(), out number_one))
                        {
                            Console.WriteLine("Incorrect number");
                            return;
                        }
                        result = 1;
                        for (int i = 0; i < Math.Abs(number_one); i++)
                        {
                            result *= Math.E;
                        }
                        if (number_one < 0)
                        {
                            result = 1 / result;
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Incorrect operation");
                        break;
                    }
            }
            Console.WriteLine("Result is: "+result);

            

        }
        #endregion

        #region Factorial
        static void Factorial_calculation()
        {
            // Implement input of the number
            // Implement input the for circle to calculate factorial of the number
            // Output the result
            Console.WriteLine();
            Console.Write("Enter a number: ");
            int number;
            int factorial = 1;

            if (int.TryParse(Console.ReadLine(), out number))
            {
                if (number < 0)
                {
                    Console.WriteLine($"Number must be more than 0");
                }
                else if (number == 0)
                {
                    Console.WriteLine($"{number} factorial is {factorial}");
                }
                else
                {
                    for (int i = number; i > 0; i--) 
                    {
                        factorial *= i;
                    }
                    Console.WriteLine($"{number} factorial is {factorial}");
                }
            }
            else
            {
                Console.WriteLine($"You must enter the integer number");
            }




        }
        #endregion

        static bool Enter(ref double number_one, ref double number_two)
        {
            Console.Write("Enter number_one: ");
            if(!double.TryParse(Console.ReadLine(), out number_one))
            {
                Console.WriteLine("Incorrect number");
                return false;
            }
            Console.Write("Enter number_two: ");
            if(!double.TryParse(Console.ReadLine(), out number_two))
            {
                Console.WriteLine("Incorrect number");
                return false;
            }
            return true;
        }
    }
}
