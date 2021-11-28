using Curiosity.Domain;

namespace Curiosity.Application.Command
{
    [ConsoleCommand(@"^[0-9]+ [0-9]+$")]
    public class CreateLandingAreaCommand : ICommand
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
