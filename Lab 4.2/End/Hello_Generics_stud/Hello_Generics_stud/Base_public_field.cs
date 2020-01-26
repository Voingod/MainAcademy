using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    public class Base_public_field<T> where T : new()
    {
        private T _instance;
        public  T Instance
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
            System.Console.WriteLine("  Base static constructor");
            T intern = new T();
        }

    }
}
