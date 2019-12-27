using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using objpatrishbot.Bot.Services.Discord;
using objpatrishbot.Commands;
using objpatrishbot.Infrastructure;
using objpatrishbot.Infrastructure.Interfaces;

namespace objpatrishbot.Bot
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddHostedService<DiscordClient>();
            // TelegramClient or otherwise can be added as a hosted service here

            services.AddSingleton<IChatClient, DiscordClient>();
            services.AddScoped<IImageHandler, DiscordImageHandler>();
            services.AddScoped<IMessageHandler<SocketMessage>, DiscordMessageHandler<SocketMessage>>();
            services.AddSingleton<ICommandHandler<DiscordCommand>, DiscordCommandHandler>();
        }
    }
}