using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Airport
{
    abstract class EnterUserData
    {
        public static ICommonUserData commonUserData;
        private static readonly Enum unknownStatus = FlightStatus.unknown;
        public EnterUserData(ICommonUserData commonUserData)
        {
            EnterUserData.commonUserData = commonUserData;
        }

        public static void EnteredValueByUser<T>(out T param)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                if (converter != null)
                {
                    param = (T)converter.ConvertFromString(commonUserData.EnteredValueByUser());
                    return;
                }
                param = default;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.InnerException); 
                commonUserData.PrintUserUncorrectInput("Uncorrect entered parameter");
                param = default;
            }
        }

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
