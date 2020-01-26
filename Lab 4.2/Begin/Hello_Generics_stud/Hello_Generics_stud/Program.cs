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
                                Swap<Derivared_public_field>();
                                break;
                            case 4:
                                Console.WriteLine("Create Derived from static base constructor ...");
                                Derived_static_field field = new Derived_static_field();
                                Console.WriteLine("");
                                break;
                            case 5:
                                Console.WriteLine("Create currying ...");
                                Add();
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

            Console.ReadLine();
        }
        static void Swap<T>() where T : new()
        {
            T puzzle = new T();
            Console.WriteLine(puzzle);
            Console.WriteLine("IN METHOD SWAP");
        }
        static void Add()
        {
            var source = new List<double> { 1.0, 2.4, 34.9, 9.02, 7.0 };
            var result = new List<double>();
            Func<double, double, double> f = (x, y) => x - y;
            var fBnd = f.Bnd()(2.0);
            Console.WriteLine("Source list");
            foreach(var item in source)
            {
                Console.WriteLine(item);
                result.Add(fBnd(item));
            }
            Console.WriteLine();
            Console.WriteLine("Result list");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

    }
    public static class Curr_list
    {
        public static Func <TArg2, Func<TArg1, TResult>> Bnd<TArg1,TArg2,TResult>(this Func<TArg1,TArg2,TResult> f)
        {
            return (y) => ((x) => f(x, y));
        }
    }

    public sealed class Derived : Base<Derived>
    {
        public Derived()
        {
            Console.WriteLine("USE PUBLIC CONSTRUCTUR FROM DERIVED CLASS");
        }
    }
    public class Base<T> where T : new()
    {
        static Base()
        {
            T input = new T();
            Console.WriteLine("USE STATIC CONSTRUCTUR FROM BASE CLASS");
            Console.WriteLine(input);
        }
    }

    public class Base_public_field<T> where T : new()
    {
        private T _instance;
        public T Instance
        {
            get
            {
                Console.WriteLine("Public field");
                _instance = new T();
                return _instance;
            }
        }
        static Base_public_field()
        {
            T input = new T();
            Console.WriteLine("USE STATIC CONSTRUCTUR FROM Base_public_field");
            Console.WriteLine(input);
        }
    }
    public sealed class Derivared_public_field : Base_public_field<Derivared_public_field>
    {
        public Derivared_public_field()
        {
            Console.WriteLine("USE PUBLIC CONSTRUCTUR FROM Derivared_public_field CLASS");
        }
    }

    public class Base_static_field<T> where T : new()
    {
        static private T field;
        static public T Field
        {
            get
            {
                field = new T();
                return field;
            }
        }
        protected Base_static_field()
        {
            Console.WriteLine("USE PROTECTED CONSTRUCTUR FROM Base_static_field CLASS");
        }
    }
    public sealed class Derived_static_field : Base_static_field<Derived_static_field>
    {
        public Derived_static_field()
        {
            Console.WriteLine("USE PUBLIC CONSTRUCTUR FROM Derived_static_field CLASS");
        }
    }

    public class Base_publ<T> where T : new()
    {
        private T _instance;
        public T Instance
        {
            get
            {
                Console.WriteLine("Public field");
                _instance = new T();
                return _instance;
            }
        }
        static Base_publ()
        {
            T item = new T();
            Console.WriteLine("USE STATIC CONSTRUCTUR FROM Base_publ CLASS");
        }
    }
    public sealed class Derived_publ: Base_publ<Derived_publ>
    {
        public Derived_publ()
        {
            Console.WriteLine("USE PUBLIC CONSTRUCTUR FROM Derived_publ CLASS");
        }
    }

}

