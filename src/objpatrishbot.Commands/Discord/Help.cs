using System.Reflection;
using System.Threading.Tasks;
using Discord.WebSocket;
using objpatrishbot.Commands;
using objpatrishbot.Commands.Attributes;
using objpatrishbot.Infrastructure.Discord;

namespace objpatrishbot.Discord
{
    [DiscordCommand("Help", "help")]
    public class Help : IDiscordCommand
    {
        public Task ExecutionAction(SocketMessage message)
        {
            System.Console.WriteLine("Testing execute action");
            return Task.CompletedTask;
        }

        public string GetReply(SocketMessage message)
        {
            return "this will be a help command...";
        }
    }
}