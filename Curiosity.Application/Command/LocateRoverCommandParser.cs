using Curiosity.Domain.Model;
using Curiosity.Domain;
using System;

namespace Curiosity.Application.Command
{
    public class LocateRoverCommandParser : ICommandParser<LocateRoverCommand>
    {
        public LocateRoverCommand Parse(string command)
        {
            return new LocateRoverCommand
            {
                X = Convert.ToInt32(command.Split(' ')[0]),
                Y = Convert.ToInt32(command.Split(' ')[1]),
                Direction = command.Split(' ')[2] switch
                {
                    "N" => Directions.North,
                    "E" => Directions.East,
                    "S" => Directions.South,
                    "W" => Directions.West,
                    _ => throw new Exception("Bad Direction Input")
                }
            };
        }
    }
}
