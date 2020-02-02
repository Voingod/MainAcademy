namespace Airport
{
    enum FlightStatus
    {
        checkIn, gateClosed, arrived, departedAt, unknown, canceled, expectedAt, delayed, inFlight
    }
    enum EmergencyInformation
    {
        evacuation, fire, unknown, flooding, earthquake
    }
    enum ParamForSearch
    {
        flightNumber = 1, dataTimeOfarrival, arrivalPort, departurePort, nearestFlightArrived, nearestFlightDeparture
    }
    enum ParamMenu
    {
        createNewFlight = 1, deleteFlight, updateFlightsInformation, searchInformation, outputSchedule, 
        outputEmergencyInformation, outputPrice
    }
    enum ParamUpdate
    {
         NumberOfGate = 1,  FlightNumber,  Airline,  Terminal,  FlightStatus,  EmergencyInformation,
         DateOfArrive,  ArrivalCity,  ArrivalPort,  DateOfDeparture,  DepartureCity,  DeparturePort
    }
    enum AirlineClass
    {
        econom, bussines
    }
}