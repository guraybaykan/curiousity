using Curiosity.Domain.Manager;
using Curiosity.Application;
using Curiosity.Application.Command;
using Curiosity.Domain;
using Curiosity.Manager;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Curiosity
{
    static class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var serviceProvider = AddDI();
                var mediator = serviceProvider.GetRequiredService<IMediator>();

                using StreamReader streamReader = new(args[0]);

                while (streamReader.ReadLine() is string command)
                {
                    mediator.Send(command);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine( $"An error occured: {ex.Message}");
            }

        }

        static ServiceProvider AddDI()
        {
            return new ServiceCollection()
            .AddSingleton<IPlateauManager, PlateauManager>()
            .AddSingleton<IRoverManager, RoverManager>()
            .AddSingleton<IMediator, Mediator>()
            .AddSingleton<ICommandParser<CreateLandingAreaCommand>, CreateLandingAreaCommandParser>()
            .AddSingleton<ICommandParser<DriveRoverCommand>, DriveRoverCommandParser>()
            .AddSingleton<ICommandParser<LocateRoverCommand>, LocateRoverCommandParser>()
            .AddSingleton<ICommandHandler<CreateLandingAreaCommand>, CreateLandingAreaCommandHandler>()
            .AddSingleton<ICommandHandler<DriveRoverCommand>, DriveRoverCommandHandler>()
            .AddSingleton<ICommandHandler<LocateRoverCommand>, LocateRoverCommandHandler>()
            .BuildServiceProvider();
        }
    }
}
