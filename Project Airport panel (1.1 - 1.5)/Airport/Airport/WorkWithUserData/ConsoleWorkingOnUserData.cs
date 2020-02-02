using System;
using System.Collections.Generic;

namespace Airport
{
    class ConsoleWorkingOnUserData <T> : IPrinter<T>
    {
        public void Print(T airport)
        {
            if (airport is AirportPanel airportPanel)
            {

                Console.WriteLine($"Airline: {airportPanel.Airline.AirlineName}\tFlight: {airportPanel.FlightNumber}\tTerminal: {airportPanel.Terminal}\tGate: {airportPanel.Gate}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.Write("From: ");
                Console.ResetColor();
                Console.WriteLine($"{airportPanel.AirportDeparture.DepartureCity}\tPort: {airportPanel.AirportDeparture.DeparturePort}\t" +
                    $"Departure at: \t{airportPanel.AirportDeparture.DepartureDate.ToShortDateString()} {airportPanel.AirportDeparture.DepartureDate.ToShortTimeString()}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("To: ");
                Console.ResetColor();
                Console.WriteLine($"{airportPanel.AirportArrival.ArrivalCity}\tPort: {airportPanel.AirportArrival.ArrivalPort}\t" +
                    $"Arrive at: \t{airportPanel.AirportArrival.ArrivalDate.ToShortDateString()} { airportPanel.AirportArrival.ArrivalDate.ToShortTimeString()}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.Write("Status: ");
                Console.ResetColor();
                Console.WriteLine(airportPanel.FlightStatus);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
            }
        }
        public void PrintEmerganceInformation(T airport)
        {
            if (airport is AirportPanel airportPanel)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Emergence: {airportPanel.EmergencyInformation}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
            }
        }
        public void PrintUserUncorrectInput(string info)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(info);
            Console.ResetColor();
        }
        public void Print(string info)
        {
            Console.WriteLine(info);
        }
        public string EnteredValueByUser()
        {
            string info = Console.ReadLine();
            return info;
        }
        public void PrintPrice <T>(T airport)
        {
            if (airport is List<AirportPanel> airportPanel)
            {
                foreach (var airline in airportPanel)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Flight: " + airline.FlightNumber+"\t");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write ("Airline: " +airline.Airline.AirlineName);
                    Console.ResetColor();
                    Console.WriteLine();
                    foreach (var airlineClass in airline.Airline.PriceOfAirlineClass)
                    {
                        Console.WriteLine($"\tClass: {airlineClass.Key}\t\tPrice: {airlineClass.Value}");
                    }

                }
            }
        }
    }
}
