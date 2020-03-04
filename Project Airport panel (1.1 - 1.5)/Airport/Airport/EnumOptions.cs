namespace Airport
{
    enum FlightStatus : byte
    {
        checkIn, gateClosed, arrived, departedAt, unknown, canceled, expectedAt, delayed, inFlight
    }
    enum EmergencyInformation : byte
    {
        evacuation, fire, unknown, flooding, earthquake
    }
    enum ParamForSearch : byte
    {
        flightNumber = 1, dataTimeOfarrival, arrivalPort, departurePort, nearestFlightArrived, nearestFlightDeparture, price
    }
    enum ParamMenu : byte
    {
        createNewFlight = 1, deleteFlight, updateFlightsInformation, searchInformation, outputSchedule,
        outputEmergencyInformation, outputPrice
    }
    enum ParamUpdate : byte
    {
        NumberOfGate = 1, FlightNumber, Airline, Terminal, FlightStatus, EmergencyInformation,
        DateOfArrive, ArrivalCity, ArrivalPort, DateOfDeparture, DepartureCity, DeparturePort, Price
    }
    enum AirlineClass : byte
    {
        econom, bussines
    }
    enum ParamMenuPassenger : byte
    {
        createPassenger = 1, outputPassenger, landingHuman, deletePassenger, searchPassenger
    }
    enum ParamHumanForSearch : byte
    {
        FirstNamePassenger = 1, SecondNamePassenger, Nationality, Passport, DateOfBirthday, Sex, Price, FlightNumber
    }
}