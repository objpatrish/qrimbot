using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Logging;
using objpatrishbot.Infrastructure.Interfaces;

namespace objpatrishbot.Bot.Services.Discord
{
    class DiscordClient : IChatClient
    {
        private ILogger<DiscordClient> _logger;
        private IMessageHandler<SocketMessage> _messageHandler;
        public DiscordClient(ILogger<DiscordClient> logger, IMessageHandler<SocketMessage> messagehandler)
        {
            _logger = logger;
            _messageHandler = messagehandler;
        }
        string apiTokenPath = ".apitoken";
        string apiToken = "";
        public static readonly DiscordSocketClient client = new DiscordSocketClient();

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if (File.Exists(apiTokenPath))
            {
                apiToken = File.ReadAllText(apiTokenPath);
                _logger.LogInformation($"api token loaded from disk: {apiToken}");
            }
            else
            {
                _logger.LogError("api token could not be loaded from disk.");
            }

            try
            {
                client.Log += Log;
                client.MessageReceived += _messageHandler.MessageReceived;

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

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }

        private Task Log(LogMessage msg)
        {
            _logger.LogInformation("Discord Client logged: " + msg.Message);
            return Task.CompletedTask;
        }
    }
}
