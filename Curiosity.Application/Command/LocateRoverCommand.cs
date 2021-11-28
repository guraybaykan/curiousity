using Curiosity.Domain;

namespace Curiosity.Application.Command
{
    [ConsoleCommand(@"^[0-9]+ [0-9] +[NSEW]$")]
    public class LocateRoverCommand : ICommand
    {

    }
}
