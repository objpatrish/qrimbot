using System.Threading.Tasks;
using objpatrishbot.ChatClient.Factory;

namespace objpatrishbot
{
    class Program
    {
        public static void Main(string[] args)
            => new Program().MainAsync(args).GetAwaiter().GetResult();

        public async Task MainAsync(string[] args)
        {
            var client = ChatClientFactory.Create();

            await client.StartUp();
        }
    }
}
