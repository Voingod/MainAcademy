using System;
using System.Collections.Generic;

namespace Airport
{
    class ConsoleAirportUserData : IAirportUserData
    {
        public void Print(AirportPanel airport)
        {
            Console.WriteLine($"Airline: {airport.Airline.AirlineName}\tFlight: {airport.FlightNumber}\tTerminal: {airport.Terminal}\tGate: {airport.Gate}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.Write("From: ");
            Console.ResetColor();
            Console.WriteLine($"{airport.AirportDeparture.DepartureCity}\tPort: {airport.AirportDeparture.DeparturePort}\t" +
                $"Departure at: \t{airport.AirportDeparture.DepartureDate.ToShortDateString()} {airport.AirportDeparture.DepartureDate.ToShortTimeString()}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("To: ");
            Console.ResetColor();
            Console.WriteLine($"{airport.AirportArrival.ArrivalCity}\tPort: {airport.AirportArrival.ArrivalPort}\t" +
                $"Arrive at: \t{airport.AirportArrival.ArrivalDate.ToShortDateString()} { airport.AirportArrival.ArrivalDate.ToShortTimeString()}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.Write("Status: ");
            Console.ResetColor();
            Console.WriteLine(airport.FlightStatus);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }
        public void PrintEmerganceInformation(AirportPanel airport)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Emergence: {airport.EmergencyInformation}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }
        public void PrintPrice(List<AirportPanel> airport)
        {
            foreach (var airline in airport)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Flight: " + airline.FlightNumber + "\t");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Airline: " + airline.Airline.AirlineName);
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
