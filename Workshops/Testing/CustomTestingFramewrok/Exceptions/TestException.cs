using System;

namespace CustomTestingFramework.Exeptions
{
    public class TestException : Exception
    {
        public const string EXEPTION_MESSAGE = "The test has failed!";
        public TestException()
            : base(EXEPTION_MESSAGE)
        {
        }

        public TestException(string message) 
            : base(message)
        {
        }
    }
}
