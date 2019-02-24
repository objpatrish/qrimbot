using System.Threading.Tasks;
using Discord.WebSocket;
using objpatrishbot.MessageHandler.Interface;

namespace objpatrishbot.MessageHandler.Client
{
    class DiscordMessageHandler<TMessage> : IMessageHandler<TMessage>
    {
        public async Task MessageReceived(SocketMessage message)
        {
            if (message.Content.ToUpper().Contains("QRIM"))
            {
                await message.Channel.SendMessageAsync("Epic!");
            }
        }
    }
}
