using System.Threading.Tasks;
using Discord.WebSocket;

namespace objpatrishbot.Infrastructure.Discord
{
    public interface IDiscordCommand
    {
        string GetReply(SocketMessage message);
        Task ExecutionAction(SocketMessage message);
    }
}