using Curiosity.Domain.Manager;
using Curiosity.Domain.Model;

namespace Curiosity.Manager
{
    public class RoverManager : IRoverManager
    {
        public void Move(ref Rover rover)
        {
            (rover.X, rover.Y) = SimulateMovement(rover);
        }

        public (int x, int y) PredictMove(Rover rover)
        {
            return SimulateMovement(rover);
        }

        public void TurnLeft(ref Rover rover)
        {
            rover.Direction = (Directions)((uint)(rover.Direction - 1) % 4);
        }

        public void TurnRight(ref Rover rover)
        {
            rover.Direction = (Directions)((uint)(rover.Direction + 1) % 4);
        }

        private (int x, int y) SimulateMovement(Rover rover)
        {
            return rover.Direction switch
            {
                Directions.North => (rover.X, rover.Y + 1),
                Directions.East => (rover.X + 1, rover.Y),
                Directions.South => (rover.X, rover.Y - 1),
                Directions.West => (rover.X - 1, rover.Y),
                _ => (rover.X, rover.Y),
            };
        }
    }
}
