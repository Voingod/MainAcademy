using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Passenger : Human
    {
        public Passenger(IPassengerUserData workWithUserData, ICommonUserData commonUserData) : base(commonUserData)
        {
            Passenger.workWithUserData = workWithUserData;
            HumanToPassenger += LandingPassanger;
        }
        protected static IPassengerUserData workWithUserData;
        #region TestEvent
        public delegate void HumanHowPassenger(AirportPanel airportPanel);
        public event HumanHowPassenger HumanToPassenger;
        public void UseHumanHowPassenger(AirportPanel airportPanel)
        {
            HumanToPassenger?.Invoke(airportPanel);
        }
        #endregion
        public AirlineClass PassangerClass { get; set; }
        public int FlightNumber { get; set; }

        public void LandingPassanger(AirportPanel airportPanel)
        {
            FlightNumber = airportPanel.FlightNumber;
            PassangerClass = SetClass();
        }
        private AirlineClass SetClass()
        {
            commonUserData.Print($"Enter passanger`s class: ");
            PrintEnum(typeof(AirlineClass));
            EnteredValueByUser(out int passangerClass);
            PassangerClass = (AirlineClass)passangerClass - 1;
            return PassangerClass;
        }
        private static Passenger CreatPassenger(string people)
        {
            Passenger passenger = new Passenger(new ConsolePassengerUserData(), new ConsoleCommonUserData());
            passenger.CreatePeople(people);
            passenger.SetClass();

            commonUserData.Print($"Enter fligth for passenger: ");

            for (int i = 0; i < Program.airportPanel.Count; i++)
                commonUserData.Print($@"        {i + 1}.  Flight: {Program.airportPanel[i].FlightNumber}");
            
            EnteredValueByUser(out int flight);
            passenger.FlightNumber = Program.airportPanel[flight - 1].FlightNumber;


            return passenger;
        }
        private static void PrintPassengers(List<Passenger> passengers)
        {
            for (int i = 0; i < passengers.Count; i++)
            {
                workWithUserData.Print(passengers[i]);
            }
        }
        public static void Menu(List<Passenger> passengers)
        {
            do
            {
                Console.WriteLine();
                commonUserData.Print(@"Please,  type the number:
        1.  Create passenger (input all data)
        2.  Output list of passenger

                    ");
                try
                {
                    int.TryParse(commonUserData.EnteredValueByUser(), out int b);
                    ParamMenuPassenger a = (ParamMenuPassenger)b;

                    Console.WriteLine();
                    switch (a)
                    {
                        case ParamMenuPassenger.createPassenger:
                            passengers.Add(CreatPassenger("passanger"));
                            break;

                        case ParamMenuPassenger.outputPassenger:
                            PrintPassengers(passengers);
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

    }

}
