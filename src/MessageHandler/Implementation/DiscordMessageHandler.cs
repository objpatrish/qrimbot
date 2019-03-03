using System.Threading.Tasks;
using Discord.WebSocket;
using objpatrishbot.ImageHandler.Factory;
using objpatrishbot.ImageHandler.Implementations;
using objpatrishbot.MessageHandler.Interface;


namespace objpatrishbot.MessageHandler.Implementation
{
    class DiscordMessageHandler<TMessage> : IMessageHandler<TMessage>
    {
        public async Task MessageReceived(SocketMessage message)
        {
            if (message.Content.ToUpper().Contains("QRIM"))
            {
                var imageProvider = ImageHandlerFactory.Create("");
                await imageProvider.SendImage("qrim", message.Channel.Name, message.Content.ToUpper().Contains("SAD"));
            }
        }
    }
}
