using Curiosity.Manager;
using Curiosity.Domain.Model;
using Xunit;

namespace Curiosity.Tests.DomainServices
{
    public class RoverManagerTest
    {
        private RoverManager _roverManager;
        public RoverManagerTest()
        {
            _roverManager = new RoverManager();
        }   


        [Theory]
        [InlineData(3, 4, Directions.West)]
        public void TurnLeft_ShouldNotMove(int x, int y, Directions direction)
        {
            var rover = new Rover
            {
                X = x,
                Y = y,
                Direction = direction
            };

            _roverManager.TurnLeft(ref rover);
            Assert.Equal(rover.X, x);
            Assert.Equal(rover.Y, y);
        }

        [Theory]
        [InlineData(3, 4, Directions.West)]
        public void TurnRight_ShouldNotMove(int x, int y, Directions direction)
        {
            var rover = new Rover
            {
                X = x,
                Y = y,
                Direction = direction
            };

            _roverManager.TurnRight(ref rover);
            Assert.Equal(rover.X, x);
            Assert.Equal(rover.Y, y);
        }


        [Theory]
        [InlineData(3, 4, Directions.West)]
        public void Move_DirectionShoultNotChange(int x, int y, Directions direction)
        {
            var rover = new Rover
            {
                X = x,
                Y = y,
                Direction = direction
            };

            _roverManager.Move(ref rover);
            Assert.Equal(rover.Direction, direction);
        }

        
        [Fact]
        public void Move_ShouldIncreaseY1_WhenDirectionIsNorth()
        {
            int y = 4;
            var rover = new Rover
            {
                X = 3,
                Y = y,
                Direction = Directions.North
            };
            _roverManager.Move(ref rover);
            Assert.Equal(rover.Y, y + 1);
        }

        [Fact]
        public void Move_ShouldDecreaseY1_WhenDirectionIsSouth()
        {
            int y = 4;
            var rover = new Rover
            {
                X = 3,
                Y = y,
                Direction = Directions.South
            };
            _roverManager.Move(ref rover);
            Assert.Equal(rover.Y, y - 1);
        }

    }
}