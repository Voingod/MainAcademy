using System;
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
    class AirportPanel:EnterUserData
    {

        public AirportPanel(IAirportUserData workWithUserData, ICommonUserData commonUserData) :base(commonUserData)
        {
            AirportPanel.workWithUserData = workWithUserData;
        }
        private static IAirportUserData workWithUserData;

        public int Gate { get; set; }
        public int FlightNumber { get; set; }
        public int Terminal { get; set; }
        public FlightStatus FlightStatus { get; set; }
        public EmergencyInformation EmergencyInformation { get; set; }
        public AirportArrival AirportArrival { get; set; }
        public AirportDeparture AirportDeparture { get; set; }
        public Airline Airline { get; set; }
        //public Passenger Passenger
        //{
        //    get { return passenger; }
        //    set { passenger = value; passenger.UseETest(); }

        //}
        //private Passenger passenger;
        
        public static void Menu(List<AirportPanel> airportPanel)
        {
            //NewPassanger(airportPanel[0],new Passenger(new ConsoleGetSetInfo()));
            do
            {
                Console.WriteLine();
                commonUserData.Print(@"Please,  type the number:
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
                    int.TryParse(commonUserData.EnteredValueByUser(), out int b);
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
                            commonUserData.PrintUserUncorrectInput("Exit. Not found option");
                            break;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    commonUserData.PrintUserUncorrectInput("Not found flight for entered value");
                }
                catch (Exception ex)
                {
                    commonUserData.Print(ex.Message);
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    commonUserData.Print("Press Spacebar to exit; press any key to continue");
                    Console.ResetColor();
                }
            } while (Console.ReadKey().Key != ConsoleKey.Spacebar);
        }
        private static AirportPanel CreateNewFlight()
        {
            commonUserData.Print("Adding new flight");
            AirportPanel flight = new AirportPanel(new ConsoleAirportUserData(), new ConsoleCommonUserData());
            AirportArrival airportArrival = new AirportArrival();
            AirportDeparture airportDeparture = new AirportDeparture();
            Airline airline = new Airline();

            commonUserData.Print("Enter airline: ");
            airline.AirlineName = commonUserData.EnteredValueByUser();


            foreach (var item in Enum.GetValues(typeof(AirlineClass)))
            {
                commonUserData.Print($"Enter price for {item} class: ");
                EnteredValueByUser(out int price);
                airline.PriceOfAirlineClass.Add((AirlineClass)item, price);
            }

            commonUserData.Print("Enter flight number: ");
            EnteredValueByUser(out int flightNumber);
            flight.FlightNumber = flightNumber;

            commonUserData.Print("Choose status for adding: ");
            flight.FlightStatus = NewStatus(flight);

            commonUserData.Print("Enter number of gate: ");
            EnteredValueByUser(out int gate);
            flight.Gate = gate;

            commonUserData.Print("Enter Terminal: ");
            EnteredValueByUser(out int terminal);
            flight.Terminal = terminal;

            commonUserData.Print("Choose emergency information for adding: ");
            flight.EmergencyInformation = NewEmergencyInformation(flight);

            commonUserData.Print("Enter arrival city: ");
            airportArrival.ArrivalCity = commonUserData.EnteredValueByUser();

            commonUserData.Print("Enter arrival date and time: ");
            EnteredValueByUser(out DateTime arrivalDate);
            airportArrival.ArrivalDate = arrivalDate;

            commonUserData.Print("Enter arrival port: ");
            airportArrival.ArrivalPort = commonUserData.EnteredValueByUser();

            commonUserData.Print("Enter departure city: ");
            airportDeparture.DepartureCity = commonUserData.EnteredValueByUser();

            commonUserData.Print("Enter departure date and time: ");
            EnteredValueByUser(out DateTime departureDate);
            airportDeparture.DepartureDate = departureDate;

            commonUserData.Print("Enter departure port: ");
            airportDeparture.DeparturePort = commonUserData.EnteredValueByUser();

            flight.AirportArrival = airportArrival;
            flight.AirportDeparture = airportDeparture;
            flight.Airline = airline;

            return flight;
        }
        private static void PrintFlights(List<AirportPanel> airportPanel)
        {
            for (int i = 0; i < airportPanel.Count; i++)
            {
                commonUserData.Print($@"        {i + 1}.  Flight: {airportPanel[i].FlightNumber}");
            }
        }
        private static int DeleteFlight(List<AirportPanel> airportPanel)
        {
            commonUserData.Print("Choose schedule for delete:");
            PrintFlights(airportPanel);
            EnteredValueByUser(out int input);
            return input - 1;
        }
        private static void UpdateFlightsInformation(List<AirportPanel> airportPanel)
        {
            commonUserData.Print("Choose schedule for update:");
            PrintFlights(airportPanel);
            EnteredValueByUser(out int a);
            AirportArrival airportArrival = airportPanel[a - 1].AirportArrival;
            AirportDeparture airportDeparture = airportPanel[a - 1].AirportDeparture;
            Airline airline = airportPanel[a - 1].Airline;

            Console.WriteLine();
            commonUserData.Print(@"What do you want to update?
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
        13. Price
                    ");

            int.TryParse(commonUserData.EnteredValueByUser(), out int param);
            ParamUpdate b = (ParamUpdate)param;
            switch (b)
            {
                case ParamUpdate.NumberOfGate:
                    commonUserData.Print("Enter new number of gate: ");
                    EnteredValueByUser(out int gate);
                    airportPanel[a - 1].Gate = gate;
                    Console.WriteLine();
                    break;

                case ParamUpdate.FlightNumber:
                    commonUserData.Print("Enter new flight number: ");
                    EnteredValueByUser(out int flightNumber);
                    airportPanel[a - 1].FlightNumber = flightNumber;
                    Console.WriteLine();
                    break;

                case ParamUpdate.Airline:
                    commonUserData.Print("Enter new airline: ");
                    airline.AirlineName = commonUserData.EnteredValueByUser();
                    airportPanel[a - 1].Airline = airline;
                    Console.WriteLine();
                    break;

                case ParamUpdate.Price:
                    {
                        commonUserData.Print("Enter class for update price: ");
                        PrintEnum(typeof(AirlineClass));
                        EnteredValueByUser(out int type);
                        AirlineClass typeEntered = (AirlineClass)(--type);
                       
                        commonUserData.Print("Enter price: ");
                        EnteredValueByUser(out int price);

                        switch (typeEntered)
                        {
                            case AirlineClass.bussines:
                                airline.PriceOfAirlineClass[AirlineClass.bussines] = price;
                                break;
                            case AirlineClass.econom:
                                airline.PriceOfAirlineClass[AirlineClass.econom] = price;
                                break;
                            default:
                                commonUserData.PrintUserUncorrectInput("Exit. Not found option");
                                break;
                        }
                        airportPanel[a - 1].Airline = airline;
                        Console.WriteLine();
                        break;
                    }

                case ParamUpdate.Terminal:
                    commonUserData.Print("Enter new terminal: ");
                    EnteredValueByUser(out int terminal);
                    airportPanel[a - 1].Terminal = terminal;
                    Console.WriteLine();
                    break;

                case ParamUpdate.FlightStatus:
                    commonUserData.Print("Choose new status: ");
                    airportPanel[a - 1].FlightStatus = NewStatus(airportPanel[a - 1]);
                    break;

                case ParamUpdate.EmergencyInformation:
                    commonUserData.Print("Choose new emergency information: ");
                    airportPanel[a - 1].EmergencyInformation = NewEmergencyInformation(airportPanel[a - 1]);
                    break;

                case ParamUpdate.DateOfArrive:
                    commonUserData.Print("Enter new arrival date and time: ");
                    EnteredValueByUser(out DateTime arrivalDate);
                    airportArrival.ArrivalDate = arrivalDate;
                    airportPanel[a - 1].AirportArrival = airportArrival;
                    Console.WriteLine();
                    break;

                case ParamUpdate.ArrivalCity:
                    commonUserData.Print("Enter new arrival city: ");
                    airportArrival.ArrivalCity = commonUserData.EnteredValueByUser();
                    airportPanel[a - 1].AirportArrival = airportArrival;
                    Console.WriteLine();
                    break;

                case ParamUpdate.ArrivalPort:
                    commonUserData.Print("Enter new arrival port: ");
                    airportArrival.ArrivalPort = commonUserData.EnteredValueByUser();
                    airportPanel[a - 1].AirportArrival = airportArrival;
                    Console.WriteLine();
                    break;

                case ParamUpdate.DateOfDeparture:
                    commonUserData.Print("Enter new departure date and time: ");
                    EnteredValueByUser(out DateTime departureDate);
                    airportDeparture.DepartureDate = departureDate;
                    airportPanel[a - 1].AirportDeparture = airportDeparture;
                    Console.WriteLine();
                    break;

                case ParamUpdate.DepartureCity:
                    commonUserData.Print("Enter new departure city: ");
                    airportDeparture.DepartureCity = commonUserData.EnteredValueByUser();
                    airportPanel[a - 1].AirportDeparture = airportDeparture;
                    Console.WriteLine();
                    break;

                case ParamUpdate.DeparturePort:
                    commonUserData.Print("Enter new departure port: ");
                    airportDeparture.DeparturePort = commonUserData.EnteredValueByUser();
                    airportPanel[a - 1].AirportDeparture = airportDeparture;
                    Console.WriteLine();
                    break;

                default:
                    commonUserData.PrintUserUncorrectInput("Exit. Not found option");
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
                                        "The nearest (1 hour) flight (time to)", "The nearest (1 hour) flight (time from)", "Price" };
            commonUserData.Print("Choose parametr, which you want to use for search: ");
            for (int i = 0; i < parametrs.Length; i++)
            {
                commonUserData.Print($"       {i + 1}.  {parametrs[i]}");
            }
            EnteredValueByUser(out int searchParamNumber);
            ParamForSearch searchParam = (ParamForSearch)searchParamNumber;
            switch (searchParam)
            {
                case ParamForSearch.flightNumber:
                    {
                        commonUserData.Print($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        EnteredValueByUser(out int searchFlightNumber);
                        SetSearchParametr(airportPanel, compare = (flight) => flight.FlightNumber == searchFlightNumber);
                        break;
                    }
                case ParamForSearch.dataTimeOfarrival:
                    {
                        commonUserData.Print($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        EnteredValueByUser(out DateTime searchArrivalTime);
                        SetSearchParametr(airportPanel, compare = (flight) => flight.AirportArrival.ArrivalDate.Date == searchArrivalTime.Date &&
                                (int)flight.AirportArrival.ArrivalDate.TimeOfDay.TotalSeconds == (int)searchArrivalTime.TimeOfDay.TotalSeconds);
                        break;
                    }
                case ParamForSearch.arrivalPort:
                    {
                        commonUserData.Print($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        string searchArrivalPort = commonUserData.EnteredValueByUser();
                        SetSearchParametr(airportPanel, compare = (flight) => flight.AirportArrival.ArrivalPort == searchArrivalPort);
                        break;
                    }
                case ParamForSearch.departurePort:
                    {
                        commonUserData.Print($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        string searchDeparturePort = commonUserData.EnteredValueByUser();
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
                case ParamForSearch.price:
                    {
                        commonUserData.Print($"Enter {parametrs[searchParamNumber - 1].ToLower()}: ");
                        EnteredValueByUser(out int price);
                        SetSearchParametr(airportPanel, compare = (flight) => flight.Airline.PriceOfAirlineClass[AirlineClass.econom] == price);
                        SetSearchParametr(airportPanel, compare = (flight) => flight.Airline.PriceOfAirlineClass[AirlineClass.bussines] == price);
                        break;
                    }
                default:
                    commonUserData.PrintUserUncorrectInput("Exit. Not found option");
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
            commonUserData.Print("Where do you want to find out about an emergency?");
            PrintFlights(airportPanel);
            EnteredValueByUser(out int a);
            Console.WriteLine();
            workWithUserData.PrintEmerganceInformation(airportPanel[a - 1]);
        }

        private static EmergencyInformation check(AirportPanel flight, Func<int, bool> isUnknown)
        {
            PrintEnum(typeof(EmergencyInformation));
            EnteredValueByUser(out int emergencyInformation);
            if (isUnknown(emergencyInformation))
                emergencyInformation += 1;
            if (!Enum.IsDefined(typeof(EmergencyInformation), emergencyInformation - 1))
            {
                commonUserData.PrintUserUncorrectInput("Not found option");
                return flight.EmergencyInformation;
            }

            return (EmergencyInformation)(emergencyInformation - 1);
        }

        private static EmergencyInformation NewEmergencyInformation(AirportPanel flight)
        {
            return check(flight, x => x > (int)EmergencyInformation.unknown);
        }

        private static FlightStatus NewStatus(AirportPanel flight)
        {
            PrintEnum(typeof(FlightStatus));
            EnteredValueByUser(out int flightStatus);
            if (flightStatus > (int)FlightStatus.unknown)
                flightStatus += 1;
            if (!Enum.IsDefined(typeof(FlightStatus), flightStatus - 1))
            {
                commonUserData.PrintUserUncorrectInput("Not found option");
                return flight.FlightStatus;
            }

            return (FlightStatus)(flightStatus - 1);
        }
        private static void NewPassanger(AirportPanel flight, Passenger passenger)
        {
            //flight.Passenger = passenger;
        }
        private static void Sort(ref List<AirportPanel> airportPanel, ParamForSearch flightPlace)
        {
            airportPanel = flightPlace == ParamForSearch.nearestFlightArrived ?
                 airportPanel.OrderBy(airport => airport.AirportArrival.ArrivalDate).ToList() :
                 airportPanel.OrderBy(airport => airport.AirportDeparture.DepartureDate).ToList();
        }
        private static void NearestFlight(List<AirportPanel> airportPanel, ParamForSearch flightPlace)
        {
            commonUserData.Print($"Enter port: ");
            string enteredPort = commonUserData.EnteredValueByUser();

            commonUserData.Print($"Enter time: ");
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
