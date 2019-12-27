using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using objpatrishbot.Commands;
using objpatrishbot.Infrastructure;
using objpatrishbot.Infrastructure.Interfaces;

namespace objpatrishbot.Bot.Services.Discord
{
    class DiscordMessageHandler<TMessage> : IMessageHandler<SocketMessage>
    {
        private ILogger<DiscordMessageHandler<TMessage>> _logger;
        private IImageHandler _imageHandler;
        private ICommandHandler<DiscordCommand> _commandHandler;

        public DiscordMessageHandler(
            ILogger<DiscordMessageHandler<TMessage>> logger, IImageHandler imagehandler,
            ICommandHandler<DiscordCommand> commandHandler)
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
            {
                var reply = await _commandHandler.CheckMessageForCommands();
                // Pass to SendMessage, both of these methods need params but I need to find out which
            }
            else
            {
                // pass to some other service/handler which checks for regex etc.
            }

        }

        public Task SendMessage()
        {
            throw new System.NotImplementedException();
        }
    }
}
