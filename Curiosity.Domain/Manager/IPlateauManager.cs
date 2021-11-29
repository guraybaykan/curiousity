using Curiosity.Domain.Model;

namespace Curiosity.Domain.Manager
{
    public interface IPlateauManager
    {
        void Create(int width, int heigth);
        Plateau Get();
        bool TryPutRover(int x, int y, Directions direction);
        Rover GetLastAddedRover();
        bool IsAnyRoverInLocation(int x, int y);
        bool IsInBoundaries(int x, int y);
    }
}
