using System;

namespace Airport
{
    class ConsoleCommonUserData : ICommonUserData
    {
        public string EnteredValueByUser()
        {
            string info = Console.ReadLine();
            return info;
        }
        public void PrintUserUncorrectInput(string info)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(info);
            Console.WriteLine();
            Console.ResetColor();
        }
        public void Print(string info)
        {
            Console.WriteLine(info);
        }
    }
}
