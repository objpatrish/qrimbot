using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            .ConfigureAppConfiguration((context, config) =>
            {
                config.AddJsonFile("appsettings.development.json", optional: false, reloadOnChange: true);
            })
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
