using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using objpatrishbot.Bot.Services.Discord;
using objpatrishbot.Infrastructure.Interfaces;

namespace objpatrishbot.Bot
{
    public class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddHostedService<DiscordClient>();
            services.AddScoped<IChatClient, DiscordClient>();
            services.AddScoped<IImageHandler, DiscordImageHandler>();
            services.AddScoped<IMessageHandler<SocketMessage>, DiscordMessageHandler<SocketMessage>>();
        }
    }
}