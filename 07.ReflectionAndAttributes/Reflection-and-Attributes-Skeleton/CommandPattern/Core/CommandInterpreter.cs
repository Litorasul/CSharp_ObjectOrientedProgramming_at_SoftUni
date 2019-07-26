using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandPostfix = "Command";
        public string Read(string input)
        {           
            string[] commandInfo = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string commandName = commandInfo[0] + CommandPostfix;
            string[] commandArgs = commandInfo
                .Skip(1)
                .ToArray();

            Assembly assembly = Assembly
                .GetCallingAssembly();

            Type[] types = assembly.GetTypes();

            Type typeToCreate = types
                .FirstOrDefault(t => t.Name == commandName);

            if (typeToCreate == null)
            {
                throw new InvalidOperationException("Invalid Command Type!");
            }

            Object instance = Activator.CreateInstance(typeToCreate);
            ICommand command = (ICommand)instance;

            string result = command.Execute(commandArgs);
            return result;
        }
    }
}
