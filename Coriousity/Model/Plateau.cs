﻿using System.Collections.Generic;

namespace Coriousity.Model
{
    public class Plateau
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public IList<Rover> Rovers { get; set; }
    }
}