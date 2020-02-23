using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Program
    {
       public static List<AirportPanel> airportPanel = new List<AirportPanel>();
       public static List<Passenger> passengers = new List<Passenger>();
        static void Main(string[] args)
        {
            Random random = new Random();
            const int flightsCount = 10;
            

            #region InitalizationArrayForFlighting
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
                airportPanel.Add(flight);

            }

            //Human passenger = new Passenger(new ConsoleAirportUserData(), new ConsoleCommonUserData());
            //airportPanel[0].Passenger = (Passenger)passenger;

            //Passenger passenger12 = new Passenger(new ConsolePassengerUserData(), new ConsoleCommonUserData());
            //var f = (Human)passenger12;

            Console.WriteLine(airportPanel[0].Airline.PriceOfAirlineClass[0]);
            Console.WriteLine(airportPanel[1].Airline.PriceOfAirlineClass[0]);
            Console.WriteLine(airportPanel[2].Airline.PriceOfAirlineClass[0]);
            #endregion

            do
            {
                Console.WriteLine(@"Please,  type the number:
        1.  Work with aeroport panel
        2.  Work with passengers
                    ");
                int.TryParse(Console.ReadLine(), out int input);
                switch (input)
                {
                    case 1:
                        AirportPanel.Menu(airportPanel);
                        break;
                    case 2:
                        Passenger.Menu(passengers);
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
                
                ConsoleCommonUserData console = new ConsoleCommonUserData();
                Console.WriteLine(@"Please,  type the number:
        1.  Work with aeroport panel
        2.  Work with passengers
                    ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                console.Print("--Press Spacebar to exit;press any key to continue--");
                Console.ResetColor();
            } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);

            Console.ReadLine();
        }
    }
}
