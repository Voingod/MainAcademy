using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace CSharp_Net_module1_7_1_lab
{
    class Program
    {
        static void Main(string[] args)
        {
            // 3) create collection of computers;
            // set path to file and file name
            List<Computer> computers = new List<Computer>();
            Random random = new Random();

            InOutOperation.CurrentPath = @"D:\Projects\Main Academy\Lab 5.1\CSharp_Net_module1_7_1_lab\bin\Debug";
            InOutOperation.CurrentFile = "Computers.txt";

            File.WriteAllText(InOutOperation.CurrentPath + "\\" + InOutOperation.CurrentFile, string.Empty);

            for (int i = 0; i < 5; i++)
            {
                computers.Add
                    (new Computer
                    {
                        Hdd = random.Next(128, 1000),
                        Cores = random.Next(2, 9),
                        Frequency = random.Next(1, 6),
                        Memory = random.Next(2, 33)
                    });
            }
            // 4) save data and read it in the seamplest way (with WriteData() and ReadData() methods)
            for (int i = 0; i < computers.Count; i++)
            {
                InOutOperation.WriteData(computers[i]);
            }

            Console.WriteLine(InOutOperation.ReadData(InOutOperation.CurrentPath + "\\" + InOutOperation.CurrentFile));
            Console.WriteLine("-----------------");
            // 5) save data and read it with WriteZip() and ReadZip() methods
            // Note: create another file for these operations

            InOutOperation.CurrentFile = "ArhComputers.txt";
            File.WriteAllText(InOutOperation.CurrentPath + "\\" + InOutOperation.CurrentFile, string.Empty);
            FileInfo CurrentfileInfo = new FileInfo(InOutOperation.CurrentFile);
            for (int i = 0; i < computers.Count; i++)
            {
                InOutOperation.WriteZip(computers[i], CurrentfileInfo.FullName + ".7z");
            }
            Console.WriteLine(InOutOperation.ReadZip(CurrentfileInfo.FullName + ".7z"));

            // 6) read info about computers asynchronously (from the 1st file)
            // While asynchronous method will be running, Main() method must print ‘*’ 
            // use 
            // collection of Task with info about computers as type to get returned data from method ReadAsync()
            // use property Result of collection of Task to get access to info about computers

            // Note:
            // print all info about computers after reading from files

            Console.WriteLine("---------------");
            var text = InOutOperation.ReadAsync(InOutOperation.CurrentPath + "\\" + InOutOperation.CurrentFile);
            for (int i = 0; i < 5; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            Console.WriteLine(text.Result);
            // ADVANCED:
            // 8) save data to memory stream and from memory to file
            // declare file stream and set it to null
            // call method WriteToMemory() with info about computers as parameter
            // save returned stream to file stream
            InOutOperation.CurrentFile = "memory.txt";
            for (int i = 0; i < computers.Count; i++)
            {
                Console.WriteLine(InOutOperation.WriteToFileFromMemoryStream
                    (InOutOperation.WriteToMemoryStream(computers[i])));
            }
            
            // call method WriteToFileFromMemory() with parameter of file stream
            // open file with saved data and compare it with input info

            Console.ReadKey();
        }
    }
}
