using System;

namespace Logger.Exeptions
{
    public class InvalidLayoutTypeExeption : Exception
    {
        private const string exeptionMessage = "Invalid Layout Type!";

        public InvalidLayoutTypeExeption()
            : base(exeptionMessage)
        {
        }

        public InvalidLayoutTypeExeption(string message) : base(message)
        {
        }
    }
}
