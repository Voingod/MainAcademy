using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Cons_Dr_Methods
{
    class Box
    {
        //1.  Implement public  auto-implement properties for start position (point position)
        //auto-implement properties for width and height of the box
        //and auto-implement properties for a symbol of a given set of valid characters (*, + ,.) to be used for the border 
        //and a message inside the box
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public char Symbol { get; set; }
        public string Message { get; set; }
        //2.  Implement public Draw() method
        //to define start position, width and height, symbol, message  according to properties
        //Use Math.Min() and Math.Max() methods
        //Use draw() to draw the box with message
        public void Draw()
        {
            draw(X, Y, Height, Width, Symbol, Message);
        }

        //3.  Implement private method draw() with parameters 
        //for start position, width and height, symbol, message
        //Change the message in the method to return the Box square
        //Use Console.SetCursorPosition() method
        //Trim the message if necessary
        private void draw(int x, int y, int height, int width, char symbol, string message)
        {
            message += $" Square is {height * width}";
            char[] messageAsSymbols = message.ToCharArray();
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (i == width - 1 || j == height - 1 || i == 0 || j == 0)
                    {
                        Console.SetCursorPosition(x + i, y + j);
                        Console.Write(symbol);
                    }
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            int shiftY = 1;
            int lineBreak = 0;
            Console.SetCursorPosition(x + shiftY, y + shiftY);
            for (int i = 0; i < messageAsSymbols.Length; i++)
            {
                Console.Write(messageAsSymbols[i]);
                if (lineBreak++ == width - 3)
                {
                    lineBreak = 0;
                    shiftY++;
                    Console.WriteLine();
                    Console.SetCursorPosition(x + 1, y + shiftY);
                }
                if (shiftY == height - 1)
                {
                    break;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x + width, y + height);
            Console.WriteLine();
        }


    }
}
