using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using objpatrishbot.MessageHandler.Client;
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
