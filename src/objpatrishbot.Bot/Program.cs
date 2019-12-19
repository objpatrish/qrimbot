using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using objpatrishbot.Bot.Services.Discord;

namespace objpatrishbot.Bot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
            {
                // Azure can be hooked up to logging here if ever desired
                logging.AddConsole();
            })
            .ConfigureServices(services =>
            {
                Startup.ConfigureServices(services);
            });
    }
}
