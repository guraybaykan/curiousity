using Curiosity.Domain.Manager;
using Curiosity.Domain;
using System;

namespace Curiosity.Application.Command
{
    public class LocateRoverCommandHandler : ICommandHandler<LocateRoverCommand>
    {
        private readonly IPlateauManager _plateauManager;

        public LocateRoverCommandHandler(IPlateauManager plateauManager)
        {
            _plateauManager = plateauManager;
        }
        public void Handle(LocateRoverCommand command)
        {
            if(!_plateauManager.TryPutRover(command.X, command.Y, command.Direction))
            {
                throw new Exception("Rover couldn't land to Mars");
            }
        }
    }
}
