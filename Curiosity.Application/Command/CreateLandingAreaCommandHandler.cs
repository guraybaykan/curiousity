using Curiosity.Domain.Manager;
using Curiosity.Domain;

namespace Curiosity.Application.Command
{
    public class CreateLandingAreaCommandHandler : ICommandHandler<CreateLandingAreaCommand>
    {
        private readonly IPlateauManager _plateauManager;

        public CreateLandingAreaCommandHandler(IPlateauManager plateauManager)
        {
            _plateauManager = plateauManager;
        }
        public void Handle(CreateLandingAreaCommand command)
        {
            _plateauManager.Create(command.Width, command.Height);
        }
    }
}
