using System;
using System.Collections.Generic;

namespace Airport
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
        public AirportPanel(IGetSetInfo getSetInfoIn)
        {
            getSetInfo = getSetInfoIn;
        }
        private static IGetSetInfo getSetInfo;
        public int Gate { get; set; }
        public int FlightNumber { get; set; }
        public string Airline { get; set; }
        public int Terminal { get; set; }
        public FlightStatus FlightStatus { get; set; }
        public EmergencyInformation EmergencyInformation { get; set; }
        public AirportArrival AirportArrival { get; set; }
        public AirportDeparture AirportDeparture { get; set; }
        public static void MenuPanel(List<AirportPanel> airportPanel)
        {
            do
            {

                Console.WriteLine();
                getSetInfo.GetInfoCommon(@"Please,  type the number:
        1.  Create new flight (input all data)
        2.  Delete flight
        3.  Update some information about flight
        4.  Search some information about flight
        5.  Output schedule
        6.  Output of the emergency information 
                    ");
                try
                {
                    int.TryParse(getSetInfo.SetInfo(), out int b);
                    Console.WriteLine(int.TryParse(getSetInfo.SetInfo(), out int z));
                    ParamMenu a = (ParamMenu)b;

                    Console.WriteLine();
                    switch (a)
                    {
                        case ParamMenu.createNewFlight:
                            airportPanel.Add(Airport.AirportPanel.CreateNewFlight());
                            break;

                        case ParamMenu.deleteFlight:
                            airportPanel.RemoveAt(Airport.AirportPanel.DeleteFlight(airportPanel));
                            break;

                        case ParamMenu.updateFlightsInformation:
                            Airport.AirportPanel.UpdateFlightsInformation(airportPanel);
                            break;

                        case ParamMenu.searchInformation:
                            Airport.AirportPanel.SearchInformation(airportPanel);
                            break;

                        case ParamMenu.outputSchedule:
                            Airport.AirportPanel.OutputSchedule(airportPanel);
                            break;

                        case ParamMenu.outputEmergencyInformation:
                            Airport.AirportPanel.OutputEmergencyInformation(airportPanel);

                            break;
                        default:
                            getSetInfo.GetInfoUncorredEntered("Exit. Not found option");
                            break;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    getSetInfo.GetInfoUncorredEntered("Not found flight for entered value");
                }
                catch (Exception ex)
                {
                    getSetInfo.GetInfoCommon(ex.Message);
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    getSetInfo.GetInfoCommon("Press Spacebar to exit; press any key to continue");
                    Console.ResetColor();
                }
            } while (Console.ReadKey().Key != ConsoleKey.Spacebar);
        }
        private static AirportPanel CreateNewFlight()
        {
            getSetInfo.GetInfoCommon("Adding new flight");
            AirportPanel flight = new AirportPanel(new ConsoleGetSetInfo());
            AirportArrival airportArrival = new AirportArrival();
            AirportDeparture airportDeparture = new AirportDeparture();

            getSetInfo.GetInfoEntered("Enter airline: ");
            flight.Airline = getSetInfo.SetInfo();

            getSetInfo.GetInfoEntered("Enter flight number: ");
            SetParam(out int flightNumber);
            flight.FlightNumber = flightNumber;

            getSetInfo.GetInfoCommon("Choose status for adding: ");
            NewStatus(flight);

            getSetInfo.GetInfoEntered("Enter number of gate: ");
            SetParam(out int gate);
            flight.Gate = gate;

            getSetInfo.GetInfoEntered("Enter Terminal: ");
            SetParam(out int terminal);
            flight.Terminal = terminal;

            getSetInfo.GetInfoCommon("Choose emergency information for adding: ");
            NewEmergencyInformation(flight);

            getSetInfo.GetInfoEntered("Enter arrival city: ");
            airportArrival.ArrivalCity = getSetInfo.SetInfo();

            getSetInfo.GetInfoEntered("Enter arrival date and time: ");
            SetParam(out DateTime arrivalDate);
            airportArrival.ArrivalDate = arrivalDate;

            getSetInfo.GetInfoEntered("Enter arrival port: ");
            airportArrival.ArrivalPort = getSetInfo.SetInfo();

            getSetInfo.GetInfoEntered("Enter departure city: ");
            airportDeparture.DepartureCity = getSetInfo.SetInfo();

            getSetInfo.GetInfoEntered("Enter departure date and time: ");
            SetParam(out DateTime departureDate);
            airportDeparture.DepartureDate = departureDate;

            getSetInfo.GetInfoEntered("Enter departure port: ");
            airportDeparture.DeparturePort = getSetInfo.SetInfo();

            flight.AirportArrival = airportArrival;
            flight.AirportDeparture = airportDeparture;

            return flight;
        }
        private static int DeleteFlight(List<AirportPanel> airportPanel)
        {
            getSetInfo.GetInfoCommon("Choose schedule for delete:");
            for (int i = 0; i < airportPanel.Count; i++)
            {
                getSetInfo.GetInfoCommon($@"        {i + 1}.  Flight: {airportPanel[i].FlightNumber}");
            }
            SetParam(out int input);
            return input - 1;
        }
        private static void UpdateFlightsInformation(List<AirportPanel> airportPanel)
        {
            getSetInfo.GetInfoCommon("Choose schedule for update:");
            for (int i = 0; i < airportPanel.Count; i++)
            {
                getSetInfo.GetInfoCommon($@"        {i + 1}.  Flight: {airportPanel[i].FlightNumber}");
            }
            SetParam(out int a);
            AirportArrival airportArrival = airportPanel[a - 1].AirportArrival;
            AirportDeparture airportDeparture = airportPanel[a - 1].AirportDeparture;

            Console.WriteLine();
            getSetInfo.GetInfoCommon(@"What do you want to update?
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

            int.TryParse(getSetInfo.SetInfo(), out int param);
            ParamUpdate b = (ParamUpdate)param;
            switch (b)
            {
                case ParamUpdate.updateNumberOfGate:
                    getSetInfo.GetInfoEntered("Enter new number of gate: ");
                    SetParam(out int gate);
                    airportPanel[a - 1].Gate = gate;
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateFlightNumber:
                    getSetInfo.GetInfoEntered("Enter new flight number: ");
                    SetParam(out int flightNumber);
                    airportPanel[a - 1].FlightNumber = flightNumber;
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateAirline:
                    getSetInfo.GetInfoEntered("Enter new airline: ");
                    airportPanel[a - 1].Airline = getSetInfo.SetInfo();
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateTerminal:
                    getSetInfo.GetInfoEntered("Enter new terminal: ");
                    SetParam(out int terminal);
                    airportPanel[a - 1].Terminal = terminal;
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateFlightStatus:
                    getSetInfo.GetInfoCommon("Choose new status: ");
                    NewStatus(airportPanel[a - 1]);
                    break;

                case ParamUpdate.updateEmergencyInformation:
                    getSetInfo.GetInfoCommon("Choose new emergency information: ");
                    NewEmergencyInformation(airportPanel[a - 1]);
                    break;

                case ParamUpdate.updateDateOfArrive:
                    getSetInfo.GetInfoEntered("Enter new arrival date and time: ");
                    SetParam(out DateTime arrivalDate);
                    airportArrival.ArrivalDate = arrivalDate;
                    airportPanel[a - 1].AirportArrival = airportArrival;
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateArrivalCity:
                    getSetInfo.GetInfoEntered("Enter new arrival city: ");
                    airportArrival.ArrivalCity = getSetInfo.SetInfo();
                    airportPanel[a - 1].AirportArrival = airportArrival;
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateArrivalPort:
                    getSetInfo.GetInfoEntered("Enter new arrival port: ");
                    airportArrival.ArrivalPort = getSetInfo.SetInfo();
                    airportPanel[a - 1].AirportArrival = airportArrival;
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateDateOfDeparture:
                    getSetInfo.GetInfoEntered("Enter new departure date and time: ");
                    SetParam(out DateTime departureDate);
                    airportDeparture.DepartureDate = departureDate;
                    airportPanel[a - 1].AirportDeparture = airportDeparture;
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateDepartureCity:
                    getSetInfo.GetInfoEntered("Enter new departure city: ");
                    airportDeparture.DepartureCity = getSetInfo.SetInfo();
                    airportPanel[a - 1].AirportDeparture = airportDeparture;
                    Console.WriteLine();
                    break;

                case ParamUpdate.updateDeparturePort:
                    getSetInfo.GetInfoEntered("Enter new departure port: ");
                    airportDeparture.DeparturePort = getSetInfo.SetInfo();
                    airportPanel[a - 1].AirportDeparture = airportDeparture;
                    Console.WriteLine();
                    break;

                default:
                    getSetInfo.GetInfoUncorredEntered("Exit. Not found option");
                    break;
            }
        }
        private static void SetSearchParametr(List<AirportPanel> airportPanel, Func<AirportPanel, bool> searchParametr)
        {
            foreach (var flight in airportPanel)
            {
                if (searchParametr(flight))
                {
                    getSetInfo.GetInfoSchedule(flight);
                }
            }
        }
        private static void SearchInformation(List<AirportPanel> airportPanel)
        {
            Func<AirportPanel, bool> compare;
            string[] parametrs = { "Flight number", "Date and time for arriaval", "Arrival port", "Departure port",
                                        "The nearest (1 hour) flight (time to)", "The nearest (1 hour) flight (time from)" };
            getSetInfo.GetInfoCommon("Choose parametr, which you want to use for search: ");
            for (int i = 0; i < parametrs.Length; i++)
            {
                getSetInfo.GetInfoCommon($"       {i + 1}.  {parametrs[i]}");
            }
            SetParam(out int searchParamNumber);
            ParamForSearch searchParam = (ParamForSearch)searchParamNumber;
            switch (searchParam)
            {
                case ParamForSearch.flightNumber:
                    {
                        getSetInfo.GetInfoEntered($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        SetParam(out int searchFlightNumber);
                        SetSearchParametr(airportPanel, compare = (flight) => flight.FlightNumber == searchFlightNumber);
                        break;
                    }
                case ParamForSearch.dataTimeOfarrival:
                    {
                        getSetInfo.GetInfoEntered($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        SetParam(out DateTime searchArrivalTime);
                        SetSearchParametr(airportPanel, compare = (flight) => flight.AirportArrival.ArrivalDate.Date == searchArrivalTime.Date &&
                                (int)flight.AirportArrival.ArrivalDate.TimeOfDay.TotalSeconds == (int)searchArrivalTime.TimeOfDay.TotalSeconds);
                        break;
                    }
                case ParamForSearch.arrivalPort:
                    {
                        getSetInfo.GetInfoEntered($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        string searchArrivalPort = getSetInfo.SetInfo();
                        SetSearchParametr(airportPanel, compare = (flight) => flight.AirportArrival.ArrivalPort == searchArrivalPort);
                        break;
                    }
                case ParamForSearch.departurePort:
                    {
                        getSetInfo.GetInfoEntered($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        string searchDeparturePort = getSetInfo.SetInfo();
                        SetSearchParametr(airportPanel, compare = (flight) => flight.AirportDeparture.DeparturePort == searchDeparturePort);
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
                    getSetInfo.GetInfoUncorredEntered("Exit. Not found option");
                    break;
            }
        }
        private static void OutputSchedule(List<AirportPanel> airportPanel)
        {
            for (int i = 0; i < airportPanel.Count; i++)
            {
                getSetInfo.GetInfoSchedule(airportPanel[i]);
            }
        }
        private static void OutputEmergencyInformation(List<AirportPanel> airportPanel)
        {
            getSetInfo.GetInfoCommon("Where do you want to find out about an emergency?");
            for (int i = 0; i < airportPanel.Count; i++)
            {
                getSetInfo.GetInfoCommon($"        {i + 1}.  Flight: {airportPanel[i].FlightNumber}");
            }
            SetParam(out int a);
            Console.WriteLine();
            getSetInfo.GetInfoEmergance(airportPanel[a - 1]);
        }
        private static void NewStatus(AirportPanel flight)
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
                getSetInfo.GetInfoCommon($@"           {i + 1 - skipUnknownEnter}.{Enum.GetName(typeof(FlightStatus), i)}");
            }
            SetParam(out int status);
            int statusEnterNumber = status - 1;
            if (statusEnterNumber > unknownEnter)
            {
                statusEnterNumber += skipUnknownEnter;
            }
            if (!Enum.IsDefined(typeof(FlightStatus), statusEnterNumber))
            {
                getSetInfo.GetInfoUncorredEntered("Not found option");
                flight.FlightStatus = FlightStatus.unknown;
            }
            else
            {
                flight.FlightStatus = (FlightStatus)statusEnterNumber;
            }
        }
        private static void NewEmergencyInformation(AirportPanel flight)
        {
            for (int i = 0; i < Enum.GetNames(typeof(EmergencyInformation)).Length; i++)
            {
                getSetInfo.GetInfoCommon($@"           {i + 1}. {Enum.GetName(typeof(EmergencyInformation), i)}");
            }
            SetParam(out int emergencyInformation);
            if (!Enum.IsDefined(typeof(EmergencyInformation), emergencyInformation - 1))
            {
                getSetInfo.GetInfoUncorredEntered("Not found option");
                return;
            }

            flight.EmergencyInformation = (EmergencyInformation)(emergencyInformation - 1);
        }
        private static void Sort(List<AirportPanel> airportPanel, ParamForSearch flightPlace)
        {
            for (int i = 0; i < airportPanel.Count; i++)
            {
                for (int j = 0; j < airportPanel.Count - 1; j++)
                {
                    bool sort = flightPlace == ParamForSearch.nearestFlightArrived ?
                        airportPanel[j].AirportArrival.ArrivalDate > airportPanel[j + 1].AirportArrival.ArrivalDate :
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
        private static void NearestFlight(List<AirportPanel> airportPanel, ParamForSearch flightPlace)
        {
            getSetInfo.GetInfoEntered($"Enter port: ");
            string enteredPort = getSetInfo.SetInfo();

            getSetInfo.GetInfoEntered($"Enter time: ");
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
                        getSetInfo.GetInfoSchedule(airportPanel[i]);
                    }
                }
            }
        }
        private static void SetParam(out int param)
        {
            if (!int.TryParse(getSetInfo.SetInfo(), out param))
                getSetInfo.GetInfoUncorredEntered($"Uncorrect entered parameter");
        }
        private static void SetParam(out DateTime param)
        {
            if (!DateTime.TryParse(getSetInfo.SetInfo(), out param))
                getSetInfo.GetInfoUncorredEntered($"Uncorrect entered parameter");
        }
        private static void SetParam(out TimeSpan param)
        {
            if (!TimeSpan.TryParse(getSetInfo.SetInfo(), out param))
                getSetInfo.GetInfoUncorredEntered($"Uncorrect entered parameter");
        }

    }
    interface IGetSetInfo
    {
        void GetInfoSchedule(AirportPanel airportPanel);
        void GetInfoEmergance(AirportPanel airportPanel);
        void GetInfoUncorredEntered(string info);
        void GetInfoCommon(string info);
        void GetInfoEntered(string info);
        string SetInfo();
    }
    class ConsoleGetSetInfo: IGetSetInfo
    {
        public void GetInfoSchedule(AirportPanel airportPanel)
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
        public void GetInfoEmergance(AirportPanel airportPanel)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Emergence: {airportPanel.EmergencyInformation}");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.ResetColor();
        }
        public void GetInfoUncorredEntered(string info)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(info);
            Console.ResetColor();
        }
        public void GetInfoCommon(string info)
        {
            Console.WriteLine(info);
        }
        public void GetInfoEntered(string info)
        {
            Console.Write(info);
        }
        public string SetInfo()
        {
            string info = Console.ReadLine();
            return info;
        }
    }


}
