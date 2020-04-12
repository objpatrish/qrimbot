using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using objpatrishbot.MessageHandler.Factory;

namespace objpatrishbot.ChatClient.Discord
{
    class DiscordClient : ChatClient
    {
        string apiToken = "";
        public static readonly DiscordSocketClient client = new DiscordSocketClient();

        public DiscordClient(ChatClientConfig config) : base(config)
        {
            clientType = "discord";
            string apitokenEnv = Environment.GetEnvironmentVariable("DISCORD_API_TOKEN");

            if (apitokenEnv != null)
            {
                apiToken = apitokenEnv;
            }
            else if (!config.client.TryGetValue("api_token", out apiToken))
            {
                Program.Log("could not get api token, exiting");
                return;
            }
        }

        public override async Task Run()
        {
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
                Program.Log($"Exception occured while initializing bot client\n\t {e.Message}");
                return;
            }
        }

        private Task Log(LogMessage msg)
        {
            Program.Log(msg.ToString());
            return Task.CompletedTask;
        }
        public override Task Shutdown()
        {
            throw new NotImplementedException();
        }

        public override void ConfigUpdateHandler(ChatClientConfig cfg)
        {
            throw new NotImplementedException();
        }
    }
}
