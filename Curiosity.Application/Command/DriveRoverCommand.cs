using Curiosity.Domain;
using Curiosity.Domain.Model;
using System.Collections.Generic;

namespace Curiosity.Application.Command
{
    [ConsoleCommand(@"^[LMR]+$")]
    public class DriveRoverCommand : ICommand
    {
        public IList<Move> Moves { get; set; }
    }
}
