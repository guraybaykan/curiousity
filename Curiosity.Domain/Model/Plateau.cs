using System.Collections.Generic;

namespace Curiosity.Domain.Model
{
    public class Plateau
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Rover> Rovers { get; set; }
    }
}
