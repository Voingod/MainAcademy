using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Program
    {
        struct AirportArrival
        {
           public DateTime ArrivalDate { get; set; }
           public string ArrivalCity { get; set; }
           public string ArrivalPort { get; set; }
        }
        struct AirportDeparture
        {
            public DateTime DepartureDate { get; set; }
            public string DepartureCity { get; set; }
            public string DeparturePort { get; set; }
        }
        class AirportPanel
        {
            public int Gate { get; set; }
            public int FlightNumber { get; set; }
            public string Airline { get; set; }
            public int Terminal { get; set; }

            public FlightStatus FlightStatus { get; set; }
            public EmergencyInformation EmergencyInformation { get; set; }
            public AirportArrival AirportArrival {get; set; }
            public AirportDeparture AirportDeparture { get; set; }

            public static void GetInfoSchedule(AirportPanel airportPanel)
            {

                Console.WriteLine($"Airline: {airportPanel.Airline}\tFlight: {airportPanel.FlightNumber}\tTerminal: {airportPanel.Terminal}\tGate: {airportPanel.Gate}");
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
            public static void GetInfoEmergance(AirportPanel airportPanel)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Emergence: {airportPanel.EmergencyInformation}");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                Console.ResetColor();
            }
            public static void GetInfoUncorredEntered(string info)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(info);
                Console.ResetColor();
            }
            public static void GetInfoCommon(string info)
            {
                Console.WriteLine(info);
            }
            public static void GetInfoEntered(string info)
            {
                Console.Write(info);
            }
            public static string SetInfo ()
            {
                string info = Console.ReadLine();
                return info;
            }
        }

        static void Main(string[] args)
        {
            #region InitalizationArrayForFlighting
            Random random = new Random();

            const int flightsCount = 10;
            List<AirportPanel> airportPanel = new List<AirportPanel>();

            string[] airline = { "Ukraine Intl Air", "LOT", "KLM", "S7 Airlines", "Onur Air" };

            string[] arrivalCity = { "Rome", "Kyiv", "Bangkok", "Kingston", "London" };
            string[] arrivalPort = { "Borneo", "Madagascar", "Sumatra", "Honshu", "Sulawesi" };

            string[] departureCity = { "Kinshasa", "Libreville", "Nur-Sultan", "Oslo", "Ottawa" };
            string[] departurePort = { "Java", "Luzon", "Mindanao", "Marajó", "Kyushu" };

            for (int i = 0; i < flightsCount; i++)
            {
                AirportPanel flight = new AirportPanel
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

            do
            {
                
                Console.WriteLine();
                AirportPanel.GetInfoCommon(@"Please,  type the number:
        1.  Create new flight (input all data)
        2.  Delete flight
        3.  Update some information about flight
        4.  Search some information about flight
        5.  Output schedule
        6.  Output of the emergency information 
                    ");
                try
                {
                    int.TryParse(AirportPanel.SetInfo(), out int b);
                    ParamMenu a = (ParamMenu)b;

                    Console.WriteLine();
                    switch (a)
                    {
                        case ParamMenu.createNewFlight:
                            airportPanel.Add(CreateNewFlight());
                            break;

                        case ParamMenu.deleteFlight:
                            airportPanel.RemoveAt(DeleteFlight(airportPanel));
                            break;

                        case ParamMenu.updateFlightsInformation:
                            UpdateFlightsInformation(airportPanel);
                            break;

                        case ParamMenu.searchInformation:
                            SearchInformation(airportPanel);
                            break;

                        case ParamMenu.outputSchedule:
                            OutputSchedule(airportPanel);
                            break;

                        case ParamMenu.outputEmergencyInformation:
                            OutputEmergencyInformation(airportPanel);

                            break;
                        default:
                            AirportPanel.GetInfoUncorredEntered("Exit. Not found option");
                            break;
                    }
                }
                catch(ArgumentOutOfRangeException)
                {
                    AirportPanel.GetInfoUncorredEntered("Not found flight for entered value");
                }
                catch (Exception ex)
                {
                    AirportPanel.GetInfoCommon(ex.Message);
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    AirportPanel.GetInfoCommon("Press Spacebar to exit; press any key to continue");
                    Console.ResetColor();
                }
            } while (Console.ReadKey().Key != ConsoleKey.Spacebar);

            Console.ReadLine();
        }
        static AirportPanel CreateNewFlight()
        {
            AirportPanel.GetInfoCommon("Adding new flight");
            AirportPanel flight = new AirportPanel();
            AirportArrival airportArrival = new AirportArrival();
            AirportDeparture airportDeparture = new AirportDeparture();

            AirportPanel.GetInfoEntered("Enter airline: ");
            flight.Airline = AirportPanel.SetInfo();

            AirportPanel.GetInfoEntered("Enter flight number: ");
            SetParam(out int flightNumber);
            flight.FlightNumber = flightNumber;

            AirportPanel.GetInfoCommon("Choose status for adding: ");
            NewStatus(flight);

            AirportPanel.GetInfoEntered("Enter number of gate: ");
            SetParam(out int gate);
            flight.Gate = gate;

            AirportPanel.GetInfoEntered("Enter Terminal: ");
            SetParam(out int terminal);
            flight.Terminal = terminal;

            AirportPanel.GetInfoCommon("Choose emergency information for adding: ");
            NewEmergencyInformation(flight);

            AirportPanel.GetInfoEntered("Enter arrival city: ");
            airportArrival.ArrivalCity = AirportPanel.SetInfo();

            AirportPanel.GetInfoEntered("Enter arrival date and time: ");
            SetParam(out DateTime arrivalDate);
            airportArrival.ArrivalDate = arrivalDate;

            AirportPanel.GetInfoEntered("Enter arrival port: ");
            airportArrival.ArrivalPort = AirportPanel.SetInfo();

            AirportPanel.GetInfoEntered("Enter departure city: ");
            airportDeparture.DepartureCity = AirportPanel.SetInfo();

            AirportPanel.GetInfoEntered("Enter departure date and time: ");
            SetParam(out DateTime departureDate);
            airportDeparture.DepartureDate = departureDate;

            AirportPanel.GetInfoEntered("Enter departure port: ");
            airportDeparture.DeparturePort = AirportPanel.SetInfo();

            flight.AirportArrival = airportArrival;
            flight.AirportDeparture = airportDeparture;

            return flight;
        }
        static int DeleteFlight(List<AirportPanel> airportPanel)
        {
            AirportPanel.GetInfoCommon("Choose schedule for delete:");
            for (int i = 0; i < airportPanel.Count; i++)
            {
                AirportPanel.GetInfoCommon($@"        {i + 1}.  Flight: {airportPanel[i].FlightNumber}");
            }
            SetParam(out int input);
            return input - 1;
        }
        static void UpdateFlightsInformation(List<AirportPanel> airportPanel)
        {
            AirportPanel.GetInfoCommon("Choose schedule for update:");
            for (int i = 0; i < airportPanel.Count; i++)
            {
                AirportPanel.GetInfoCommon($@"        {i + 1}.  Flight: {airportPanel[i].FlightNumber}");
            }
            SetParam(out int a);
            AirportArrival airportArrival = airportPanel[a - 1].AirportArrival;
            AirportDeparture airportDeparture = airportPanel[a - 1].AirportDeparture;

            Console.WriteLine();
            AirportPanel.GetInfoCommon(@"What do you want to update?
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

            int.TryParse(AirportPanel.SetInfo(), out int param);
            ParamUpdate b = (ParamUpdate)param;
            switch (b)
            {
                case ParamUpdate.updateNumberOfGate:
                    AirportPanel.GetInfoEntered("Enter new number of gate: ");
                    SetParam(out int gate);
                    airportPanel[a - 1].Gate = gate;
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateFlightNumber:
                    AirportPanel.GetInfoEntered("Enter new flight number: ");
                    SetParam(out int flightNumber);
                    airportPanel[a - 1].FlightNumber = flightNumber;
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateAirline:
                    AirportPanel.GetInfoEntered("Enter new airline: ");
                    airportPanel[a - 1].Airline = AirportPanel.SetInfo();
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateTerminal:
                    AirportPanel.GetInfoEntered("Enter new terminal: ");
                    SetParam(out int terminal);
                    airportPanel[a - 1].Terminal = terminal;
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateFlightStatus:
                    AirportPanel.GetInfoCommon("Choose new status: ");
                    NewStatus(airportPanel[a - 1]);
                    break;

                case ParamUpdate.updateEmergencyInformation:
                    AirportPanel.GetInfoCommon("Choose new emergency information: ");
                    NewEmergencyInformation(airportPanel[a - 1]);
                    break;

                case ParamUpdate.updateDateOfArrive:
                    AirportPanel.GetInfoEntered("Enter new arrival date and time: ");
                    SetParam(out DateTime arrivalDate);
                    airportArrival.ArrivalDate = arrivalDate;
                    airportPanel[a - 1].AirportArrival = airportArrival;
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateArrivalCity:
                    AirportPanel.GetInfoEntered("Enter new arrival city: ");
                    airportArrival.ArrivalCity = AirportPanel.SetInfo();
                    airportPanel[a - 1].AirportArrival = airportArrival;
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateArrivalPort:
                    AirportPanel.GetInfoEntered("Enter new arrival port: ");
                    airportArrival.ArrivalPort = AirportPanel.SetInfo();
                    airportPanel[a - 1].AirportArrival = airportArrival;
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateDateOfDeparture:
                    AirportPanel.GetInfoEntered("Enter new departure date and time: ");
                    SetParam(out DateTime departureDate);
                    airportDeparture.DepartureDate = departureDate;
                    airportPanel[a - 1].AirportDeparture = airportDeparture;
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateDepartureCity:
                    AirportPanel.GetInfoEntered("Enter new departure city: ");
                    airportDeparture.DepartureCity = AirportPanel.SetInfo();
                    airportPanel[a - 1].AirportDeparture = airportDeparture;
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateDeparturePort:
                    AirportPanel.GetInfoEntered("Enter new departure port: ");
                    airportDeparture.DeparturePort = AirportPanel.SetInfo();
                    airportPanel[a - 1].AirportDeparture = airportDeparture;
                    Console.WriteLine();
                    break;

                default:
                    AirportPanel.GetInfoUncorredEntered("Exit. Not found option");
                    break;
            }
        }
        static void SearchInformation(List<AirportPanel> airportPanel)
        {
            Func<AirportPanel, bool> compare = Compare;

            string[] parametrs = { "Flight number", "Date and time for arriaval", "Arrival port", "Departure port",
                                        "The nearest (1 hour) flight (time to)", "The nearest (1 hour) flight (time from)" };
            AirportPanel.GetInfoCommon("Choose parametr, which you want to use for search: ");
            for (int i = 0; i < parametrs.Length; i++)
            {
                AirportPanel.GetInfoCommon($"       {i + 1}.  {parametrs[i]}");
            }
            SetParam(out int searchParamNumber);
            ParamForSearch searchParam = (ParamForSearch)searchParamNumber;
            switch (searchParam)
            {
                case ParamForSearch.flightNumber:
                    {
                        AirportPanel.GetInfoEntered($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        SetParam(out int searchFlightNumber);
                        for (int i = 0; i < airportPanel.Count; i++)
                        {
                            if (airportPanel[i].FlightNumber == searchFlightNumber)
                            {
                                AirportPanel.GetInfoSchedule(airportPanel[i]);
                            }
                        }
                        break;
                    }
                case ParamForSearch.dataTimeOfarrival:
                    {
                        AirportPanel.GetInfoEntered($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        SetParam(out DateTime searchArrivalTime);
                        for (int i = 0; i < airportPanel.Count; i++)
                        {
                            if (airportPanel[i].AirportArrival.ArrivalDate.Date == searchArrivalTime.Date&&
                                (int)airportPanel[i].AirportArrival.ArrivalDate.TimeOfDay.TotalSeconds == (int)searchArrivalTime.TimeOfDay.TotalSeconds)
                            {
                                AirportPanel.GetInfoSchedule(airportPanel[i]);
                            }
                        }
                        break;
                    }
                case ParamForSearch.arrivalPort:
                    {
                        AirportPanel.GetInfoEntered($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        string searchArrivalPort = AirportPanel.SetInfo();
                        for (int i = 0; i < airportPanel.Count; i++)
                        {
                            if (airportPanel[i].AirportArrival.ArrivalPort == searchArrivalPort)
                            {
                                AirportPanel.GetInfoSchedule(airportPanel[i]);
                            }
                        }
                        break;
                    }
                case ParamForSearch.departurePort:
                    {
                        AirportPanel.GetInfoEntered($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        string searchDeparturePort = AirportPanel.SetInfo();
                        for (int i = 0; i < airportPanel.Count; i++)
                        {
                            if (airportPanel[i].AirportDeparture.DeparturePort == searchDeparturePort)
                            {
                                AirportPanel.GetInfoSchedule(airportPanel[i]);
                            }
                        }
                        break;
                    }
                case ParamForSearch.nearestFlightArrived:
                    {
                        Sort(airportPanel, ParamForSearch.nearestFlightArrived);
                        NearestFlight(airportPanel, ParamForSearch.nearestFlightArrived);
                        break;
                    }
                case ParamForSearch.nearestFlightDeparture:
                    {
                        Sort(airportPanel, ParamForSearch.nearestFlightDeparture);
                        NearestFlight(airportPanel, ParamForSearch.nearestFlightDeparture);
                        break;
                    }
                default:
                    AirportPanel.GetInfoUncorredEntered("Exit. Not found option");
                    break;
            }
        }
        static void OutputSchedule(List<AirportPanel> airportPanel)
        {
            for (int i = 0; i < airportPanel.Count; i++)
            {
                AirportPanel.GetInfoSchedule(airportPanel[i]);
            }
        }
        static void OutputEmergencyInformation(List<AirportPanel> airportPanel)
        {
            AirportPanel.GetInfoCommon("Where do you want to find out about an emergency?");
            for (int i = 0; i < airportPanel.Count; i++)
            {
                AirportPanel.GetInfoCommon($"        {i + 1}.  Flight: {airportPanel[i].FlightNumber}");
            }
            SetParam(out int a);
            Console.WriteLine();
            AirportPanel.GetInfoEmergance(airportPanel[a - 1]);
        }
        static void NewStatus(AirportPanel flight)
        {
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
                AirportPanel.GetInfoCommon($@"           {i + 1 - skipUnknownEnter}.{Enum.GetName(typeof(FlightStatus), i)}");
            }
            SetParam(out int status);
            int statusEnterNumber = status - 1;
            if (statusEnterNumber > unknownEnter)
            {
                statusEnterNumber += skipUnknownEnter;
            }
            if (!Enum.IsDefined(typeof(FlightStatus), statusEnterNumber))
            {
                AirportPanel.GetInfoUncorredEntered("Not found option");
                flight.FlightStatus = FlightStatus.unknown;
            }
            else
            {
                flight.FlightStatus = (FlightStatus)statusEnterNumber;
            }
        }
        static void NewEmergencyInformation(AirportPanel flight)
        {
            for (int i = 0; i < Enum.GetNames(typeof(EmergencyInformation)).Length; i++)
            {
                AirportPanel.GetInfoCommon($@"           {i + 1}. {Enum.GetName(typeof(EmergencyInformation), i)}");
            }
            SetParam(out int emergencyInformation);
            if (!Enum.IsDefined(typeof(EmergencyInformation), emergencyInformation - 1))
            {
                AirportPanel.GetInfoUncorredEntered("Not found option");
                return;
            }
                
            flight.EmergencyInformation = (EmergencyInformation)(emergencyInformation - 1);
        }
        static void Sort(List<AirportPanel> airportPanel, ParamForSearch flightPlace)
        {
            for (int i = 0; i < airportPanel.Count; i++)
            {
                for (int j = 0; j < airportPanel.Count - 1; j++)
                {
                    bool sort = flightPlace == ParamForSearch.nearestFlightArrived ? 
                        airportPanel[j].AirportArrival.ArrivalDate > airportPanel[j + 1].AirportArrival.ArrivalDate:
                        airportPanel[j].AirportDeparture.DepartureDate > airportPanel[j + 1].AirportDeparture.DepartureDate;
                   
                    if (sort)
                    {
                        var tempAirport = airportPanel[j];
                        airportPanel[j] = airportPanel[j + 1];
                        airportPanel[j + 1] = tempAirport;

                    }
                }
            }
        }
        static void NearestFlight(List<AirportPanel> airportPanel, ParamForSearch flightPlace)
        {
            AirportPanel.GetInfoEntered($"Enter port: ");
            string enteredPort = AirportPanel.SetInfo();

            AirportPanel.GetInfoEntered($"Enter time: ");
            SetParam(out TimeSpan enteredTime);

            DateTime enteredDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                enteredTime.Hours, enteredTime.Minutes, 0);

            for (int i = 0; i < airportPanel.Count; i++)
            {
                string choosePort = flightPlace == ParamForSearch.nearestFlightArrived ?
                    airportPanel[i].AirportArrival.ArrivalPort : airportPanel[i].AirportDeparture.DeparturePort;
                if (choosePort == enteredPort)
                {
                    DateTime chooseDate = flightPlace == ParamForSearch.nearestFlightArrived ?
                        airportPanel[i].AirportArrival.ArrivalDate : airportPanel[i].AirportDeparture.DepartureDate;

                    if (chooseDate >= enteredDate.AddHours(-1) && chooseDate <= enteredDate.AddHours(1))
                    {
                        AirportPanel.GetInfoSchedule(airportPanel[i]);
                    }
                }
            }
        }
        static void SetParam(out int param)
        {
            if (!int.TryParse(AirportPanel.SetInfo(), out param))
                AirportPanel.GetInfoUncorredEntered($"Uncorrect entered parameter");
        }
        static void SetParam(out DateTime param)
        {
            if (!DateTime.TryParse(AirportPanel.SetInfo(), out param)) 
                AirportPanel.GetInfoUncorredEntered($"Uncorrect entered parameter");
        }
        static void SetParam(out TimeSpan param)
        {
            if (!TimeSpan.TryParse(AirportPanel.SetInfo(), out param)) 
                AirportPanel.GetInfoUncorredEntered($"Uncorrect entered parameter");
        }
        static bool Compare(AirportPanel airportPanel)
        {
            return true;
        }
        enum FlightStatus
        {
            checkIn, gateClosed, arrived, departedAt, unknown, canceled, expectedAt, delayed, inFlight
        }
        enum EmergencyInformation
        {
            evacuation, fire
        }
        enum ParamForSearch
        {
            flightNumber = 1, dataTimeOfarrival, arrivalPort, departurePort, nearestFlightArrived, nearestFlightDeparture
        }
        enum ParamMenu 
        { 
            createNewFlight=1, deleteFlight,updateFlightsInformation, searchInformation, outputSchedule, outputEmergencyInformation 
        }
        enum ParamUpdate
        {
            updateNumberOfGate = 1, updateFlightNumber, updateAirline, updateTerminal, updateFlightStatus, updateEmergencyInformation,
            updateDateOfArrive, updateArrivalCity, updateArrivalPort, updateDateOfDeparture, updateDepartureCity, updateDeparturePort
        }
    }
}
