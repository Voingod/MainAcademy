﻿using System;
using System.Collections.Generic;
using System.Linq;

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
    class AirportPanel : InputUserValue<AirportPanel>
    {
        public AirportPanel(IPrinter<AirportPanel> getSetInfoIn) : base(getSetInfoIn)
        {

        }
        public int Gate { get; set; }
        public int FlightNumber { get; set; }
        public int Terminal { get; set; }
        public FlightStatus FlightStatus { get; set; }
        public EmergencyInformation EmergencyInformation { get; set; }
        public AirportArrival AirportArrival { get; set; }
        public AirportDeparture AirportDeparture { get; set; }
        public Airline Airline { get; set; }
        public Passenger Passenger
        {
            get { return passenger; }
            set { passenger = value; passenger.UseETest(); }

        }
        private Passenger passenger;
        private static readonly Enum unknownStatus = FlightStatus.unknown;
        public static void Menu(List<AirportPanel> airportPanel)
        {
            //NewPassanger(airportPanel[0],new Passenger(new ConsoleGetSetInfo()));
            do
            {
                Console.WriteLine();
                workWithUserData.Print(@"Please,  type the number:
        1.  Create new flight (input all data)
        2.  Delete flight
        3.  Update some information about flight
        4.  Search some information about flight
        5.  Output schedule
        6.  Output of the emergency information
        7.  Output price of airline
                    ");
                try
                {
                    int.TryParse(workWithUserData.EnteredValueByUser(), out int b);
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
                            PrintSchedule(airportPanel);
                            break;

                        case ParamMenu.outputEmergencyInformation:
                            PrintEmergencyInformation(airportPanel);
                            break;
                        case ParamMenu.outputPrice:
                            workWithUserData.PrintPrice(airportPanel);
                            break;
                        default:
                            workWithUserData.PrintUserUncorrectInput("Exit. Not found option");
                            break;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    workWithUserData.PrintUserUncorrectInput("Not found flight for entered value");
                }
                catch (Exception ex)
                {
                    workWithUserData.Print(ex.Message);
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    workWithUserData.Print("Press Spacebar to exit; press any key to continue");
                    Console.ResetColor();
                }
            } while (Console.ReadKey().Key != ConsoleKey.Spacebar);
        }
        private static AirportPanel CreateNewFlight()
        {
            workWithUserData.Print("Adding new flight");
            AirportPanel flight = new AirportPanel(new ConsoleWorkingOnUserData<AirportPanel>());
            AirportArrival airportArrival = new AirportArrival();
            AirportDeparture airportDeparture = new AirportDeparture();
            Airline airline = new Airline();

            workWithUserData.Print("Enter airline: ");
            airline.AirlineName = workWithUserData.EnteredValueByUser();


            foreach (var item in Enum.GetValues(typeof(AirlineClass)))
            {
                workWithUserData.Print($"Enter price for {item} class: ");
                EnteredValueByUser(out int price);
                airline.PriceOfAirlineClass.Add((AirlineClass)item, price);
            }

            workWithUserData.Print("Enter flight number: ");
            EnteredValueByUser(out int flightNumber);
            flight.FlightNumber = flightNumber;

            workWithUserData.Print("Choose status for adding: ");
            flight.FlightStatus = NewStatus(flight);

            workWithUserData.Print("Enter number of gate: ");
            EnteredValueByUser(out int gate);
            flight.Gate = gate;

            workWithUserData.Print("Enter Terminal: ");
            EnteredValueByUser(out int terminal);
            flight.Terminal = terminal;

            workWithUserData.Print("Choose emergency information for adding: ");
            flight.EmergencyInformation = NewEmergencyInformation(flight);

            workWithUserData.Print("Enter arrival city: ");
            airportArrival.ArrivalCity = workWithUserData.EnteredValueByUser();

            workWithUserData.Print("Enter arrival date and time: ");
            EnteredValueByUser(out DateTime arrivalDate);
            airportArrival.ArrivalDate = arrivalDate;

            workWithUserData.Print("Enter arrival port: ");
            airportArrival.ArrivalPort = workWithUserData.EnteredValueByUser();

            workWithUserData.Print("Enter departure city: ");
            airportDeparture.DepartureCity = workWithUserData.EnteredValueByUser();

            workWithUserData.Print("Enter departure date and time: ");
            EnteredValueByUser(out DateTime departureDate);
            airportDeparture.DepartureDate = departureDate;

            workWithUserData.Print("Enter departure port: ");
            airportDeparture.DeparturePort = workWithUserData.EnteredValueByUser();

            flight.AirportArrival = airportArrival;
            flight.AirportDeparture = airportDeparture;
            flight.Airline = airline;

            return flight;
        }
        private static void PrintFlights(List<AirportPanel> airportPanel)
        {
            for (int i = 0; i < airportPanel.Count; i++)
            {
                workWithUserData.Print($@"        {i + 1}.  Flight: {airportPanel[i].FlightNumber}");
            }
        }
        private static int DeleteFlight(List<AirportPanel> airportPanel)
        {
            workWithUserData.Print("Choose schedule for delete:");
            PrintFlights(airportPanel);
            EnteredValueByUser(out int input);
            return input - 1;
        }
        private static void UpdateFlightsInformation(List<AirportPanel> airportPanel)
        {
            workWithUserData.Print("Choose schedule for update:");
            PrintFlights(airportPanel);
            EnteredValueByUser(out int a);
            AirportArrival airportArrival = airportPanel[a - 1].AirportArrival;
            AirportDeparture airportDeparture = airportPanel[a - 1].AirportDeparture;
            Airline airline = airportPanel[a - 1].Airline;

            Console.WriteLine();
            workWithUserData.Print(@"What do you want to update?
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

            int.TryParse(workWithUserData.EnteredValueByUser(), out int param);
            ParamUpdate b = (ParamUpdate)param;
            switch (b)
            {
                case ParamUpdate.NumberOfGate:
                    workWithUserData.Print("Enter new number of gate: ");
                    EnteredValueByUser(out int gate);
                    airportPanel[a - 1].Gate = gate;
                    Console.WriteLine();
                    break;

                case ParamUpdate.FlightNumber:
                    workWithUserData.Print("Enter new flight number: ");
                    EnteredValueByUser(out int flightNumber);
                    airportPanel[a - 1].FlightNumber = flightNumber;
                    Console.WriteLine();
                    break;

                case ParamUpdate.Airline:
                    workWithUserData.Print("Enter new airline: ");
                    airline.AirlineName = workWithUserData.EnteredValueByUser();
                    airportPanel[a - 1].Airline = airline;
                    Console.WriteLine();
                    break;

                case ParamUpdate.Terminal:
                    workWithUserData.Print("Enter new terminal: ");
                    EnteredValueByUser(out int terminal);
                    airportPanel[a - 1].Terminal = terminal;
                    Console.WriteLine();
                    break;

                case ParamUpdate.FlightStatus:
                    workWithUserData.Print("Choose new status: ");
                    airportPanel[a - 1].FlightStatus = NewStatus(airportPanel[a - 1]);
                    break;

                case ParamUpdate.EmergencyInformation:
                    workWithUserData.Print("Choose new emergency information: ");
                    airportPanel[a - 1].EmergencyInformation = NewEmergencyInformation(airportPanel[a - 1]);
                    break;

                case ParamUpdate.DateOfArrive:
                    workWithUserData.Print("Enter new arrival date and time: ");
                    EnteredValueByUser(out DateTime arrivalDate);
                    airportArrival.ArrivalDate = arrivalDate;
                    airportPanel[a - 1].AirportArrival = airportArrival;
                    Console.WriteLine();
                    break;

                case ParamUpdate.ArrivalCity:
                    workWithUserData.Print("Enter new arrival city: ");
                    airportArrival.ArrivalCity = workWithUserData.EnteredValueByUser();
                    airportPanel[a - 1].AirportArrival = airportArrival;
                    Console.WriteLine();
                    break;

                case ParamUpdate.ArrivalPort:
                    workWithUserData.Print("Enter new arrival port: ");
                    airportArrival.ArrivalPort = workWithUserData.EnteredValueByUser();
                    airportPanel[a - 1].AirportArrival = airportArrival;
                    Console.WriteLine();
                    break;

                case ParamUpdate.DateOfDeparture:
                    workWithUserData.Print("Enter new departure date and time: ");
                    EnteredValueByUser(out DateTime departureDate);
                    airportDeparture.DepartureDate = departureDate;
                    airportPanel[a - 1].AirportDeparture = airportDeparture;
                    Console.WriteLine();
                    break;

                case ParamUpdate.DepartureCity:
                    workWithUserData.Print("Enter new departure city: ");
                    airportDeparture.DepartureCity = workWithUserData.EnteredValueByUser();
                    airportPanel[a - 1].AirportDeparture = airportDeparture;
                    Console.WriteLine();
                    break;

                case ParamUpdate.DeparturePort:
                    workWithUserData.Print("Enter new departure port: ");
                    airportDeparture.DeparturePort = workWithUserData.EnteredValueByUser();
                    airportPanel[a - 1].AirportDeparture = airportDeparture;
                    Console.WriteLine();
                    break;

                default:
                    workWithUserData.PrintUserUncorrectInput("Exit. Not found option");
                    break;
            }
        }
        private static void SetSearchParametr(List<AirportPanel> airportPanel, Func<AirportPanel, bool> searchParametr)
        {
            foreach (var flight in airportPanel)
            {
                if (searchParametr(flight))
                {
                    workWithUserData.Print(flight);
                }
            }
        }
        private static void SearchInformation(List<AirportPanel> airportPanel)
        {
            Func<AirportPanel, bool> compare;
            string[] parametrs = { "Flight number", "Date and time for arriaval", "Arrival port", "Departure port",
                                        "The nearest (1 hour) flight (time to)", "The nearest (1 hour) flight (time from)" };
            workWithUserData.Print("Choose parametr, which you want to use for search: ");
            for (int i = 0; i < parametrs.Length; i++)
            {
                workWithUserData.Print($"       {i + 1}.  {parametrs[i]}");
            }
            EnteredValueByUser(out int searchParamNumber);
            ParamForSearch searchParam = (ParamForSearch)searchParamNumber;
            switch (searchParam)
            {
                case ParamForSearch.flightNumber:
                    {
                        workWithUserData.Print($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        EnteredValueByUser(out int searchFlightNumber);
                        SetSearchParametr(airportPanel, compare = (flight) => flight.FlightNumber == searchFlightNumber);
                        break;
                    }
                case ParamForSearch.dataTimeOfarrival:
                    {
                        workWithUserData.Print($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        EnteredValueByUser(out DateTime searchArrivalTime);
                        SetSearchParametr(airportPanel, compare = (flight) => flight.AirportArrival.ArrivalDate.Date == searchArrivalTime.Date &&
                                (int)flight.AirportArrival.ArrivalDate.TimeOfDay.TotalSeconds == (int)searchArrivalTime.TimeOfDay.TotalSeconds);
                        break;
                    }
                case ParamForSearch.arrivalPort:
                    {
                        workWithUserData.Print($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        string searchArrivalPort = workWithUserData.EnteredValueByUser();
                        SetSearchParametr(airportPanel, compare = (flight) => flight.AirportArrival.ArrivalPort == searchArrivalPort);
                        break;
                    }
                case ParamForSearch.departurePort:
                    {
                        workWithUserData.Print($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        string searchDeparturePort = workWithUserData.EnteredValueByUser();
                        SetSearchParametr(airportPanel, compare = (flight) => flight.AirportDeparture.DeparturePort == searchDeparturePort);
                        break;
                    }
                case ParamForSearch.nearestFlightArrived:
                    {
                        Sort(ref airportPanel, ParamForSearch.nearestFlightArrived);
                        NearestFlight(airportPanel, ParamForSearch.nearestFlightArrived);
                        break;
                    }
                case ParamForSearch.nearestFlightDeparture:
                    {
                        Sort(ref airportPanel, ParamForSearch.nearestFlightDeparture);
                        NearestFlight(airportPanel, ParamForSearch.nearestFlightDeparture);
                        break;
                    }
                default:
                    workWithUserData.PrintUserUncorrectInput("Exit. Not found option");
                    break;
            }
        }
        private static void PrintSchedule(List<AirportPanel> airportPanel)
        {
            for (int i = 0; i < airportPanel.Count; i++)
            {
                workWithUserData.Print(airportPanel[i]);
            }
        }
        private static void PrintEmergencyInformation(List<AirportPanel> airportPanel)
        {
            workWithUserData.Print("Where do you want to find out about an emergency?");
            PrintFlights(airportPanel);
            EnteredValueByUser(out int a);
            Console.WriteLine();
            workWithUserData.PrintEmerganceInformation(airportPanel[a - 1]);
        }
        private static void PrintEnum(Type t)
        {
            int skipUnknownEnter = 0;
            for (int i = 0; i < Enum.GetNames(t).Length; i++)
            {
                if (Enum.GetName(t, i) == unknownStatus.ToString())
                {
                    skipUnknownEnter++;
                    continue;
                }

                workWithUserData.Print($@"           {i + 1 - skipUnknownEnter}. {Enum.GetName(t, i)}");
            }
        }
        private static EmergencyInformation NewEmergencyInformation(AirportPanel flight)
        {
            PrintEnum(typeof(EmergencyInformation));
            EnteredValueByUser(out int emergencyInformation);
            if (emergencyInformation > (int)EmergencyInformation.unknown)
                emergencyInformation += 1;
            if (!Enum.IsDefined(typeof(EmergencyInformation), emergencyInformation - 1))
            {
                workWithUserData.PrintUserUncorrectInput("Not found option");
                return flight.EmergencyInformation;
            }

            return (EmergencyInformation)(emergencyInformation - 1);
        }

        private static FlightStatus NewStatus(AirportPanel flight)
        {
            PrintEnum(typeof(FlightStatus));
            EnteredValueByUser(out int flightStatus);
            if (flightStatus > (int)FlightStatus.unknown)
                flightStatus += 1;
            if (!Enum.IsDefined(typeof(FlightStatus), flightStatus - 1))
            {
                workWithUserData.PrintUserUncorrectInput("Not found option");
                return flight.FlightStatus;
            }

            return (FlightStatus)(flightStatus - 1);
        }
        private static void NewPassanger(AirportPanel flight, Passenger passenger)
        {
            flight.Passenger = passenger;
        }
        private static void Sort(ref List<AirportPanel> airportPanel, ParamForSearch flightPlace)
        {
            airportPanel = flightPlace == ParamForSearch.nearestFlightArrived ?
                 airportPanel.OrderBy(airport => airport.AirportArrival.ArrivalDate).ToList() :
                 airportPanel.OrderBy(airport => airport.AirportDeparture.DepartureDate).ToList();
        }
        private static void NearestFlight(List<AirportPanel> airportPanel, ParamForSearch flightPlace)
        {
            workWithUserData.Print($"Enter port: ");
            string enteredPort = workWithUserData.EnteredValueByUser();

            workWithUserData.Print($"Enter time: ");
            EnteredValueByUser(out TimeSpan enteredTime);

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
                        workWithUserData.Print(airportPanel[i]);
                    }
                }
            }
        }
    }
}
