using System.Threading.Tasks;

namespace objpatrishbot.Commands
{
    public interface ICommand
    {
        Task<string> GetResponse();
    }
}