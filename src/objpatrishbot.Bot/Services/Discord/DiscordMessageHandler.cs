using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using objpatrishbot.Commands;
using objpatrishbot.Infrastructure.Discord;
using objpatrishbot.Infrastructure.Interfaces;

namespace objpatrishbot.Bot.Services.Discord
{
    class DiscordMessageHandler<TMessage> : IMessageHandler<SocketMessage>
    {
        private ILogger<DiscordMessageHandler<SocketMessage>> _logger;
        private IImageHandler _imageHandler;
        private IDiscordCommandHandler _commandHandler;

        public DiscordMessageHandler(
            ILogger<DiscordMessageHandler<SocketMessage>> logger, IImageHandler imagehandler,
            IDiscordCommandHandler commandHandler)
        {
            _logger = logger;
            _imageHandler = imagehandler;
            _commandHandler = commandHandler;
        }
        public async Task MessageReceived(SocketMessage messageParam)
        {
            // Filter out system messages
            var message = messageParam as SocketUserMessage;
            if (message == null) return;

            int prefixIndex = 0;
            if (!message.HasStringPrefix("qbot", ref prefixIndex))
                return;

            if (await _commandHandler.HandleMessageAsync(message, prefixIndex))
            {
                _logger.LogInformation("Command triggered successfully.");
                return;
            }
            else
            {
                _logger.LogInformation("Message triggered no commands.");
                return;
                // pass to some other service/handler which checks for regex etc.
            }

        }
    }
}
