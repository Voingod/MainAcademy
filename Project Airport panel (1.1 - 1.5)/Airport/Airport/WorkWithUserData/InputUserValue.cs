using System;
using System.Collections.Generic;

namespace Airport
{
    abstract class InputUserValue<T>
    {
        public InputUserValue(IPrinter<T> workWithUserData)
        {
            InputUserValue<T>.workWithUserData = workWithUserData;
        }
        protected static IPrinter<T> workWithUserData;
        public static void EnteredValueByUser(out int param)
        {
            if (!int.TryParse(workWithUserData.EnteredValueByUser(), out param))
                workWithUserData.PrintUserUncorrectInput($"Uncorrect entered parameter");
        }
        public static void EnteredValueByUser(out DateTime param)
        {
            if (!DateTime.TryParse(workWithUserData.EnteredValueByUser(), out param))
                workWithUserData.PrintUserUncorrectInput($"Uncorrect entered parameter");
        }
        public static void EnteredValueByUser(out TimeSpan param)
        {
            if (!TimeSpan.TryParse(workWithUserData.EnteredValueByUser(), out param))
                workWithUserData.PrintUserUncorrectInput($"Uncorrect entered parameter");
        }

    }



}
