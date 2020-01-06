using System;

namespace Hello_Exception_stud
{
    //Create the BirdFlewAwayException class, derived from ApplicationException  with two properties  
    class BirdFlewAwayException : ApplicationException
    { 
        public DateTime When { get; set; }
        public string Why { get; set; }

        //Create constructors
        public BirdFlewAwayException() { }
        public BirdFlewAwayException(string message, string cause, DateTime time)
            :base(message)
        {
            Why = cause;
            When = time;
        }
    }

}
