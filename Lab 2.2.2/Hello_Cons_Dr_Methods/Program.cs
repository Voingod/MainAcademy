using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Cons_Dr_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Implement start position, width and height, symbol, message input
                //Create Box class instance
                Box box = new Box();
                //Use  Box.Draw() method
                Random random = new Random();
                do
                {
                    Console.Clear();
                    box.X = random.Next(5, 25);
                    box.Y = random.Next(5, 25);
                    box.Width = random.Next(5, 25);
                    box.Height = random.Next(5, 25);
                    box.Symbol = '*';
                    box.Message = "Draw something.";
                    box.Draw();
                    Console.WriteLine("Press any key for continue or press esc for exit");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
            
            }
            catch (Exception)
            {
                Console.WriteLine("Error!");
            }
            Console.ReadLine();

        }
    }
}
