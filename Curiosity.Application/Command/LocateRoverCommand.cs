using Curiosity.Domain.Model;
using Curiosity.Domain;

namespace Curiosity.Application.Command
{
    [ConsoleCommand(@"^[0-9]+ [0-9] +[NSEW]$")]
    public class LocateRoverCommand : ICommand
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }
    }
}
