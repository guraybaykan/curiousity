using Curiosity.Domain;
using System;

namespace Curiosity.Application.Command
{
    public class CreateLandingAreaCommandParser : ICommandParser<CreateLandingAreaCommand>
    {
        public CreateLandingAreaCommand Parse(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new ArgumentException($"'{nameof(command)}' cannot be null or whitespace.", nameof(command));
            }

            return new CreateLandingAreaCommand
            {
                Width = Convert.ToInt32(command.Split(' ')[0]),
                Height = Convert.ToInt32(command.Split(' ')[1]),
            };

        }
    }
}
