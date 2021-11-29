using Curiosity.Domain.Manager;
using Curiosity.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Curiosity.Manager
{
    public class PlateauManager : IPlateauManager
    {
        private Plateau _plateau;
        public PlateauManager()
        {

        }

        public void Create(int width, int heigth)
        {
            _plateau = new Plateau
            {
                Width = width + 1,
                Height = heigth + 1,
                Rovers = new List<Rover>()
            };
        }

        public Plateau Get()
        {
            return _plateau;
        }

        public Rover GetLastAddedRover()
        {
            return _plateau?.Rovers?.Last();
        }

        public bool IsAnyRoverInLocation(int x, int y)
        {
            return _plateau.Rovers.Any(rover => rover.X == x && rover.Y == y);
        }

        public bool IsInBoundaries(int x, int y)
        {
            return _plateau.Height > y && _plateau.Width > x && x >= 0 && y >= 0;
        }

        public bool TryPutRover(int x, int y, Directions direction)
        {
            if(_plateau is null)
            {
                return false;
            }    

            if (_plateau.Rovers.Any(rover => rover.X == x && rover.Y == y))
            {
                return false;
            }

            _plateau.Rovers.Add(new Rover
            {
                X = x,
                Y = y,
                Direction = direction
            });

            return true;
        }
    }
}
