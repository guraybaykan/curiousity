 Running the application and the results
 
 Curiosity (master) ✗ cd Curiosity
 Curiosity (master) ✗ dotnet run -- Commands.txt
1 3 N
5 1 E

Running tests

The following Tests are available:
    Curiosity.Tests.DomainServices.RoverManagerTest.TurnLeft_ShouldNotMove(x: 3, y: 4, direction: West)
    Curiosity.Tests.DomainServices.RoverManagerTest.TurnRight_ShouldNotMove(x: 3, y: 4, direction: West)
    Curiosity.Tests.DomainServices.RoverManagerTest.Move_DirectionShoultNotChange(x: 3, y: 4, direction: West)
    Curiosity.Tests.DomainServices.RoverManagerTest.Move_ShouldIncreaseY1_WhenDirectionIsNorth
    Curiosity.Tests.DomainServices.RoverManagerTest.Move_ShouldDecreaseY1_WhenDirectionIsSouth
    Curiosity.Tests.ApplicationServices.LocateRoverCommandHandlerTests.WhenThePositionIsOccupiedByAnotherRover_ThrowException

...

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     6, Skipped:     0, Total:     6, Duration: 167 ms  Curiosity.Tests.dll (net5.0)