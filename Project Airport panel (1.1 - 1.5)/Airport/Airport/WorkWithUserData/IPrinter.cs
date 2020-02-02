namespace Airport
{
    interface IPrinter<T>: IEnteredValue
    {
        void Print(T airport);
        void PrintEmerganceInformation(T airport);
        void PrintPrice <T>(T airport);
        void Print(string info);
        void PrintUserUncorrectInput(string info);

    }
    interface IEnteredValue
    {
        string EnteredValueByUser();
    }


}
