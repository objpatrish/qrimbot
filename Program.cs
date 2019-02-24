using System;
using System.IO;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;

namespace objpatrishbot
{
    class Program
    {
        static string tokenpath = ".apitoken";
        static string token = "";

        public static void Main(string[] args)
            => new Program().MainAsync(args).GetAwaiter().GetResult();

        public async Task MainAsync(string[] args)
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
                var client = new DiscordSocketClient();

                client.Log += Log;
                client.MessageReceived += MessageReceived;

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

        private async Task MessageReceived(SocketMessage message)
        {
            if (message.Content == "!ping")
            {
                await message.Channel.SendMessageAsync("Pong!");
            }
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
			return Task.CompletedTask;
        }
    }
}
