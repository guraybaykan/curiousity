using Curiosity.Domain.Manager;
using Curiosity.Domain;
using Curiosity.Domain.Model;

namespace Curiosity.Application.Command
{
    public class DriveRoverCommandHandler : ICommandHandler<DriveRoverCommand>
    {
        private readonly IPlateauManager _plateauManager;
        private readonly IRoverManager _roverManager;

        public DriveRoverCommandHandler(IPlateauManager plateauManager,
            IRoverManager roverManager)
        {
            _plateauManager = plateauManager;
            _roverManager = roverManager;
        }

        public void Handle(DriveRoverCommand command)
        {
            var rover = _plateauManager.GetLastAddedRover();

            foreach (var move in command.Moves)
            {
                switch (move)
                {
                    case Move.L:
                        _roverManager.TurnLeft(ref rover);
                        break;
                    case Move.R:
                        _roverManager.TurnRight(ref rover);
                        break;
                    case Move.M:
                        var (x, y) = _roverManager.PredictMove(rover);
                        if(!_plateauManager.IsInBoundaries(x, y))
                        {
                            throw new System.Exception("Rover sent to out of boundaries");
                        }
                        if(_plateauManager.IsAnyRoverInLocation(x, y))
                        {
                            throw new System.Exception("Rover crashed to another rover");
                        }
                        _roverManager.Move(ref rover);
                        break;
                }
            }

            System.Console.WriteLine($"{rover.X} {rover.Y} {rover.Direction.ToString()[0]}");

        }
    }
}
