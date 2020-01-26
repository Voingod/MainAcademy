using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            try
            {
                do
                {
                    Console.WriteLine(@"Please,  type the number:

                        Generics      Class Derived : Base<Derived>
                        1.  Static base constructor
                        2.  Protected base constructor (StackOverflow !)
                        3.  Static base constructor, public field
                        4.  Protected base constructor, static field

                        Generics      Delegats & List
                        5.  Generic delegates, extension methods, List  
                
                        ");
                    try
                    {                        
                        a = int.Parse(Console.ReadLine());
                        switch (a)
                        {
                            case 1:                             
                                Console.WriteLine("Create Derived from static base constructor ...");
                                Swap<Derived>();
                                break;
                            case 2:
                                Console.WriteLine("Create Derived from static base constructor ...");
                                Swap<Derived_publ>();
                                break;
                            case 3:
                                Console.WriteLine("Create Derived from static base constructor ...");
                                Swap<Derived_public_field>();
                                break;
                            case 4:
                                Console.WriteLine("Create Derived from static base constructor ...");
                                var o = Derived_static_field.Instance;                                  
                                Console.WriteLine("");
                                break;
                            case 5:
                                Console.WriteLine("Create currying ...");
                                Gen_List_Func();
                                Console.WriteLine("");
                                break;
                           
                            default:
                                Console.WriteLine("Exit");
                                break;
                        }

                    }
                    catch (System.Exception e)
                    {
                        Console.WriteLine("Error");
                    }
                    finally
                    {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Press Spacebar to exit; press any key to continue");
                    Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void Swap<T>() where T: new()
        {
            T puzzle = new T();
            Console.WriteLine("");
        }
        #region Gen_List_Func
        static void Gen_List_Func()
        {
            var source = new List<double> { 1.0, 2.4, 34.9, 9.02, 7.0 };
            var result = new List<double>(); 
            Func<double, double, double> f = (x, у) => x - у;

            // Substitute second argument and receive new delegate for one argument by Bnd extension method
            var fBnd = f.Bnd()(2.0);

            Console.WriteLine("Source list");
            foreach ( var item in source )  {
            Console.Write ( "{0} ; ", item );
            result.Add( fBnd(item) );
            }
            Console.WriteLine();
            Console.WriteLine ("Result list");
            foreach ( var item in result )  { Console.Write ( "{0} ; ", item );
                   }
        }
        #endregion
    }
}

