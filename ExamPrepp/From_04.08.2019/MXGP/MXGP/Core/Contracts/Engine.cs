using MXGP.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Core.Contracts
{
    public class Engine :  IEngine
    {
        public ChampionshipController controller { get; }
        public ConsoleReader reader { get; }
        public ConsoleWriter writer { get;  }

        public Engine()
        {
            this.controller = new ChampionshipController();
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }
        public void Run()
        {
            while (true)
            {
                string[] commandInfo = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandInfo[0];
                string result = string.Empty;
                try
                {

                    switch (command)
                    {
                        case "CreateRider":
                            {
                                result = this.controller.CreateRider(commandInfo[1]);
                            }
                            break;
                        case "CreateMotorcycle":
                            {
                                result = this.controller
                                    .CreateMotorcycle(commandInfo[1], commandInfo[2], int.Parse(commandInfo[3]));
                            }
                            break;
                        case "AddMotorcycleToRider":
                            {
                                result = this.controller
                                    .AddMotorcycleToRider(commandInfo[1], commandInfo[2]);
                            }
                            break;
                        case "AddRiderToRace":
                            {
                                result = this.controller
                                    .AddRiderToRace(commandInfo[1], commandInfo[2]);
                            }
                            break;
                        case "CreateRace":
                            {
                                result = this.controller
                                    .CreateRace(commandInfo[1], int.Parse(commandInfo[2]));
                            }
                            break;
                        case "StartRace":
                            {
                                result = this.controller
                                    .StartRace(commandInfo[1]);
                            }
                            break;
                        case "End":
                            {
                                this.controller.End();
                            }
                            break;

                        default:
                            break;
                    }

                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {

                    writer.WriteLine(ex.Message);
                }
            }

        }
    }
}
