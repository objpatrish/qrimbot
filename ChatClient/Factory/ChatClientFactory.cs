using System;
using System.Collections.Generic;
using System.Text;
using objpatrishbot.ChatClient.Implementation;
using objpatrishbot.ChatClient.Interface;

namespace objpatrishbot.ChatClient.Factory
{
    static class ChatClientFactory
    {
        public static IChatClient Create()
        {
            return new DiscordClient();
        }
    }
}
