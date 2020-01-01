using System.Reflection;
using System.Threading.Tasks;
using Discord.WebSocket;
using objpatrishbot.Commands.Attributes;
using objpatrishbot.Infrastructure.Discord;

namespace objpatrishbot.Commands
{
    [DiscordCommand("Ncount", "ncount")]
    public class NCount : IDiscordCommand
    {
        public Task ExecutionAction(SocketMessage message)
        {
            throw new System.NotImplementedException();
        }

        public string GetReply(SocketMessage message)
        {
            return "access database and return top 5 n-word users";
        }
    }
}