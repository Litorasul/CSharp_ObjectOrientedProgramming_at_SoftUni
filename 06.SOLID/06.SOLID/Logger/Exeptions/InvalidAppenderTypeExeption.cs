using System;

namespace Logger.Exeptions
{
    public class InvalidAppenderTypeExeption : Exception
    {
        private const string exeptionMessage = "Invalid Appender Type!";
        public InvalidAppenderTypeExeption()
            : base(exeptionMessage)
        {
        }

        public InvalidAppenderTypeExeption(string message) 
            : base(message)
        {
        }
    }
}
