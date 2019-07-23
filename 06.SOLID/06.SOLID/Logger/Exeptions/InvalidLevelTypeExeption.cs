using System;

namespace Logger.Exeptions
{
    class InvalidLevelTypeExeption : Exception
    {
        public const string exeptionMessage = "Invalid Level Type!";
        public InvalidLevelTypeExeption()
            : base(exeptionMessage)
        {
        }

        public InvalidLevelTypeExeption(string message) 
            : base(message)
        {
        }
    }
}
