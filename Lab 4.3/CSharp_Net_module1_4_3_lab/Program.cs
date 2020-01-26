using System;

namespace CSharp_Net_module1_4_3_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 10) Create an array of Animal objects and object of Animals    
            // print animals with foreach operator for object of Animals 
            Animal[] animal =
                {
                new Animal(){Weight=73,Genus="Cow"},
                new Animal(){Weight=37,Genus="Wolf"},
                new Animal(){Weight=41,Genus="Dog"},
                new Animal(){Weight=104,Genus="Elephant"},
                new Animal(){Weight=115,Genus="Antelope"},

                };
            Animals animals = new Animals(animal);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Before sorting");
            Console.ResetColor();
            foreach (var item in animals)
                Console.WriteLine(item);
            Console.WriteLine();
            // 11) Invoke 3 types of sorting 
            // and print results with foreach operator for array of Animal objects  

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("After standard sorting");
            Console.ResetColor();
            Array.Sort(animal);
            foreach (var item in animals)
                Console.WriteLine(item);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("After sorting by genus descending");
            Console.ResetColor();
            Array.Sort(animal, Animal.SortGenusDescending());
            foreach (var item in animals)
                Console.WriteLine(item);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("After weight ascending sorting");
            Console.ResetColor();
            Array.Sort(animal, Animal.SortWeightAscending());
            foreach (var item in animals)
                Console.WriteLine(item);

            Console.ReadLine();
        }
    }
}
