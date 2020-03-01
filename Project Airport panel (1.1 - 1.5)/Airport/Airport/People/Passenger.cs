using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private delegate void HumanHowPassenger(int indexFlightNumber);
        private event HumanHowPassenger HumanToPassenger;
        public void UseHumanHowPassenger(int indexFlightNumber)
        {
            HumanToPassenger?.Invoke(indexFlightNumber);
        }
        private void LandingPassanger(int indexFlightNumber)
        {
            FlightNumber = Collections.airportPanel[indexFlightNumber].FlightNumber;
            PassangerClass = SetClass();
        }
        #endregion
        public AirlineClass PassangerClass { get; set; }
        public int FlightNumber { get; set; }

        private AirlineClass SetClass()
        {
            commonUserData.Print($"Enter passanger`s class: ");
            PrintEnum(typeof(AirlineClass));
            EnteredValueByUser(out int passangerClass);
            PassangerClass = (AirlineClass)passangerClass - 1;
            return PassangerClass;
        }
        public static Passenger LandingHumanToPlane(List<Human> humen)
        {
            commonUserData.Print("Enter passenger for landing: ");
            PrintPassangerName(humen);
            EnteredValueByUser(out int human);
            Passenger passenger = (Passenger)humen[human - 1].Clone();
            SetFlightAndClass(passenger);
            return passenger;
        }
        private static Passenger CreatePassenger(string people)
        {
            Passenger passenger = new Passenger(new ConsolePassengerUserData(), new ConsoleCommonUserData());
            passenger.CreatePeople(people);
            SetFlightAndClass(passenger);

            return passenger;
        }
        private static void SetFlightAndClass(Passenger passenger)
        {
            passenger.SetClass();

            commonUserData.Print($"Enter fligth for passenger: ");

            for (int i = 0; i < Collections.airportPanel.Count; i++)
                commonUserData.Print($@"        {i + 1}.  Flight: {Collections.airportPanel[i].FlightNumber}");

            EnteredValueByUser(out int flight);
            passenger.FlightNumber = Collections.airportPanel[flight - 1].FlightNumber;

        }
        private static void PrintPassengers(List<Passenger> passengers)
        {
            for (int i = 0; i < passengers.Count; i++)
            {
                workWithUserData.Print(passengers[i]);
            }
        }
        private static void PrintPassangerName<T>(List<T> humen) where T : Human
        {
            for (int i = 0; i < humen.Count; i++)
            {
                commonUserData.Print(i + 1 + " " + humen[i].FirstNamePassenger + " " + humen[i].SecondNamePassenger);
            }
        }
        public static new void SearchInformation<T>(List<T> humen) where T: Passenger
        {

        }
        public static new void UpdatePeopleInformation<T>(List<T> passengers) where T : Passenger
        {

        }

        public static void Menu(List<Passenger> passengers, List<Human> humen)
        {
            do
            {
                Console.WriteLine();
                commonUserData.Print(@"Please,  type the number:
        1.  Create passenger (input all data)
        2.  Output list of passenger
        3.  Landing human to plane
        4.  Delete passenger

                    ");
                try
                {
                    int.TryParse(commonUserData.EnteredValueByUser(), out int b);
                    ParamMenuPassenger a = (ParamMenuPassenger)b;

                    Console.WriteLine();
                    switch (a)
                    {
                        case ParamMenuPassenger.createPassenger:
                            passengers.Add(CreatePassenger("passanger"));
                            break;

                        case ParamMenuPassenger.outputPassenger:
                            PrintPassengers(passengers);
                            break;

                        case ParamMenuPassenger.landingHuman:
                            passengers.Add(LandingHumanToPlane(humen));
                            break;

                        case ParamMenuPassenger.deletePassenger:
                            passengers.RemoveAt(DeletePeople(passengers));
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
