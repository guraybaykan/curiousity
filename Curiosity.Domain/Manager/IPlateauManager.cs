using Coriousity.Domain.Model;

namespace Coriousity.Domain.Manager
{
    public interface IPlateauManager
    {
        void Create(int width, int heigth);
        Plateau Get();
        void PutRover(Plateau plateau, int x, int y);
    }
}
