using objpatrishbot.MessageHandler.Implementation;
using objpatrishbot.MessageHandler.Interface;

namespace objpatrishbot.MessageHandler.Factory
{
    static class MessageHandlerFactory<TMessage>
    {
        public static IMessageHandler<TMessage> Create()
        {
            return new DiscordMessageHandler<TMessage>();
        }
    }
}
