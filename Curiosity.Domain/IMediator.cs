namespace Curiosity.Domain
{
    public interface IMediator
    {
        void Send(string command);
    }
}
