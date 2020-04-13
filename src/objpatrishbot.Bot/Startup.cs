using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using objpatrishbot.Bot.Services.Discord;
using objpatrishbot.Infrastructure.Discord;
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

            // Discord
            services.AddSingleton<IChatClient, DiscordClient>();
            services.AddSingleton<IDiscordCommandHandler, DiscordCommandHandler>();
            services.AddScoped<IImageHandler, DiscordImageHandler>();
            services.AddScoped<IMessageHandler<SocketMessage>, DiscordMessageHandler<SocketMessage>>();
        }
    }
}