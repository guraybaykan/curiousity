using Curiosity.Domain;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Curiosity.Application
{
    public class Mediator : IMediator
    {
        public void Send(string command)
        {
            if (TryGetCommandType(command, out Type commandType))
            {
                Console.WriteLine($"{command} -> {commandType.Name}");
            }
        }


        private bool TryGetCommandType(string command, out Type commandType)
        {
            commandType = null;

            var commandTypes = from t in this.GetType().Assembly.GetTypes()
                               where t.IsAssignableTo(typeof(ICommand)) && t.IsClass && !t.IsAbstract
                               select t;

            foreach (Type type in commandTypes)
            {
                if (type.GetCustomAttributes(typeof(ConsoleCommandAttribute), false)[0] is ConsoleCommandAttribute consoleCommand && Regex.IsMatch(command, consoleCommand.Pattern, RegexOptions.Compiled))
                {
                    commandType = type;
                    return true;
                }
            }

            return false;
        }
    }
}
