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
            
            RandomInitializationAirportPanels();
            RandomInitializationHumen();
            RandomInitializationPassengers();
            ICommonUserData console = new ConsoleCommonUserData();
            do
            {
                console.Print(@"Please,  type the number:
        1.  Work with aeroport panel
        2.  Work with passengers
                    ");

                ProcessingUserData.EnteredValueByUser(out int input);
                switch (input)
                {
                    case 1:
                        AirportPanel.Menu(Collections.airportPanel);
                        break;
                    case 2:
                        Passenger.Menu(Collections.passengers, Collections.humen);
                        break;
                    default:
                        console.PrintUserUncorrectInput("Uncorrect enter");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        console.Print("--Press Spacebar to exit;press any key to continue--");
                        Console.WriteLine();
                        Console.ResetColor();
                        break;
                }

            } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);
        }
        static void RandomInitializationAirportPanels()
        {
            Random random = new Random();
            const int flightsCount = 10;

            string[] airlineName = { "Ukraine Intl Air", "LOT", "KLM", "S7 Airlines", "Onur Air" };

            string[] arrivalCity = { "Rome", "Kyiv", "Bangkok", "Kingston", "London" };
            string[] arrivalPort = { "Borneo", "Madagascar", "Sumatra", "Honshu", "Sulawesi" };

            string[] departureCity = { "Kinshasa", "Libreville", "Nur-Sultan", "Oslo", "Ottawa" };
            string[] departurePort = { "Java", "Luzon", "Mindanao", "Marajó", "Kyushu" };

            for (int i = 0; i < flightsCount; i++)
            {
                AirportPanel flight = new AirportPanel(new ConsoleAirportUserData(), new ConsoleCommonUserData())
                {
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
                Airline airline = new Airline
                {
                    AirlineName = airlineName[random.Next(0, airlineName.Length)],
                    PriceOfAirlineClass = new Dictionary<AirlineClass, int>
                    {
                        [AirlineClass.bussines] = random.Next(1000, 2000),
                        [AirlineClass.econom] = random.Next(100, 200)
                    }
                };

                flight.Airline = airline;
                Collections.airportPanel.Add(flight);

            }

        }
        static void RandomInitializationHumen()
        {
            Random random = new Random();
            const int humanCount = 4;
            Human passenger = new Passenger(new ConsolePassengerUserData(), new ConsoleCommonUserData())
            {
                DateOfBirthday = default,
                Sex = "man",
                FirstNamePassenger = "Petro",
                SecondNamePassenger = "Lovan",
                Nationality = "uk",
                Passport = "TT45321"
            };
            Collections.humen.Add(passenger);
        }
        static void RandomInitializationPassengers()
        {
            Random random = new Random();
            const int passengerCount = 10;
        }
    }
}
