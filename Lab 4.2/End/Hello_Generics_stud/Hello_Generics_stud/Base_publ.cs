using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{ 
    public class Base_publ<T> where T : new()
    {

        protected Base_publ() 
        {
            System.Console.WriteLine("  Base  protected constructor");
            T intern = new T();
        }
    }
}
