using System.Threading.Tasks;

namespace objpatrishbot.Commands
{
    public interface ICommand
    {
        string GetResponse();
    }
}