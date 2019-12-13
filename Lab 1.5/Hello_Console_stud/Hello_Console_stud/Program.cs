using System;
using System.Threading;

namespace Hello_Console_stud
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            try
            {
                do
                {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(@"Please,  type the number:
                    1.  f(a,b) = |a-b| (unary)
                    2.  f(a) = a (binary)
                    3.  music
                    4.  morse sos
          
                    ");
                    try
                    {
                        a = (int)uint.Parse(Console.ReadLine());
                        switch (a)
                        {
                            case 1:
                                My_strings();
                                Console.WriteLine("");
                                break;
                            case 2:
                                My_Binary();
                                Console.WriteLine("");
                                break;
                            case 3:
                                My_music();
                                Console.WriteLine("");
                                break;
                            case 4:
                                Morse_code();
                                Console.WriteLine("");
                                break;                   
                            default:
                                Console.WriteLine("Exit");
                                break;
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error"+e.Message);
                    }                   
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Press Spacebar to exit; press any key to continue");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #region ToFromBinary
        static void My_Binary()
        {
            //Implement positive integer variable input

            Console.Write("Input positive integer variable: ");

            //Present it like binary string
            //   For example, 4 as 100

            //Use modulus operator to obtain the remainder  (n % 2) 
            //and divide variable by 2 in the loop
            string toBinary = null;
            if (!uint.TryParse(Console.ReadLine(), out uint number))
            {
                Console.WriteLine("It is not positive integer variable");
                return;
            }
            else
            {
                for (uint i = number; i > 0; i /= 2) 
                {
                    toBinary+= i % 2;
                }
            }

            //Use the ToCharArray() method to transform string to chararray
            //and Array.Reverse() method
            var binary = toBinary.ToCharArray();
            Array.Reverse(binary);
            
            Console.WriteLine($"{number} as binary is {String.Concat(binary)}");
        }
        #endregion

        #region ToFromUnary
        static void My_strings()
        {
            //Declare int and string variables for decimal and binary presentations

            string numberOneUnary = null;
            string numberTwoUnary = null;
            string FullNumberUnary ;
            //Implement two positive integer variables input
            
            Console.Write("Input first integer variable: ");
            if (!int.TryParse(Console.ReadLine(), out int numberOne)) 
            {
                Console.WriteLine("It is not integer variable");
                return;
            }

            Console.Write("Input second integer variable: ");
            if (!int.TryParse(Console.ReadLine(), out int numberTwo)) 
            {
                Console.WriteLine("It is not integer variable");
                return;
            }

            else
            {
                numberOne = Math.Abs(numberOne);
                numberTwo = Math.Abs(numberTwo);
                //To present each of them in the form of unary string use for loop
                for (int i = 0; i < numberOne; i++)
                {
                    numberOneUnary += "1";
                }
                for (int i = 0; i < numberTwo; i++)
                {
                    numberTwoUnary += "1";
                }
                //Use concatenation of these two strings 
                //Note it is necessary to use some symbol ( for example “#”) to separate
                FullNumberUnary = String.Concat(numberOneUnary, "#", numberTwoUnary);
                //Check the numbers on the equality 0
                if (numberOne == 0 || numberTwo == 0)
                {
                    Console.WriteLine("Inputed number(s) equal 0");
                }
                //Realize the  algorithm for replacing '1#1' to '#' by using the for loop

                for (;FullNumberUnary.Contains("1#1");) 
                {
                    FullNumberUnary = FullNumberUnary.Replace("1#1", "#");
                }
                //Delete the '#' from algorithm result
                FullNumberUnary = FullNumberUnary.Trim('#');
                if (FullNumberUnary.Length != 0) 
                {
                    Console.WriteLine($"|{numberOne}-{numberTwo}|={FullNumberUnary.Length} or as unary it = {FullNumberUnary}");
                }
                else
                {
                    Console.WriteLine($"|{numberOne}-{numberTwo}|={FullNumberUnary.Length}");
                }
                
                //Output the result 
            }

        }
        #endregion

        #region My_music
        static void My_music()
        {
            //HappyBirthday
            Thread.Sleep(2000);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(330, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(297, 500);
            Thread.Sleep(125);
            Console.Beep(264, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(250);
            Console.Beep(264, 125);
            Thread.Sleep(125);
            Console.Beep(2642, 500);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 250);
            Thread.Sleep(125);
            Console.Beep(352, 125);
            Thread.Sleep(125);
            Console.Beep(330, 500);
            Thread.Sleep(125);
            Console.Beep(297, 1000);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(250);
            Console.Beep(466, 125);
            Thread.Sleep(125);
            Console.Beep(440, 500);
            Thread.Sleep(125);
            Console.Beep(352, 500);
            Thread.Sleep(125);
            Console.Beep(396, 500);
            Thread.Sleep(125);
            Console.Beep(352, 1000);
        }
        #endregion

        #region Morse
        static void Morse_code()
        {
            //Create string variable for 'sos'      
            string sos;
            //Use string array for Morse code
            string[,] Dictionary_arr = new string [,] { { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" },
            { ".-   ", "-... ", "-.-. ", "-..  ", ".    ", "..-. ", "--.  ", ".... ", "..   ", ".--- ", "-.-  ", ".-.. ", "--   ", "-.   ", "---  ", ".--. ", "--.- ", ".-.  ", "...  ", "-    ", "..-  ", "...- ", ".--  ", "-..- ", "-.-- ", "--.. ", "-----", ".----", "..---", "...--", "....-", ".....", "-....", "--...", "---..", "----." }};
            //Use ToCharArray() method for string to copy charecters to Unicode character array
            const byte alphabet = 0;
            const byte morseCode = 1;
            int sIndex = 0;
            int oIndex = 0;

            for (int i = 0; i < Dictionary_arr.GetLength(1); i++)
            {
                if (Dictionary_arr[alphabet, i] == "s") 
                {
                    sIndex = i;
                }
                if (Dictionary_arr[alphabet, i] == "o") 
                {
                    oIndex = i;
                }
            }
            string sMorse = Dictionary_arr[morseCode, sIndex];
            string oMorse = Dictionary_arr[morseCode, oIndex];
            sos = String.Concat(sMorse,oMorse, sMorse);
            char[] sosMorse = sos.ToCharArray();

            //Use foreach loop for character array in which

                //Implement Console.Beep(1000, 250) for '.'
                // and Console.Beep(1000, 750) for '-'

                //Use Thread.Sleep(50) to separate sounds
            // 
            foreach(var morse in sosMorse)
            {
                if (morse == '.')
                {
                    Thread.Sleep(50);
                    Console.Beep(1000, 250);
                }
                else if (morse == '-')
                {
                    Thread.Sleep(50);
                    Console.Beep(1000, 750);
                }
            }
        }

        #endregion
    }
}
