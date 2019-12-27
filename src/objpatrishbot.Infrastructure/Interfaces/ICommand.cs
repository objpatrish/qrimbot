using System.Threading.Tasks;

namespace objpatrishbot.Infrastructure
{
    public interface ICommand
    {
        string GetResponse();
        // Also needs an ExecuteAction, potentially more
    }
}