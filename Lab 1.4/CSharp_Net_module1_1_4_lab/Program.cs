using System;

namespace CSharp_Net_module1_1_4_lab
{
    class Program
    {
        // 1) declare enum ComputerType
        enum ComputerType
        {
            Desktop,
            Laptop,
            Server
        }

        // 2) declare struct Computer
        struct Computer
        {
            public byte CPUcore;
            public double CPUfrequency;
            public byte memory;
            public short HDD;
            public ComputerType computerType;

            public void DescribeComputer()
            {
                Console.WriteLine($"{computerType}: CPU - {CPUcore} cores, " +
                    $"{CPUfrequency} HGz, memory - {memory} GB, " +
                    $"HDD - {HDD} GB");
            }

        }

        static void Main(string[] args)
        {
            Computer desktop = new Computer
            {
                computerType = ComputerType.Desktop,
                CPUcore = 4,
                CPUfrequency = 2.5,
                memory = 6,
                HDD = 500
            };
            Computer server = new Computer
            {
                computerType = ComputerType.Server,
                CPUcore = 8,
                CPUfrequency = 3,
                memory = 16,
                HDD = 2000
            };
            Computer laptop = new Computer
            {
                computerType = ComputerType.Laptop,
                CPUcore = 2,
                CPUfrequency = 1.7,
                memory = 4,
                HDD = 250,
            };

            // 3) declare jagged array of computers size 4 (4 departments)
            Computer[][] departments = new Computer[4][];
            // 4) set the size of every array in jagged array (number of computers)
            departments[0] = new Computer[5];
            departments[1] = new Computer[3];
            departments[2] = new Computer[5];
            departments[3] = new Computer[4];

            // 5) initialize array
            // Note: use loops and if-else statements
            for(int i = 0; i < departments.Length; i++)
            {
                for(int j = 0; j < departments[i].Length; j++)
                {
                    switch(i)
                    {
                        case 0:
                            {
                                departments[i][j] = (j < 2) ? desktop : 
                                    (j >= 2 && j < 4) ? laptop : server;
                                break;

                            }
                        case 1:
                            {
                                departments[i][j] =  laptop;
                                break;
                            }
                        case 2:
                            {
                                departments[i][j] = (j < 3) ? desktop : laptop;
                                break;
                            }
                        case 3:
                            {
                                departments[i][j] = (j < 1) ? desktop :
                                    (j >= 1 && j < 2) ? laptop : server;
                                break;
                            }
                    }
                    
                }
            }
            foreach(var department in departments)
            {
                foreach (var computer in department)
                {
                    computer.DescribeComputer();
                }
                Console.WriteLine();
            }
            
            int allComputersCount = 0;
            int desktopCount = 0;
            int laptopCount = 0;
            int serverCount =0 ;
            // 6) count total number of every type of computers

            for (int i = 0; i < departments.Length; i++)
            {
                for (int j = 0; j < departments[i].Length; j++)
                {
                    if (departments[i][j].computerType == ComputerType.Desktop)
                    {
                        desktopCount += 1;
                    }
                    if (departments[i][j].computerType == ComputerType.Laptop)
                    {
                        laptopCount += 1;
                    }
                    if (departments[i][j].computerType == ComputerType.Server)
                    {
                        serverCount += 1;
                    }
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Number of Desktop: {desktopCount}");
            Console.WriteLine($"Number of Laptop: {laptopCount}");
            Console.WriteLine($"Number of Server: {serverCount}");
            // 7) count total number of all computers
            // Note: use loops and if-else statements
            // Note: use the same loop for 6) and 7)

            for (int i = 0; i < departments.Length; i++)
            {
                allComputersCount += departments[i].Length;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Number of all computers: {allComputersCount}");

            // 8) find computer with the largest storage (HDD) - 
            // compare HHD of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements

            ComputerType largestStorage;

            if (desktop.HDD >= laptop.HDD)
            {
                if (desktop.HDD > server.HDD)
                {
                    largestStorage = desktop.computerType;
                }
                else
                {
                    largestStorage = server.computerType;
                }
                
            }
            else
            {
                if (laptop.HDD > server.HDD)
                {
                    largestStorage = laptop.computerType;
                }
                else
                {
                    largestStorage = server.computerType;
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Computer with the largest storage (HDD): {largestStorage}");

            // 9) find computer with the lowest productivity (CPU and memory) - 
            // compare CPU and memory of every computer between each other; 
            // find position of this computer in array (indexes)
            // Note: use loops and if-else statements
            // Note: use logical oerators in statement conditions

            ComputerType lowestProductivity;
            if ((desktop.CPUfrequency <= laptop.CPUfrequency)
                && (desktop.memory <= laptop.memory))
            {
                if ((desktop.CPUfrequency < server.CPUfrequency)
                    && (desktop.memory < server.memory)) 
                {
                    lowestProductivity = desktop.computerType;
                }
                else
                {
                    lowestProductivity = server.computerType;
                }
            }
            else
            {
                if ((laptop.CPUfrequency < server.CPUfrequency)
                    && (laptop.memory < server.memory))
                {
                    lowestProductivity = laptop.computerType;
                }
                else
                {
                    lowestProductivity = server.computerType;
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Computer with the lowest productivity (CPU and memory): {lowestProductivity}");

            // 10) make desktop upgrade: change memory up to 8
            // change value of memory to 8 for every desktop. Don't do it for other computers
            // Note: use loops and if-else statements
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < departments.Length; i++)
            {
                for (int j = 0; j < departments[i].Length; j++)
                {
                    if (departments[i][j].computerType == ComputerType.Desktop)
                    {
                        departments[i][j].memory = 8;
                    }
                }
            }
            Console.WriteLine();
            foreach (var department in departments)
            {
                foreach (var computer in department)
                {

                    computer.DescribeComputer();
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
 
    }



}
