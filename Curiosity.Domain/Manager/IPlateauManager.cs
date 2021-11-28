using Coriousity.Domain.Model;

namespace Coriousity.Domain.Manager
{
    public interface IPlateauManager
    {
        void GetPlateau(int width, int heigth);
        void PutRover(Plateau plateau, int x, int y);
    }
}
