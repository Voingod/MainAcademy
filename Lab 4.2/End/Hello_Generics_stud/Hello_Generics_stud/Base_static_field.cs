using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    public class Base_static_field<T> where T : new()
    {
       private static T _instance;
       public static  T Instance
        {
            get
            {              
                Console.WriteLine("Static field");
                _instance = new T();
                return _instance;
            }
        }
        protected Base_static_field()
        {
            System.Console.WriteLine("  Base protected constructor without new()");
        }

    }
}
