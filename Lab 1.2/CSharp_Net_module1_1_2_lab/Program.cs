using System;

namespace CSharp_Net_module1_1_2_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use "Debugging" and "Watch" to study variables and constants

            //1) declare variables of all simple types:
            //bool, char, byte, sbyte, short, ushort, int, uint, long, ulong, decimal, float, double
            // their names should be: 
            //boo, ch, b, sb, sh, ush, i, ui, l, ul, de, fl, d0
            // initialize them with 1, 100, 250.7, 150, 10000, -25, -223, 300, 100000.6, 8, -33.1
            // Check results (types and values). Is possible to do initialization?
            // Fix compilation errors (change values for impossible initialization)
            
            bool boo = true;
            char ch = '\u002A';
            byte b = 250;
            sbyte sb =  123;
            short sh = 10000;
            ushort ush = 25;
            int i = -223;
            uint ui = 300;
            long l = 1000006;
            ulong ul = 8;
            decimal de = -33.1m;
            float fl = 17.7f;
            double d0 =8712.9;

            Console.WriteLine($"first boo: {boo}");
            Console.WriteLine($"first d0: {d0}");

            //2) declare constants of int and double. Try to change their values.
            //We can't change their

            const int ic = 34;
            const double d0c = 99.9;


            //3) declare 2 variables with var. Initialize them 20 and 20.5. Check types. 
            // Try to reinitialize by 20.5 and 20 (change values). What results are there?

            var numberOne = 20;
            var numberTwo = 20.5;

            Console.WriteLine($"twenty: {numberOne.GetType()}"); //System.Int32
            Console.WriteLine($"twentyPointFive: {numberTwo.GetType()}"); //System.Double

            numberOne = (int)20.5; //without explicit conversion we can't change value of 'numberOne'
            numberTwo = 20; //working implicit conversion, but type is double although value is int

            // 4) declare variables of System.Int32 and System.Double.
            // Initialize them by values of i and d0. Is it possible?
            //Yes: 'System.Int32' is a FCL type; 'int' is a primitive data type defined in C# and is mapped to Int32 of FCL type.

            System.Int32 iFCL = i;
            System.Double dFCL = d0;

            if (true)
            {
                // 5) declare variables of int, char, double 
                // with names i, ch, do
                // is it possible?

                #region It is impossible
                /*int i;
                char ch;
                double d0;
                */
                #endregion

                // 6) change values of variables from 1)
                 boo = false;
                 ch = 'Z';
                 b = 17;
                 sb = -10;
                 sh = 9003;
                 ush = 253;
                 i = -23;
                 ui = 54344354;
                 l = -5790568065368;
                 ul = 966545;
                 de = -8989.1m;
                 fl = 12.72122f;
                 d0 = 872.1223;


            }

            // 7)check values of variables from 1). Are they changed? Think, why
                //Yes
            Console.WriteLine($"second boo: {boo}");
            Console.WriteLine($"second d0: {d0}");

            // 8) use implicit/ explicit conversion to convert variables from 1). 
            // Is it possible? 

            #region Output Before
            Console.WriteLine();
            Console.WriteLine("Before");
            Console.WriteLine($"boo: {boo}");
            Console.WriteLine($"ul: {ul}");
            Console.WriteLine($"de: {de}");
            Console.WriteLine($"b: {b}");
            Console.WriteLine($"i: {i}");
            Console.WriteLine($"ch: {ch}");
            Console.WriteLine($"sb: {sb}");
            Console.WriteLine($"sh: {sh}");
            Console.WriteLine($"ush: {ush}");
            Console.WriteLine($"ui: {ui}");
            Console.WriteLine($"l: {l}");
            Console.WriteLine($"fl: {fl}");
            Console.WriteLine($"d0: {d0}");
            #endregion
            // Fix compilation errors (in case of impossible conversion commemt that line).

            // int -> char
            // bool -> short
            // double -> long
            // float -> char 
            // int to char
            // decimal -> double
            // byte -> uint
            // ulong -> sbyte

            #region impossible
            //boo = (short)false;
            //ul = (sbyte)966545;
            //de = (double)-8989.1m;
            //b = (uint)17;
            //i = (char)-23;
            #endregion

            ch = 'Z';
            sb = -10;
            sh = Convert.ToInt16("9003");
            ush = (ushort)253.12;
            ui = (uint)54344354.12;
            l = long.Parse("-5790568065368");
            fl = (char)12.72122f;
            d0 = (long)872.1223;

            #region Output After 1
            Console.WriteLine();
            Console.WriteLine("After 1");
            Console.WriteLine($"boo: {boo}");
            Console.WriteLine($"ul: {ul}");
            Console.WriteLine($"de: {de}");
            Console.WriteLine($"b: {b}");
            Console.WriteLine($"i: {i}");
            Console.WriteLine($"ch: {ch}");
            Console.WriteLine($"sb: {sb}");
            Console.WriteLine($"sh: {sh}");
            Console.WriteLine($"ush: {ush}");
            Console.WriteLine($"ui: {ui}");
            Console.WriteLine($"l: {l}");
            Console.WriteLine($"fl: {fl}");
            Console.WriteLine($"d0: {d0}");
            #endregion


            // 9) and reverse conversion with fixing compilation errors.

            // int <- char
            // bool <- short
            // double <- long
            // float <- char 
            // char to int
            // decimal <- double
            // byte <- uint
            // ulong <- sbyte

            boo = Convert.ToBoolean(1);
            ch = 'Z';
            b = (byte)ui;
            sb = -10;
            sh = Convert.ToInt16(false);
            ush = 253;
            i = '3';
            ui = 54344354;
            l = -5790568065368;
            ul = Convert.ToUInt64(Math.Abs(sb));
            de = Convert.ToDecimal(-8989.1);
            fl = 'z';
            d0 = Convert.ToDouble(85790568065368);

            #region After 2
            Console.WriteLine();
            Console.WriteLine("After 2");
            Console.WriteLine($"boo: {boo}");
            Console.WriteLine($"ul: {ul}");
            Console.WriteLine($"de: {de}");
            Console.WriteLine($"b: {b}");
            Console.WriteLine($"i: {i}");
            Console.WriteLine($"ch: {ch}");
            Console.WriteLine($"sb: {sb}");
            Console.WriteLine($"sh: {sh}");
            Console.WriteLine($"ush: {ush}");
            Console.WriteLine($"ui: {ui}");
            Console.WriteLine($"l: {l}");
            Console.WriteLine($"fl: {fl}");
            Console.WriteLine($"d0: {d0}");
            #endregion

            // 10) declare int nullable value. Initialize it with 'null'. 
            // Try to initialize variable i with 'null'. Is it possible?

            //No, it is impossible
            //int ni;
            //ni = null;

            int? ni;
            ni = null;
            Console.ReadLine();
        }
    }
}
