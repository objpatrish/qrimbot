using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace objpatrishbot.MessageHandler.Interface
{
    interface IMessageHandler <TMessage>
    {
        Task MessageReceived(SocketMessage message);
    }
}
