using System;
using System.Collections.Generic;

namespace Airport
{
    class ConsolePassengerUserData : IPassengerUserData
    {
        public void Print(Passenger passenger)
        {
            const int length = -27;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Name: ");
            Console.ResetColor();
            Console.Write($"{passenger.FirstNamePassenger,length }");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Surname: ");
            Console.ResetColor();
            Console.Write($"{passenger.SecondNamePassenger,length}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Sex: ");
            Console.ResetColor();
            Console.WriteLine($"{passenger.Sex,length}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Nationality: ");
            Console.ResetColor();
            Console.Write($"{passenger.Nationality,length + 7}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Passport: ");
            Console.ResetColor();
            Console.Write($"{ passenger.Passport,length + 1}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Birthday: ");
            Console.ResetColor();
            Console.WriteLine(passenger.DateOfBirthday);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Passanger class: ");
            Console.ResetColor();
            Console.Write($"{passenger.PassangerClass,length + 11}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Passanger into plane №: ");
            Console.ResetColor();
            Console.WriteLine($"{passenger.FlightNumber,length}");

            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
        }

    }
}
