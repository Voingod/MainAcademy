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
           public DateTime arrivalData;
           public string arrivalCity;
           public string arrivalPort;
        }
        struct AirportDeparture
        {
            public DateTime departureData;  
            public string departureCity;
            public string departurePort;
        }
        struct AirportPanel
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
                    $"Departure at: \t{airportDeparture.departureData.ToShortDateString()} {airportDeparture.departureData.ToShortTimeString()}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("To: ");
                Console.ResetColor();
                Console.WriteLine($"{airportArrival.arrivalCity}\tPort: {airportArrival.arrivalPort}\t" +
                    $"Arrive at: \t{airportArrival.arrivalData.ToShortDateString()} { airportArrival.arrivalData.ToShortTimeString()}");
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
            #region FillingAirportPanel
            AirportPanel flight1 = new AirportPanel
            {
                airline = "One",
                flightNumber = 245,
                flightStatus = FlightStatus.checkIn,
                gate = 3,
                terminal = 7,
                emergencyInformation = EmergencyInformation.fire
            };

            flight1.airportArrival.arrivalCity = "Kyiv";
            flight1.airportArrival.arrivalData = new DateTime(2015, 7, 20, 18, 30, 25);
            flight1.airportArrival.arrivalPort = "Boryspil";

            flight1.airportDeparture.departureCity = "Lviv";
            flight1.airportDeparture.departureData = new DateTime(2015, 7, 21, 03, 17, 43);
            flight1.airportDeparture.departurePort = "Mikolay";

            AirportPanel flight2 = new AirportPanel
            {
                airline = "Two",
                flightNumber = 83,
                flightStatus = FlightStatus.departedAt,
                gate = 56,
                terminal = 91,
                emergencyInformation = EmergencyInformation.evacuation
            };

            flight2.airportArrival.arrivalCity = "Moscow";
            flight2.airportArrival.arrivalData = new DateTime(2019, 3, 17, 19, 20, 25);
            flight2.airportArrival.arrivalPort = "Square";
                  
            flight2.airportDeparture.departureCity = "Kyiv";
            flight2.airportDeparture.departureData = new DateTime(2019, 3, 18, 01, 27, 52);
            flight2.airportDeparture.departurePort = "Boryspil";

            AirportPanel[] airportPanel = new AirportPanel[] { flight1, flight2, flight1 };
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
                                #region AddFlightPartOne
                                Console.WriteLine("Adding new flight");
                                AirportPanel flight = new AirportPanel();
                                
                                Console.Write("Enter airline: ");
                                flight.airline = Console.ReadLine();

                                Console.Write("Enter flight number: ");
                                flight.flightNumber = ushort.Parse(Console.ReadLine());

                                #region EnterStatus
                                int unknownEnter = new int();
                                int skipUnknownEnter = new int();

                                Console.WriteLine("Choose status for adding: ");

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
                                #endregion

                                Console.Write("Enter number of gate: ");
                                flight.gate = byte.Parse(Console.ReadLine());

                                Console.Write("Enter Terminal: ");
                                flight.terminal = byte.Parse(Console.ReadLine());

                                #region EnterEmergencyInformation
                                Console.WriteLine("Choose emergency information for adding: ");

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
                                #endregion

                                Console.Write("Enter arrival city: ");
                                flight.airportArrival.arrivalCity = Console.ReadLine();

                                Console.Write("Enter arrival date and time in the format dd.mm.yy h:m:s: ");
                                flight.airportArrival.arrivalData = DateTime.Parse(Console.ReadLine());

                                Console.Write("Enter arrival port: ");
                                flight.airportArrival.arrivalPort = Console.ReadLine();

                                Console.Write("Enter departure city: ");
                                flight.airportDeparture.departureCity = Console.ReadLine();
                                
                                Console.Write("Enter departure date and time in the format dd.mm.yy h:m:s: ");
                                flight.airportDeparture.departureData = DateTime.Parse(Console.ReadLine());

                                Console.Write("Enter departure port: ");
                                flight.airportDeparture.departurePort = Console.ReadLine();                                
                                #endregion

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

                                break;

                            case 2:
                                #region Delete
                                Console.WriteLine("Choose schedule for delete:");
                                byte deleteElement = new byte();
                                for (int i = 0; i < airportPanel.Length; i++)
                                {
                                    Console.WriteLine($@"        {i + 1}.  Flight: {airportPanel[i].flightNumber}");
                                }
                                try
                                {
                                    a = (int)uint.Parse(Console.ReadLine());
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
                                
                                break;
                            #endregion

                            case 3:
                                #region Update
                                Console.WriteLine("Choose schedule for update:");
                                for (int i = 0; i < airportPanel.Length; i++)
                                {
                                    Console.WriteLine($@"        {i + 1}.  Flight: {airportPanel[i].flightNumber}");
                                }
                                try
                                {            

                                    a = (int)uint.Parse(Console.ReadLine());

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
                                                {
                                                    Console.Write("Enter new number of gate: ");
                                                    airportPanel[a-1].gate = byte.Parse(Console.ReadLine());
                                                    Console.WriteLine();
                                                    break; 
                                                }
                                            case 2:
                                                {
                                                    Console.Write("Enter new flight number: ");
                                                    airportPanel[a-1].flightNumber = ushort.Parse(Console.ReadLine());
                                                    Console.WriteLine();
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    Console.Write("Enter new airline: ");
                                                    airportPanel[a-1].airline = Console.ReadLine();
                                                    Console.WriteLine();
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    Console.Write("Enter new terminal: ");
                                                    airportPanel[a-1].terminal = byte.Parse(Console.ReadLine());
                                                    Console.WriteLine();
                                                    break;
                                                }
                                            case 5:
                                                {
                                                    #region UpdateStatus
                                                    int unknown = new int();
                                                    int skipUnknown = new int();

                                                    Console.WriteLine("Choose new status: ");

                                                    for (int i = 0; i < Enum.GetNames(typeof(FlightStatus)).Length; i++)
                                                    {
                                                        if (Enum.GetName(typeof(FlightStatus), i) == FlightStatus.unknown.ToString())
                                                        {
                                                            skipUnknown++;
                                                            unknown = i;
                                                            continue;
                                                        }

                                                        Console.WriteLine($@"           {i + 1 - skipUnknown}. {Enum.GetName(typeof(FlightStatus), i)}");
                                                    }

                                                    int status = int.Parse(Console.ReadLine());
                                                    if (status > unknown)
                                                    {
                                                        status += skipUnknown;
                                                    }
                                                    switch (status-1)
                                                    {
                                                        case (int)FlightStatus.arrived:
                                                            {
                                                                airportPanel[a - 1].flightStatus = FlightStatus.arrived;
                                                                break;
                                                            }
                                                        case (int)FlightStatus.canceled:
                                                            {
                                                                airportPanel[a - 1].flightStatus = FlightStatus.canceled;
                                                                break;
                                                            }
                                                        case (int)FlightStatus.checkIn:
                                                            {
                                                                airportPanel[a - 1].flightStatus = FlightStatus.checkIn;
                                                                break;
                                                            }
                                                        case (int)FlightStatus.delayed:
                                                            {
                                                                airportPanel[a - 1].flightStatus = FlightStatus.delayed;
                                                                break;
                                                            }
                                                        case (int)FlightStatus.departedAt:
                                                            {
                                                                airportPanel[a - 1].flightStatus = FlightStatus.departedAt;
                                                                break;
                                                            }
                                                        case (int)FlightStatus.expectedAt:
                                                            {
                                                                airportPanel[a - 1].flightStatus = FlightStatus.expectedAt;
                                                                break;
                                                            }
                                                        case (int)FlightStatus.gateClosed:
                                                            {
                                                                airportPanel[a - 1].flightStatus = FlightStatus.gateClosed;
                                                                break;
                                                            }
                                                        case (int)FlightStatus.Inflight:
                                                            {
                                                                airportPanel[a - 1].flightStatus = FlightStatus.Inflight;
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                airportPanel[a-1].flightStatus = FlightStatus.unknown;
                                                                break;
                                                            }
                                                            
                                                    }
                                                    break;
                                                    #endregion
                                                }


                                            case 6:
                                                {
                                                    Console.WriteLine("Choose new emergency information: ");

                                                    for (int i = 0; i < Enum.GetNames(typeof(EmergencyInformation)).Length; i++)
                                                    {

                                                        Console.WriteLine($@"           {i + 1}. {Enum.GetName(typeof(EmergencyInformation), i)}");
                                                    }
                                                    int information = int.Parse(Console.ReadLine());

                                                    switch (information - 1)
                                                    {
                                                        case (int)EmergencyInformation.evacuation:
                                                            {
                                                                airportPanel[a - 1].emergencyInformation = EmergencyInformation.evacuation;
                                                                break;
                                                            }
                                                        case (int)EmergencyInformation.fire:
                                                            {
                                                                airportPanel[a - 1].emergencyInformation = EmergencyInformation.fire;
                                                                break;
                                                            }
                                                    }
                                                    break;
                                                }
                                            case 7:
                                                {
                                                    Console.WriteLine("Enter new arrival date and time in the format dd.mm.yy h:m:s");
                                                    airportPanel[a-1].airportArrival.arrivalData = DateTime.Parse(Console.ReadLine());
                                                    Console.WriteLine();

                                                    break;
                                                }
                                            case 8:
                                                {
                                                    Console.Write("Enter new arrival city: ");
                                                    airportPanel[a-1].airportArrival.arrivalCity = Console.ReadLine();
                                                    Console.WriteLine();
                                                    break;
                                                }
                                            case 9:
                                                {
                                                    Console.Write("Enter new arrival port: ");
                                                    airportPanel[a-1].airportArrival.arrivalPort = Console.ReadLine();
                                                    Console.WriteLine();
                                                    break;
                                                }
                                            case 10:
                                                {
                                                    Console.WriteLine("Enter new departure date and time in the format dd.mm.yy h:m:s");
                                                    airportPanel[a-1].airportDeparture.departureData = DateTime.Parse(Console.ReadLine());
                                                    break;
                                                }
                                            case 11:
                                                {
                                                    Console.Write("Enter new departure city: ");
                                                    airportPanel[a-1].airportDeparture.departureCity = Console.ReadLine();
                                                    Console.WriteLine();
                                                    break;
                                                }
                                            case 12:
                                                {
                                                    Console.Write("Enter new departure port: ");
                                                    airportPanel[a-1].airportDeparture.departurePort = Console.ReadLine();
                                                    Console.WriteLine();
                                                    break;
                                                }
                                            default:
                                                {
                                                    Console.WriteLine("Uncorrect option");
                                                    break;
                                                }
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
                                break;
                            #endregion

                            case 4:
                                string[] parametrs = { "Flight number", "Time of arrival", "Arrival port", "Departure port", 
                                        "The nearest (1 hour) flight (time to)", "The nearest (1 hour) flight (time from)" };
                                Console.WriteLine("Choose parametr, which you want to use for search: ");
                                for (int i = 0; i < parametrs.Length; i++)
                                {
                                    Console.WriteLine($"       {i+1}.  {parametrs[i]}");
                                }
                                ushort searchParam = ushort.Parse(Console.ReadLine());
                                switch(searchParam)
                                {
                                    case 1:
                                        #region searchFlightNumber
                                        Console.Write($"Enter {parametrs[searchParam - 1].ToLower()}: ");
                                        ushort searchFlightNumber = ushort.Parse(Console.ReadLine());
                                        for (int i = 0; i < airportPanel.Length; i++)
                                        {
                                            if(airportPanel[i].flightNumber== searchFlightNumber)
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
                                            if (airportPanel[i].airportArrival.arrivalData.Hour == searchArrivalTime.Hour
                                                && airportPanel[i].airportArrival.arrivalData.Minute == searchArrivalTime.Minute)
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
                                        # region searchDeparturePort
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



                                        #endregion
                                        break;
                                    case 6:
                                        #region  nearestSearchTimeFrom



                                        #endregion
                                        break;
                                }
                                break;
                            case 5:
                                for (int i = 0; i < airportPanel.Length; i++)
                                {
                                    airportPanel[i].InformationOutput();
                                }
                                break;
                            case 6:
                                Console.WriteLine("Where do you want to find out about an emergency?");
                                for (int i = 0; i < airportPanel.Length; i++)
                                {
                                    Console.WriteLine($"        {i+1}.  Flight: {airportPanel[i].flightNumber}");
                                }
                                try
                                {
                                    a = (int)uint.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    airportPanel[a-1].EmerganceInformation();
                                }
                                catch
                                {
                                    Console.WriteLine("Uncorrect choose");
                                }

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
