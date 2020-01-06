using System;

namespace Hello_Exception_stud
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Observation titmouse flight ");
            Bird My_Bird = new Bird("Titmouse", 20);

            //1. Create the skeleton code with the  basic exception handling for the menu in the main method 
            char rbk;
            //try - catch
            try
            {
                // 1. begin
                do
                {
                    rbk = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                    //2. Create code for the nested special exception handling in the main method
                    //try - catch - catch - finally
                    try
                    {
                        Random random = new Random();
                        for (int i = 0; i < 10; i++)
                        {
                            My_Bird.NormalSpeed = random.Next(1, 25);
                            My_Bird.FlyAway(incrmnt: random.Next(1, 25));
                        }
                    }
                    catch (BirdFlewAwayException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.WriteLine(e.When);
                        Console.WriteLine(e.Why);
                        Console.ResetColor();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("CLS exception: Message -" + e.Message +
                            " Source -" + e.Source);
                    }
                    finally
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("For the next step...");
                        Console.ResetColor();
                    }
                } while (rbk != ' ');
                Console.WriteLine();
                // 2. begin

                //3. Create the menu for three options in the inner try block  
                //In the second option throw the System.Exception
                // 3. begin

                //4. in case 1 code array overflow exception 
                //in case 2 code throw (new System.Exception("Oh! My system exception..."));
                //in case 3  code the sequentially incrementing of Bird speed until to the exception 

                // 3. end

                // 2. end

                // 1. end
                do
                {
                    Console.WriteLine("Monitoring in Try block ");
                    Console.WriteLine(@"Please, type the number
                               1. array overflow
                               2. throw exception
                               3. user exception");
                    uint i = uint.Parse(Console.ReadLine());
                    switch (i)
                    {
                        case 1:
                            int res = int.MaxValue;
                            checked
                            {
                                My_Bird.flySpeed[My_Bird.flySpeed.Length - 1] = res * res;
                            }
                            Console.WriteLine(My_Bird.flySpeed[My_Bird.flySpeed.Length - 1]);
                            break;
                        case 2:
                            throw (new Exception("Oh! My system exception..."));
                        case 3:
                            do
                            {
                                My_Bird.FlyAway(incrmnt: 1);
                            } while (true);
                        default:
                            break;
                    }
                } while (Console.ReadKey().Key != ConsoleKey.Spacebar);
             }
            catch (Exception mn)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(mn.Message);
                Console.WriteLine(mn.HelpLink);
                Console.ResetColor();
            }

            Console.ReadLine();
        }


    }
}
