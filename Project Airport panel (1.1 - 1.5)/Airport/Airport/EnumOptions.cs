namespace Airport
{
    enum FlightStatus
    {
        checkIn, gateClosed, arrived, departedAt, unknown, canceled, expectedAt, delayed, inFlight
    }
    enum EmergencyInformation
    {
        evacuation, fire
    }
    enum ParamForSearch
    {
        flightNumber = 1, dataTimeOfarrival, arrivalPort, departurePort, nearestFlightArrived, nearestFlightDeparture
    }
    enum ParamMenu
    {
        createNewFlight = 1, deleteFlight, updateFlightsInformation, searchInformation, outputSchedule, outputEmergencyInformation
    }
    enum ParamUpdate
    {
        updateNumberOfGate = 1, updateFlightNumber, updateAirline, updateTerminal, updateFlightStatus, updateEmergencyInformation,
        updateDateOfArrive, updateArrivalCity, updateArrivalPort, updateDateOfDeparture, updateDepartureCity, updateDeparturePort
    }
}