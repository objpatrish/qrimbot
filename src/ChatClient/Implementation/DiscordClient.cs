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
        string apiToken = "";
        public static readonly DiscordSocketClient client = new DiscordSocketClient();

        public async Task StartUp()
        {
            string apitokenEnv = Environment.GetEnvironmentVariable("DISCORD_API_TOKEN");
            
            if (apitokenEnv != null)
            {
                Console.WriteLine("using discord api token from env");
                apiToken = apitokenEnv;
            }
            else
            {
                Console.WriteLine("DISCORD_API_TOKEN environment variable not set, exiting");
                return;
            }

            try
            {
                var messageHandler = MessageHandlerFactory<SocketMessage>.Create();

                client.Log += Log;
                client.MessageReceived += messageHandler.MessageReceived;

                await client.LoginAsync(TokenType.Bot, apiToken);
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
