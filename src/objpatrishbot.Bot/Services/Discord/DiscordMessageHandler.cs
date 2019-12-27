using System.Threading.Tasks;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using objpatrishbot.Bot.Extensions;
using objpatrishbot.Infrastructure.Interfaces;

namespace objpatrishbot.Bot.Services.Discord
{
    class DiscordMessageHandler<TMessage> : IMessageHandler<SocketMessage>
    {
        private ILogger<DiscordMessageHandler<TMessage>> _logger;
        private IImageHandler _imageHandler;

        public DiscordMessageHandler(
            ILogger<DiscordMessageHandler<TMessage>> logger,
            IImageHandler imagehandler)
        {
            _logger = logger;
            _imageHandler = imagehandler;
        }
        public async Task MessageReceived(SocketMessage message)
        {
            // Filter out SocketSystemMessages which will not need to be checked, for performance
            // Here we will check if the message fires off a bot event or a bot command/action
            if (message.Content.ToUpper().Contains("QRIM"))
            {
                await _imageHandler.SendImage("qrim", message.Channel.Name, message.Content.ToUpper().Contains("SAD"));
            }
        }
    }
}
