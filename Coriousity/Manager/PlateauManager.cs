using Coriousity.Domain.Manager;
using Coriousity.Domain.Model;
using System.Collections.Generic;

namespace Curiosity.Manager
{
    public class PlateauManager : IPlateauManager
    {
        private Plateau _plateou;
        public PlateauManager()
        {

        }

        public void Create(int width, int heigth)
        {
            _plateou = new Plateau
            {
                Width = width,
                Height = heigth,
                Rovers = new List<Rover>()
            };
        }

        public Plateau Get()
        {
            return _plateou;
        }

        public void PutRover(Plateau plateau, int x, int y)
        {

        }
    }
}
