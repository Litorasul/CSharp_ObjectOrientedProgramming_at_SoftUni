using Logger.Factories;
using Logger.Models.Contracts;
using System;
using System.Linq;

namespace Logger.Core
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        private Engine()
        {
            errorFactory = new ErrorFactory();
        }

        public Engine(ILogger logger)
            : this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] errorInfo = command
                    .Split("|")
                    .ToArray();

                string level = errorInfo[0];
                string date = errorInfo[1];
                string message = errorInfo[2];

                IError error;
                try
                {
                    error = this.errorFactory.GetError(date, level, message);
                    this.logger.Log(error);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);                    
                }               
            }
            Console.WriteLine(this.logger.ToString());
        }
    }
}
