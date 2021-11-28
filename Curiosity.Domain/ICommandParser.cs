namespace Curiosity.Domain
{
    public interface ICommandParser<out TCommand>
        where TCommand : ICommand
    {
        TCommand Parse(string command);
    }
}
