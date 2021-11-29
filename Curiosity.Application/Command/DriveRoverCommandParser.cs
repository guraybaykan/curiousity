using Curiosity.Domain;
using Curiosity.Domain.Model;
using System;
using System.Linq;

namespace Curiosity.Application.Command
{
    public class DriveRoverCommandParser : ICommandParser<DriveRoverCommand>
    {
        public DriveRoverCommand Parse(string command)
        {
            var moves = command.ToCharArray().Select(x => x switch
            {
                'L' => Move.L,
                'M' => Move.M,
                'R' => Move.R,
                _ => throw new Exception("Wrong Input ")
            });

            return new DriveRoverCommand
            {
                Moves = moves.ToArray()
            };
        }
    }
}
