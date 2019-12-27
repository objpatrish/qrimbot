using System.Threading.Tasks;

namespace objpatrishbot.Infrastructure
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task LoadCommands();
        Task<string> CheckMessageForCommands();
        
    }
}