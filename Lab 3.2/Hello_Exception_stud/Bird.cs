using System;

namespace  Hello_Exception_stud
{
    //Create the Bird class with the fields, properties, constructors and the method
    //The public void FlyAway( int incrmnt ) method generates custom exception 
    class Bird
    {

        //Create fields and properties
        public int[] flySpeed = { 5, 15, 25, 35 };
        public int NormalSpeed { get; set; }
        public string Nick { get; set; }
        private bool birdFlewAway;
        //Create constructors
        public Bird() { }
        public Bird(string name, int speed)
        {
            NormalSpeed = speed;
            Nick = name;
        }
        //Implement Method public void FlyAway( int incrmnt ) which check Bird state by reading field  BirdFlewAway
        // check BirdFlewAway
        // if true 

        // write the message to console
        // else

        // increment the Bird speed by method argument
        // check the condition (NormalSpeed >= FlySpeed[3]) 
        // If it's true 

        // BirdFlewAway = true and we generate custom exception    BirdFlewAwayException(string.Format("{0} flew with incredible speed!", Nick), "Oh! Startle.", DateTime.Now)
        // with HelpLink = "http://en.wikipedia.org/wiki/Tufted_titmouse" else  console.writeline about Bird speed 
        public void FlyAway(int incrmnt)
        {
            if (birdFlewAway)
            {
                Console.WriteLine("Yes, bird is flying");
                birdFlewAway = false;
            }
            else
            {
                NormalSpeed += incrmnt;
                if (NormalSpeed >= flySpeed[3])
                {
                    birdFlewAway = true;
                    BirdFlewAwayException birdException = new BirdFlewAwayException(string.Format("{0} flew with incredible speed!", Nick), "Oh! Startle.", DateTime.Now);
                    birdException.HelpLink = "http://en.wikipedia.org/wiki/Tufted_titmouse";
                    throw (birdException);
                }
                else
                {
                    Console.WriteLine($"Speed is {NormalSpeed}");
                }
            }
        }
    }
}
