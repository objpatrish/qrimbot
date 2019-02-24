using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using objpatrishbot.ChatClient.Interface;
using objpatrishbot.MessageHandler.Factory;

namespace objpatrishbot.ChatClient.Client
{
    class DiscordClient : IChatClient
    {
        string tokenpath = ".apitoken";
        string token = "";

        public async Task StartUp()
        {
            if (File.Exists(tokenpath))
            {
                token = File.ReadAllText(tokenpath);
                Console.WriteLine($"api token loaded from disk: {token}");
            }
            else
            {
                Console.Write("api token could not be loaded from disk. Please enter api token: ");
                token = Console.ReadLine();
            }

            try
            {
                var messageHandler = MessageHandlerFactory<SocketMessage>.Create();

                var client = new DiscordSocketClient();

                client.Log += Log;
                client.MessageReceived += messageHandler.MessageReceived;

                await client.LoginAsync(TokenType.Bot, token);
                await client.StartAsync();
                // Block this task until the program is closed.
                await Task.Delay(-1);
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Exception occured while initializing bot client\n\t {e.Message}");
                return;
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
