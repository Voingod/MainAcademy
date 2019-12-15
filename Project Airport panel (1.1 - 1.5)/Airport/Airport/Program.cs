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
                //Console.WriteLine($"-Airline {airline}, flight number {flightNumber} from {airportDeparture.departureCity} port {airportDeparture.departurePort} to " +
                //    $"{airportArrival.arrivalCity} port {airportArrival.arrivalPort}\n" +
                //    $"will be departured at {airportDeparture.departureData} and will be arrived at {airportArrival.arrivalData}. \n" +
                //    $"Go to terminal {terminal}, gate {gate}\n\n" +
                //    $"Status {flightStatus}. Emergence {emergencyInformation}");

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
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine($"Emergence: {emergencyInformation}");
                //Console.ResetColor();
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
            AirportPanel flight1 = new AirportPanel();

            flight1.airline = "One";
            flight1.flightNumber = 245;
            flight1.flightStatus = FlightStatus.checkIn;
            flight1.gate = 3;
            flight1.terminal = 7;
            flight1.emergencyInformation = EmergencyInformation.fire;

            flight1.airportArrival.arrivalCity = "Kyiv";
            flight1.airportArrival.arrivalData = new DateTime(2015, 7, 20, 18, 30, 25);
            flight1.airportArrival.arrivalPort = "Boryspil";

            flight1.airportDeparture.departureCity = "Lviv";
            flight1.airportDeparture.departureData = new DateTime(2015, 7, 21, 03, 17, 43);
            flight1.airportDeparture.departurePort = "Mikolay";

            AirportPanel[] airportPanel = new AirportPanel[] { flight1, flight1 };
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
                                Console.WriteLine("");
                                break;
                            case 2:
                                Console.WriteLine("");
                                break;
                            case 3:
                                //Console.WriteLine("Where do you want to find out about an emergency?");
                                //for (int i = 0; i < airportPanel.Length; i++)
                                //{
                                //    Console.WriteLine($@"        {i + 1}.  Flight: {airportPanel[i].flightNumber}");
                                //}
                                //try
                                //{
                                //    a = (int)uint.Parse(Console.ReadLine());
                                //    Console.WriteLine();
                                //    airportPanel[a - 1].EmerganceInformation();
                                //}
                                //catch
                                //{
                                //    Console.WriteLine("Uncorrect choose");
                                //}
                                break;
                            case 4:
                                Console.WriteLine("");
                                break;
                            case 5:
                                for (int i = 0; i < airportPanel.Length; i++)
                                {
                                    airportPanel[i].InformationOutput();
                                }
                                Console.WriteLine("");
                                break;
                            case 6:
                                Console.WriteLine("Where do you want to find out about an emergency?");
                                for (int i = 0; i < airportPanel.Length; i++)
                                {
                                    Console.WriteLine($@"        {i+1}.  Flight: {airportPanel[i].flightNumber}");
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
