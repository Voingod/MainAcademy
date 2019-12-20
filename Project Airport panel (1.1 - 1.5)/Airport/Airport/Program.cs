using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Program
    {
//•Please, create a console application for the flight information panel at the airport
//•provide:
//–view of the flight information about arrivals and departures(separately). 
//      It should reflect the information about the arrival(departure) date and time, flight number, city/port of arrival(departure), airline, terminal, 
//flight status(check-in, gate closed, arrived, departed at, unknown, canceled, expected at, delayed, in flight), gate
//–
//–input, deleting and editing of  this information
//–search by the flight number, time of arrival, arrival(departure) port and the information output about the found flight in the specified format
//–search of the flight which is the nearest(1 hour) to the specified time to/from the specified port and output  information sorted by time
//–output of the emergency information(evacuation, fire, etc.)
//–menu for input and output
//•use:
//–arrays
//–casting and type conversions
//–loops
//–switch
//–read/write from/to console
//–string format
//–Console class properties

        struct AirportArrival
        {
           public DateTime arrivalDate;
           public string arrivalCity;
           public string arrivalPort;
        }
        struct AirportDeparture
        {
            public DateTime departureDate;  
            public string departureCity;
            public string departurePort;
        }
        class AirportPanel
        {
            public byte gate;
            public ushort flightNumber;
            public string airline;
            public byte terminal;

            public FlightStatus flightStatus;
            public EmergencyInformation emergencyInformation;

            public AirportArrival airportArrival;
            public AirportDeparture airportDeparture;

            public void InformationOutput()
            {

                Console.WriteLine($"Airline: {airline}\tFlight: {flightNumber}\tTerminal: {terminal}\tGate: {gate}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.Write("From: ");
                Console.ResetColor();
                Console.WriteLine($"{airportDeparture.departureCity}\tPort: {airportDeparture.departurePort}\t" +
                    $"Departure at: \t{airportDeparture.departureDate.ToShortDateString()} {airportDeparture.departureDate.ToShortTimeString()}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("To: ");
                Console.ResetColor();
                Console.WriteLine($"{airportArrival.arrivalCity}\tPort: {airportArrival.arrivalPort}\t" +
                    $"Arrive at: \t{airportArrival.arrivalDate.ToShortDateString()} { airportArrival.arrivalDate.ToShortTimeString()}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.Write("Status: ");
                Console.ResetColor();
                Console.WriteLine(flightStatus);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
            }
            public void EmerganceInformation()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Emergence: {emergencyInformation}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
            }

        }


        static void Main(string[] args)
        {
            #region InitalizationArrayForFlighting
            Random random = new Random();

            const int flightsCount = 3;
            AirportPanel[] airportPanel = new AirportPanel[flightsCount];

            string[] airline = {"Ukraine Intl Air", "LOT", "KLM", "S7 Airlines", "Onur Air"};
            ushort[] flightNumber = { 321, 642, 101, 554, 294 };
            byte[] gate = { 1, 2, 3, 4, 5 };
            byte[] terminal = { 99, 88, 77, 66, 55 };
            string[] arrivalCity = { "Rome", "Kyiv", "Bangkok", "Kingston", "London" };
            DateTime[] arrivalDate = { new DateTime(2019, 12, 22, 18, 32, 00), new DateTime(2019, 12, 24, 17, 01, 00), new DateTime(2019, 12, 29, 03, 17, 00) };
            string[] arrivalPort = { "Borneo", "Madagascar", "Sumatra", "Honshu", "Sulawesi" };
            
            string[] departureCity = { "Kinshasa", "Libreville", "Nur-Sultan", "Oslo", "Ottawa" };
            DateTime[] departureDate = { new DateTime(2019, 12, 19, 13, 24, 00), new DateTime(2019, 12, 21, 05, 32, 00), new DateTime(2019, 12, 20, 15, 59, 00) };
            string[] departurePort = { "Java", "Luzon", "Mindanao", "Marajó", "Kyushu" };

            for (int i = 0; i < flightsCount; i++)
            {
                AirportPanel flight = new AirportPanel
                {
                    airline = airline[random.Next(0, airline.Length)],
                    flightNumber = flightNumber[random.Next(0, flightNumber.Length)],
                    flightStatus = (FlightStatus)random.Next(0, Enum.GetValues(typeof(FlightStatus)).Length),
                    gate = gate[random.Next(0, gate.Length)],
                    terminal = terminal[random.Next(0, terminal.Length)],
                    emergencyInformation = (EmergencyInformation)random.Next(0, Enum.GetValues(typeof(EmergencyInformation)).Length),
                };

                flight.airportArrival.arrivalCity = arrivalCity[random.Next(0, arrivalCity.Length)];
                flight.airportArrival.arrivalDate = arrivalDate[random.Next(0, arrivalDate.Length)];
                flight.airportArrival.arrivalPort = arrivalPort[random.Next(0, arrivalPort.Length)];

                flight.airportDeparture.departureCity = departureCity[random.Next(0, departureCity.Length)];
                flight.airportDeparture.departureDate = departureDate[random.Next(0, departureDate.Length)];
                flight.airportDeparture.departurePort = departurePort[random.Next(0, departurePort.Length)];

                airportPanel[i] = flight;
            }
            #endregion
            int a;
            try
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine(@"Please,  type the number:
        1.  Create new flight (input all data)
        2.  Delete flight
        3.  Update some information about flight
        4.  Search some information about flight
        5.  Output schedule
        6.  Output of the emergency information 
                    ");
                    
                    try
                    {
                        a = (int)uint.Parse(Console.ReadLine());
                        Console.WriteLine();
                        switch (a)
                        {
                            case 1:
                                airportPanel = CreateNewFlight(airportPanel);
                                break;

                            case 2:
                                airportPanel = DeleteFlight(airportPanel);
                                break;                            

                            case 3:
                                airportPanel = UpdateFlightsInformation(airportPanel);
                                break;

                            case 4:
                                airportPanel = SearchInformation(airportPanel);
                                break;

                            case 5:
                                airportPanel = OutputSchedule(airportPanel);
                                break;

                            case 6:
                                airportPanel = OutputEmergencyInformation(airportPanel);

                                break;
                            default:
                                Console.WriteLine("Exit");
                                break;
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error " + e.Message);
                    }
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Press Spacebar to exit; press any key to continue");
                    Console.ResetColor();

                }
                while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadLine();
        }
        static AirportPanel[] CreateNewFlight(AirportPanel[] airportPanel)
        {
            Console.WriteLine("Adding new flight");
            AirportPanel flight = new AirportPanel();

            Console.Write("Enter airline: ");
            flight.airline = Console.ReadLine();

            Console.Write("Enter flight number: ");
            flight.flightNumber = ushort.Parse(Console.ReadLine());

            Console.WriteLine("Choose status for adding: ");
            flight.flightStatus =  NewStatus(flight);

            Console.Write("Enter number of gate: ");
            flight.gate = byte.Parse(Console.ReadLine());

            Console.Write("Enter Terminal: ");
            flight.terminal = byte.Parse(Console.ReadLine());

            Console.WriteLine("Choose emergency information for adding: ");
            flight.emergencyInformation = NewEmergencyInformation(flight);

            Console.Write("Enter arrival city: ");
            flight.airportArrival.arrivalCity = Console.ReadLine();

            Console.Write("Enter arrival date and time in the format dd.mm.yy h:m: ");
            flight.airportArrival.arrivalDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter arrival port: ");
            flight.airportArrival.arrivalPort = Console.ReadLine();

            Console.Write("Enter departure city: ");
            flight.airportDeparture.departureCity = Console.ReadLine();

            Console.Write("Enter departure date and time in the format dd.mm.yy h:m: ");
            flight.airportDeparture.departureDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter departure port: ");
            flight.airportDeparture.departurePort = Console.ReadLine();

            AirportPanel[] tempAirportPanelEnter = new AirportPanel[airportPanel.Length + 1];
            for (int i = 0; i < airportPanel.Length; i++)
            {
                tempAirportPanelEnter[i] = airportPanel[i];
            }
            airportPanel = new AirportPanel[tempAirportPanelEnter.Length];
            for (int i = 0; i < tempAirportPanelEnter.Length - 1; i++)
            {
                airportPanel[i] = tempAirportPanelEnter[i];
            }
            airportPanel[tempAirportPanelEnter.Length - 1] = flight;
            return airportPanel;
        }
        static AirportPanel[] DeleteFlight(AirportPanel[] airportPanel)
        {
            Console.WriteLine("Choose schedule for delete:");
            byte deleteElement = new byte();
            for (int i = 0; i < airportPanel.Length; i++)
            {
                Console.WriteLine($@"        {i + 1}.  Flight: {airportPanel[i].flightNumber}");
            }
            try
            {
                int a = (int)uint.Parse(Console.ReadLine());
                AirportPanel[] tempAirportPanelDelete = new AirportPanel[airportPanel.Length - 1];
                for (int i = 0; i < airportPanel.Length; i++)
                {
                    if (i == (a - 1))
                    {
                        deleteElement++;
                        continue;
                    }
                    tempAirportPanelDelete[i - deleteElement] = airportPanel[i];
                }
                airportPanel = new AirportPanel[tempAirportPanelDelete.Length];
                for (int i = 0; i < tempAirportPanelDelete.Length; i++)
                {
                    airportPanel[i] = tempAirportPanelDelete[i];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        return airportPanel;

        }
        static AirportPanel[] UpdateFlightsInformation(AirportPanel[] airportPanel)
        {
            Console.WriteLine("Choose schedule for update:");
            for (int i = 0; i < airportPanel.Length; i++)
            {
                Console.WriteLine($@"        {i + 1}.  Flight: {airportPanel[i].flightNumber}");
            }
            try
            {

                int a = (int)uint.Parse(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine(@"What do you want to update?
        1.  Number of gate
        2.  Flight number
        3.  Airline
        4.  Terminal
        5.  Flight status
        6.  Emergency information
        7.  Date of arrive
        8.  Arrival city
        9.  Arrival port
        10. Date of departure
        11. Departure city
        12. Departure port
                    ");
                try
                {
                    int b = (int)uint.Parse(Console.ReadLine());
                    switch (b)
                    {
                        case 1:
                                Console.Write("Enter new number of gate: ");
                                airportPanel[a - 1].gate = byte.Parse(Console.ReadLine());
                                Console.WriteLine();
                                break;
                            
                        case 2:
                                Console.Write("Enter new flight number: ");
                                airportPanel[a - 1].flightNumber = ushort.Parse(Console.ReadLine());
                                Console.WriteLine();
                                break;
                            
                        case 3:
                                Console.Write("Enter new airline: ");
                                airportPanel[a - 1].airline = Console.ReadLine();
                                Console.WriteLine();
                                break;
                            
                        case 4:
                                Console.Write("Enter new terminal: ");
                                airportPanel[a - 1].terminal = byte.Parse(Console.ReadLine());
                                Console.WriteLine();
                                break;
                            
                        case 5:
                                Console.WriteLine("Choose new status: ");
                                airportPanel[a - 1].flightStatus = NewStatus(airportPanel[a - 1]);
                                break;
                            

                        case 6:
                                Console.WriteLine("Choose new emergency information: ");
                                airportPanel[a - 1].emergencyInformation = NewEmergencyInformation(airportPanel[a - 1]);
                                break;
                            
                        case 7:
                                Console.WriteLine("Enter new arrival date and time in the format dd.mm.yy h:m");
                                airportPanel[a - 1].airportArrival.arrivalDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine();
                                break;
                            
                        case 8:
                                Console.Write("Enter new arrival city: ");
                                airportPanel[a - 1].airportArrival.arrivalCity = Console.ReadLine();
                                Console.WriteLine();
                                break;
                            
                        case 9:
                                Console.Write("Enter new arrival port: ");
                                airportPanel[a - 1].airportArrival.arrivalPort = Console.ReadLine();
                                Console.WriteLine();
                                break;
                            
                        case 10:
                                Console.WriteLine("Enter new departure date and time in the format dd.mm.yy h:m");
                                airportPanel[a - 1].airportDeparture.departureDate = DateTime.Parse(Console.ReadLine());
                                break;

                        case 11:
                                Console.Write("Enter new departure city: ");
                                airportPanel[a - 1].airportDeparture.departureCity = Console.ReadLine();
                                Console.WriteLine();
                                break;

                        case 12:
                                Console.Write("Enter new departure port: ");
                                airportPanel[a - 1].airportDeparture.departurePort = Console.ReadLine();
                                Console.WriteLine();
                                break;
                            
                        default:
                                Console.WriteLine("Uncorrect option");
                                break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            catch
            {
                Console.WriteLine("Uncorrect choose");
            }
            return airportPanel;
        }
        static AirportPanel[] SearchInformation(AirportPanel[] airportPanel)
        {
            string[] parametrs = { "Flight number", "Time of arrival", "Arrival port", "Departure port",
                                        "The nearest (1 hour) flight (time to)", "The nearest (1 hour) flight (time from)" };
            Console.WriteLine("Choose parametr, which you want to use for search: ");
            for (int i = 0; i < parametrs.Length; i++)
            {
                Console.WriteLine($"       {i + 1}.  {parametrs[i]}");
            }
            ushort searchParam = ushort.Parse(Console.ReadLine());
            switch (searchParam)
            {
                case 1:
                    #region searchFlightNumber
                    Console.Write($"Enter {parametrs[searchParam - 1].ToLower()}: ");
                    ushort searchFlightNumber = ushort.Parse(Console.ReadLine());
                    for (int i = 0; i < airportPanel.Length; i++)
                    {
                        if (airportPanel[i].flightNumber == searchFlightNumber)
                        {
                            airportPanel[i].InformationOutput();
                        }
                    }
                    #endregion
                    break;
                case 2:
                    #region searchArrivalTime
                    Console.Write($"Enter {parametrs[searchParam - 1].ToLower()} in the format hh:mm: ");
                    DateTime searchArrivalTime = DateTime.Parse(Console.ReadLine());
                    for (int i = 0; i < airportPanel.Length; i++)
                    {
                        if (airportPanel[i].airportArrival.arrivalDate.Hour == searchArrivalTime.Hour
                            && airportPanel[i].airportArrival.arrivalDate.Minute == searchArrivalTime.Minute)
                        {
                            airportPanel[i].InformationOutput();
                        }
                    }
                    #endregion
                    break;
                case 3:
                    #region searchArrivalPort
                    Console.Write($"Enter {parametrs[searchParam - 1].ToLower()}: ");
                    string searchArrivalPort = Console.ReadLine();
                    for (int i = 0; i < airportPanel.Length; i++)
                    {
                        if (airportPanel[i].airportArrival.arrivalPort == searchArrivalPort)
                        {
                            airportPanel[i].InformationOutput();
                        }
                    }
                    #endregion
                    break;
                case 4:
                    #region searchDeparturePort
                    Console.Write($"Enter {parametrs[searchParam - 1].ToLower()}: ");
                    string searchDeparturePort = Console.ReadLine();
                    for (int i = 0; i < airportPanel.Length; i++)
                    {
                        if (airportPanel[i].airportDeparture.departurePort == searchDeparturePort)
                        {
                            airportPanel[i].InformationOutput();
                        }
                    }
                    #endregion
                    break;
                case 5:
                    #region  nearestSearchTimeTo

                    for (int i = 0; i < airportPanel.Length; i++)
                    {
                        for (int j = 0; j < airportPanel.Length - 1; j++)
                        {
                            if (airportPanel[j].airportArrival.arrivalDate > airportPanel[j + 1].airportArrival.arrivalDate)
                            {
                                var temp = airportPanel[j];
                                airportPanel[j] = airportPanel[j + 1];
                                airportPanel[j + 1] = temp;
                            }
                        }
                    }
                    Console.Write($"Enter {parametrs[2].ToLower()}: ");
                    string enteredArrivalePort = Console.ReadLine();

                    Console.Write($"Enter time in the format hh:mm: ");
                    TimeSpan enteredArrivalTime = TimeSpan.Parse(Console.ReadLine());

                    for (int i = 0; i < airportPanel.Length; i++)
                    {
                        if (airportPanel[i].airportArrival.arrivalPort == enteredArrivalePort)
                        {
                            if (airportPanel[i].airportArrival.arrivalDate.Date == DateTime.Today
                                && (airportPanel[i].airportArrival.arrivalDate.TimeOfDay - enteredArrivalTime) < TimeSpan.FromHours(1))
                            {
                                airportPanel[i].InformationOutput();
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    #endregion
                    break;
                case 6:
                    #region  nearestSearchTimeFrom
                    for (int i = 0; i < airportPanel.Length; i++)
                    {
                        for (int j = 0; j < airportPanel.Length - 1; j++)
                        {
                            if (airportPanel[j].airportDeparture.departureDate > airportPanel[j + 1].airportDeparture.departureDate)
                            {
                                var temp = airportPanel[j];
                                airportPanel[j] = airportPanel[j + 1];
                                airportPanel[j + 1] = temp;
                            }
                        }
                    }
                    Console.Write($"Enter {parametrs[2].ToLower()}: ");
                    string enteredDepartureePort = Console.ReadLine();

                    Console.Write($"Enter time in the format hh:mm: ");
                    TimeSpan enteredDepartureTime = TimeSpan.Parse(Console.ReadLine());

                    for (int i = 0; i < airportPanel.Length; i++)
                    {
                        if (airportPanel[i].airportDeparture.departurePort == enteredDepartureePort)
                        {
                            if (airportPanel[i].airportDeparture.departureDate.Date == DateTime.Today
                                && (airportPanel[i].airportDeparture.departureDate.TimeOfDay - enteredDepartureTime) < TimeSpan.FromHours(1))
                            {
                                airportPanel[i].InformationOutput();
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    #endregion
                    break;
            }
            return airportPanel;
        }
        static AirportPanel[] OutputSchedule(AirportPanel[] airportPanel)
        {
            for (int i = 0; i < airportPanel.Length; i++)
            {
                airportPanel[i].InformationOutput();
            }
            return airportPanel;
        }
        static AirportPanel[] OutputEmergencyInformation(AirportPanel[] airportPanel)
        {
            Console.WriteLine("Where do you want to find out about an emergency?");
            for (int i = 0; i < airportPanel.Length; i++)
            {
                Console.WriteLine($"        {i + 1}.  Flight: {airportPanel[i].flightNumber}");
            }
            try
            {
                int a = (int)uint.Parse(Console.ReadLine());
                Console.WriteLine();
                airportPanel[a - 1].EmerganceInformation();
            }
            catch
            {
                Console.WriteLine("Uncorrect choose");
            }
            return airportPanel;
        }
        static FlightStatus NewStatus(AirportPanel flight)
        {
            #region EnterStatus
            int unknownEnter = new int();
            int skipUnknownEnter = new int();

            for (int i = 0; i < Enum.GetNames(typeof(FlightStatus)).Length; i++)
            {
                if (Enum.GetName(typeof(FlightStatus), i) == FlightStatus.unknown.ToString())
                {
                    skipUnknownEnter++;
                    unknownEnter = i;
                    continue;
                }

                Console.WriteLine($@"           {i + 1 - skipUnknownEnter}. {Enum.GetName(typeof(FlightStatus), i)}");
            }
            int statusEnter = int.Parse(Console.ReadLine());
            if (statusEnter > unknownEnter)
            {
                statusEnter += skipUnknownEnter;
            }
            switch (statusEnter - 1)
            {
                case (int)FlightStatus.arrived:
                    {
                        flight.flightStatus = FlightStatus.arrived;
                        break;
                    }
                case (int)FlightStatus.canceled:
                    {
                        flight.flightStatus = FlightStatus.canceled;
                        break;
                    }
                case (int)FlightStatus.checkIn:
                    {
                        flight.flightStatus = FlightStatus.checkIn;
                        break;
                    }
                case (int)FlightStatus.delayed:
                    {
                        flight.flightStatus = FlightStatus.delayed;
                        break;
                    }
                case (int)FlightStatus.departedAt:
                    {
                        flight.flightStatus = FlightStatus.departedAt;
                        break;
                    }
                case (int)FlightStatus.expectedAt:
                    {
                        flight.flightStatus = FlightStatus.expectedAt;
                        break;
                    }
                case (int)FlightStatus.gateClosed:
                    {
                        flight.flightStatus = FlightStatus.gateClosed;
                        break;
                    }
                case (int)FlightStatus.Inflight:
                    {
                        flight.flightStatus = FlightStatus.Inflight;
                        break;
                    }
                default:
                    {
                        flight.flightStatus = FlightStatus.unknown;
                        break;
                    }
            }
            return flight.flightStatus;
            #endregion
        }
        static EmergencyInformation NewEmergencyInformation(AirportPanel flight)
        {
            for (int i = 0; i < Enum.GetNames(typeof(EmergencyInformation)).Length; i++)
            {
                Console.WriteLine($@"           {i + 1}. {Enum.GetName(typeof(EmergencyInformation), i)}");
            }
            int informationEnter = int.Parse(Console.ReadLine());

            switch (informationEnter - 1)
            {
                case (int)EmergencyInformation.evacuation:
                    {
                        flight.emergencyInformation = EmergencyInformation.evacuation;
                        break;
                    }
                case (int)EmergencyInformation.fire:
                    {
                        flight.emergencyInformation = EmergencyInformation.fire;
                        break;
                    }
            }
            return flight.emergencyInformation;
        }
        enum FlightStatus
        {
            checkIn, gateClosed, arrived, departedAt, unknown, canceled, expectedAt, delayed, Inflight
        }
        enum EmergencyInformation
        {
            evacuation, fire
        }
    }
}
