using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Generics_stud
{
    public static class Curry_list
    {
        // Add an Bnd extension method to delegate f
        public static Func<TArg2, Func<TArgl, TResult>> Bnd<TArgl, TArg2, TResult>(this Func<TArgl, TArg2, TResult> f)
        {
            // Parameter x captured. Work with the one argument y -> to replace it in the outer program with some constant
            return (y) => ((x) => f(x, y));
        }

    }
}
