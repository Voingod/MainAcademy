using System.Collections.Generic;

namespace Airport
{
    class Airline
    {
        private AirlineClass TypeOfAirlineClass { get; set; }
        private int Price { get; set; }
        public string AirlineName { get; set;}

        public Dictionary<AirlineClass, int> PriceOfAirlineClass { get; set; }
            = new Dictionary<AirlineClass, int>();

        public Airline()
        {
            //PriceOfAirlineClass.Add(TypeOfAirlineClass, Price);
        }
    }
}