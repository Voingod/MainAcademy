using System;
using System.Collections.Generic;

namespace Airport
{
    abstract class EnterUserData
    {
        public EnterUserData(ICommonUserData commonUserData)
        {
            EnterUserData.commonUserData = commonUserData;
        }
        public static ICommonUserData commonUserData;
        public static void EnteredValueByUser(out int param)
        {
            if (!int.TryParse(commonUserData.EnteredValueByUser(), out param))
                commonUserData.PrintUserUncorrectInput($"Uncorrect entered parameter");
        }
        public static void EnteredValueByUser(out DateTime param)
        {
            if (!DateTime.TryParse(commonUserData.EnteredValueByUser(), out param))
                commonUserData.PrintUserUncorrectInput($"Uncorrect entered parameter");
        }
        public static void EnteredValueByUser(out TimeSpan param)
        {
            if (!TimeSpan.TryParse(commonUserData.EnteredValueByUser(), out param))
                commonUserData.PrintUserUncorrectInput($"Uncorrect entered parameter");
        }
        private static readonly Enum unknownStatus = FlightStatus.unknown;
        public static void PrintEnum(Type t)
        {
            int skipUnknownEnter = 0;
            for (int i = 0; i < Enum.GetNames(t).Length; i++)
            {
                if (Enum.GetName(t, i) == unknownStatus.ToString())
                {
                    skipUnknownEnter++;
                    continue;
                }

                commonUserData.Print($@"           {i + 1 - skipUnknownEnter}. {Enum.GetName(t, i)}");
            }
        }
    }
}
