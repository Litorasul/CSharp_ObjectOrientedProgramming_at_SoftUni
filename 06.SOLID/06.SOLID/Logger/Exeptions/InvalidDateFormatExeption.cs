using System;

namespace Logger.Exeptions
{
    public class InvalidDateFormatExeption : Exception
    {
        private const string exeptionMessage = "Invalid Date Format!";
        public InvalidDateFormatExeption()
            : base(exeptionMessage)
        {
        }

        public InvalidDateFormatExeption(string message) 
            : base(message)
        {
        }

        public InvalidDateFormatExeption(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
