using System.Collections.Generic;

namespace Airport
{
    class Airline
    {
        public string AirlineName { get; set;}

        public Dictionary<AirlineClass, int> PriceOfAirlineClass { get; set; }
            = new Dictionary<AirlineClass, int>();
    }
}