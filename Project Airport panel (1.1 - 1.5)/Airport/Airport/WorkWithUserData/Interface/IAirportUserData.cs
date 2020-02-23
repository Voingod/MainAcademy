using System.Collections.Generic;

namespace Airport
{
    interface IAirportUserData
    {
        void PrintEmerganceInformation(AirportPanel airport);
        void Print(AirportPanel airport);
        void PrintPrice(List<AirportPanel> airport);

    }

}
