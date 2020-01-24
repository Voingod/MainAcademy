using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
            Random random = new Random();
            const int flightsCount = 10;
            List<AirportPanel> airportPanel = new List<AirportPanel>();

            #region InitalizationArrayForFlighting
            string[] airline = { "Ukraine Intl Air", "LOT", "KLM", "S7 Airlines", "Onur Air" };

            string[] arrivalCity = { "Rome", "Kyiv", "Bangkok", "Kingston", "London" };
            string[] arrivalPort = { "Borneo", "Madagascar", "Sumatra", "Honshu", "Sulawesi" };

            string[] departureCity = { "Kinshasa", "Libreville", "Nur-Sultan", "Oslo", "Ottawa" };
            string[] departurePort = { "Java", "Luzon", "Mindanao", "Marajó", "Kyushu" };

            for (int i = 0; i < flightsCount; i++)
            {
                AirportPanel flight = new AirportPanel(new ConsoleGetSetInfo())
                {
                    Airline = airline[random.Next(0, airline.Length)],
                    FlightNumber = random.Next(100, 701),
                    FlightStatus = (FlightStatus)random.Next(0, Enum.GetValues(typeof(FlightStatus)).Length),
                    Gate = random.Next(1, 10),
                    Terminal = random.Next(10, 100),
                    EmergencyInformation = (EmergencyInformation)random.Next(0, Enum.GetValues(typeof(EmergencyInformation)).Length),
                };
                AirportArrival airportArrival = new AirportArrival
                {
                    ArrivalCity = arrivalCity[random.Next(0, arrivalCity.Length)],
                    ArrivalDate = DateTime.Now.AddHours(random.Next(0, 2)).
                    AddMinutes(random.Next(0, 60)).AddSeconds(-DateTime.Now.Second).AddMilliseconds(-DateTime.Now.Millisecond),
                    ArrivalPort = arrivalPort[random.Next(0, arrivalPort.Length)]
                };

                flight.AirportArrival = airportArrival;

                AirportDeparture airportDeparture = new AirportDeparture
                {
                    DepartureCity = departureCity[random.Next(0, departureCity.Length)],
                    DepartureDate = flight.AirportArrival.ArrivalDate.AddDays(random.Next(-1, 1)).AddHours(random.Next(-1, 1)).AddMinutes(random.Next(-59, 1)).AddSeconds(0),
                    DeparturePort = departurePort[random.Next(0, departurePort.Length)]
                };

                flight.AirportDeparture = airportDeparture;

                airportPanel.Add(flight);
                
            }

            #endregion

            AirportPanel.MenuPanel(airportPanel);
            Console.ReadLine();
        }
    }

}
