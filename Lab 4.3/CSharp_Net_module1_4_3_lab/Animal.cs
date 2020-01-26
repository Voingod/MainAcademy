using System;
using System.Collections;

namespace CSharp_Net_module1_4_3_lab
{
    // 12) change methods of sorting to properties

    // 1) implement interface IComparable
    public class Animal : IComparable
    {
        // 2) declare properties and parameter constructor
        public string Genus { get; set; }
        public int Weight { get; set; }

        // 3) implement method ComareTo()
        // it comares Genus of type string - return result of method String.Compare 
        // for this.genus and argument object
        // don't forget to cast object to Animal
        public int CompareTo(object obj)
        {
            if (obj is Animal animal)
                return this.Genus.CompareTo(animal.Genus);
            else
                throw new Exception("Not Animal");
        }

        // 4) declare methods SortWeightAscending(), SortGenusDescending()
        // they are static and return IComparer
        // return type is custed from constructor of classes SortWeightAscendingHelper, 
        // SortGenusDescendingHelper calling 
        public static IComparer SortWeightAscending()
        {
            return new SortWeightAscendingHelper();
        }
        public static IComparer SortGenusDescending()
        {
            return new SortGenusDescendingHelper();
        }
        // 5) declare 2 nested private classes SortWeightAscendingHelper, SortGenusDescendingHelper 
        // they implement interface IComparer
        // every nested class has implemented method Comare with 2 parameters of object and return int
        // class SortWeightAscendingHelper sort weight by ascending
        // class SortGenusDescendingHelper sort genus by descending
        private class SortWeightAscendingHelper : IComparer
        {
            
            public int Compare(object x, object y)
            {
                if (x is Animal animal1 && y is Animal animal2)
                {
                    return animal1.Weight.CompareTo(animal2.Weight);
                }
                else
                    throw new ArgumentException("Not animal");
            }
        }
        private class SortGenusDescendingHelper : IComparer
        {
            public int Compare(object x, object y)
            {
                if (x is Animal animal1 && y is Animal animal2)
                {
                    return String.Compare(animal2.Genus , animal1.Genus);
                }
                else
                    throw new ArgumentException("Not animal");
            }
        }

    }
}
