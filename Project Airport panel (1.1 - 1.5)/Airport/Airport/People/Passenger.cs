using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    class Passenger : Human
    {
        public Passenger(IPrinter<Human> getSetInfoIn) : base(getSetInfoIn)
        {
            Testing();
        }
        #region TestEvent
        public delegate void Test(int a);
        public event Test ETest;
        public Test test;

        public void Testing()
        {
            test += Passenger_ETest;
            ETest += Passenger_ETest;
        }
        public void UseETest()
        {
            ETest?.Invoke(1);
        }
        private void Passenger_ETest(int a)
        {
            Console.WriteLine("Im HERE");
        }
        #endregion
        //public int FlightNumber { get; set; }

        public string TypeOfClass { get; set; }

    }
}
