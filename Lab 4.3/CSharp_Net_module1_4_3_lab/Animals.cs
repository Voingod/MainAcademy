using System.Collections;

namespace CSharp_Net_module1_4_3_lab
{
    //6) implement interface IEnumerable
    class Animals : IEnumerable
    {
        // 7) declare private array of Animal
        private Animal[] animals;
        // 8) declare parameter constructor to initialize array   
        public Animals(Animal [] animals)
        {
            this.animals = animals;
        }
        // 9) implement method GetEnumerator(), which returns IEnumerator
        // use foreach on array of Animal
        // and yield return for every animal
        public IEnumerator GetEnumerator()
        {
            foreach (var item in animals)
            {
                yield return item.Genus+" "+item.Weight;
            }   
        }
    }
}
