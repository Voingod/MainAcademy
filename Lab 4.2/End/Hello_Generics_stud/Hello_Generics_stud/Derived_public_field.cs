using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
        public sealed class Derived_public_field : Base_public_field<Derived_public_field>
    {
            public Derived_public_field()
        {
            System.Console.WriteLine("      Derived constructor");
        }
    }
}
