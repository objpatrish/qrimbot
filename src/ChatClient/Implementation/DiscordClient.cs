using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using objpatrishbot.ChatClient.Interface;
using objpatrishbot.MessageHandler.Factory;

namespace objpatrishbot.ChatClient.Implementation
{
    class DiscordClient : IChatClient
    {
        string tokenpath = ".apitoken";
        string token = "";
        public static readonly DiscordSocketClient client = new DiscordSocketClient();

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
