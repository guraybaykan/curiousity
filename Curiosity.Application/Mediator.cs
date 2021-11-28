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
            if (!TryGetCommandType(command, out Type commandType))
            {
                return;
            }

            var parserType = GetProviderOfCommandType(typeof(ICommandParser<>), commandType);

            if (parserType is null)
            {
                return;
            }

            var parser = Activator.CreateInstance(parserType);

            var commandObj = parserType.GetMethod("Parse")?.Invoke(parser, new[] { command });

            if (commandObj is null)
            {
                return;
            }

            var commandHandlerType = GetProviderOfCommandType(typeof(ICommandHandler<>), commandType);

            if (commandHandlerType is null)
            {
                return;
            }

            var commandHandler = Activator.CreateInstance(commandHandlerType);

            commandHandlerType.GetMethod("Handle")?.Invoke(commandHandler, new[] { commandObj });
        }


        private bool TryGetCommandType(string command, out Type commandType)
        {
            commandType = null;

            var commandTypes = from t in this.GetType().Assembly.GetTypes()
                               where t.IsAssignableTo(typeof(ICommand)) && t.IsClass && !t.IsAbstract
                               select t;

            foreach (Type type in commandTypes)
            {
                var consoleCommands = type.GetCustomAttributes(typeof(ConsoleCommandAttribute), false);
                if (consoleCommands.Any() && consoleCommands[0] is ConsoleCommandAttribute consoleCommand && Regex.IsMatch(command, consoleCommand.Pattern, RegexOptions.Compiled))
                {
                    commandType = type;
                    return true;
                }
            }

            return false;
        }

        private Type GetProviderOfCommandType(Type providerType, Type commandType)
        {
            return (from t in this.GetType().Assembly.GetTypes()
                    where t.IsAssignableTo(providerType.MakeGenericType(new Type[] { commandType }))
                    select t).FirstOrDefault();
        }
    }
}
