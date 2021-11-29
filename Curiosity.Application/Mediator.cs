using Curiosity.Domain;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Curiosity.Application
{
    public class Mediator : IMediator
    {
        private const string ParseMethod = "Parse";
        private const string HandleMethod = "Handle";
        private readonly IServiceProvider _serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void Send(string command)
        {
            if (!TryGetCommandType(command, out Type commandType))
            {
                return;
            }

            var parserInterfaceType = typeof(ICommandParser<>).MakeGenericType(new Type[] { commandType });
            var parser = _serviceProvider.GetService(parserInterfaceType);

            if (parser is null)
            {
                return;
            }

            var commandObj = parserInterfaceType.GetMethod(ParseMethod)?.Invoke(parser, new[] { command });

            if (commandObj is null)
            {
                return;
            }

            var commandHandlerInterfaceType = typeof(ICommandHandler<>).MakeGenericType(new Type[] { commandType });
            var commandHandler = _serviceProvider.GetService(commandHandlerInterfaceType);

            commandHandlerInterfaceType.GetMethod(HandleMethod)?.Invoke(commandHandler, new[] { commandObj });
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


    }
}
