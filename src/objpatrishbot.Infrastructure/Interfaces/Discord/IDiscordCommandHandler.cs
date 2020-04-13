using System.Threading.Tasks;
using Discord.WebSocket;

namespace objpatrishbot.Infrastructure.Discord
{
    public interface IDiscordCommandHandler
    {
        Task<bool> HandleMessageAsync(SocketMessage message, int prefixIndex);
    }
}