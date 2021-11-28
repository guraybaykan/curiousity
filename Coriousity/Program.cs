using Coriousity.Domain.Manager;
using Curiosity.Application;
using Curiosity.Domain;
using Curiosity.Manager;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Coriousity
{
    static class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = AddDI();
            var mediator = serviceProvider.GetRequiredService<IMediator>();

            using StreamReader streamReader = new(args[0]);

            while (streamReader.ReadLine() is string command)
            {
                mediator.Send(command);
            }
        }

        static ServiceProvider AddDI()
        {
            return new ServiceCollection()
                 .AddSingleton<IPlateauManager, PlateauManager>()
                 .AddSingleton<IRoverManager, RoverManager>()
                 .AddSingleton<IMediator, Mediator>()
                 .BuildServiceProvider();
        }
    }
}
