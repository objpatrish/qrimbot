using System.Reflection;
using System.Threading.Tasks;
using Discord.WebSocket;
using objpatrishbot.Commands.Attributes;
using objpatrishbot.Infrastructure.Discord;

namespace objpatrishbot.Commands
{
    [DiscordCommand("Mute", "mute")]
    public class Mute : IDiscordCommand
    {
        public Task ExecutionAction(SocketMessage message)
        {
            throw new System.NotImplementedException();
        }

        public string GetReply(SocketMessage message)
        {
            return $"Muting user: ...";
        }
    }
}