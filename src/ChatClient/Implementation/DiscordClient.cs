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
        /// <summary>
        /// if the DISCORD_API_TOKEN environment variable is not set the program will look at this path for a file containing the token
        /// </summary>
        string tokenPath = ".apitoken";
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
            else if (File.Exists(tokenPath))
            {
                apiToken = File.ReadAllText(tokenPath);
                Console.WriteLine($"discord api token loaded from disk.");
            }
            else
            {
                Console.Write("api token could not be loaded from disk. Please enter api token: ");
                apiToken = Console.ReadLine();
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
