using Curiosity.Domain;
using System;

namespace Curiosity.Application
{
    public class Mediator : IMediator
    {
        public void Send(string command)
        {
            Console.WriteLine(command);
        }
    }
}
