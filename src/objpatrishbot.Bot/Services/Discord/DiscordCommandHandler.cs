using System.Threading.Tasks;
using objpatrishbot.Commands;
using objpatrishbot.Infrastructure;

namespace objpatrishbot.Bot
{
    public class DiscordCommandHandler : ICommandHandler<DiscordCommand>
    {
        public Task LoadCommands()
        {
            throw new System.NotImplementedException();
        }
        public Task<string> CheckMessageForCommands()
        {
            throw new System.NotImplementedException();
        }
    }
}