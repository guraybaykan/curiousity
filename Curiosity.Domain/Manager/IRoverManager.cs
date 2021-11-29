using Curiosity.Domain.Model;

namespace Curiosity.Domain.Manager
{
    public interface IRoverManager
    {
        void Move(ref Rover rover);
        void TurnRight(ref Rover rover);
        void TurnLeft(ref Rover rover);
        (int x, int y) PredictMove(Rover rover);
    }
}
