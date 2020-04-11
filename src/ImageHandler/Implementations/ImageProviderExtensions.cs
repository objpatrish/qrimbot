using System.IO;
using System.Linq;
using System.Threading.Tasks;
using objpatrishbot.ChatClient.Discord;
using objpatrishbot.ImageHandler.Interface;

namespace objpatrishbot.ImageHandler.Implementations
{
    static class ImageProviderExtensions
    {
        public static async Task SendImage(this IImageHandler imageHandler, string mediaPath, string user, string channel, bool isSad)
        {
            if (isSad)
                await SendVocaroo(channel);
            else
                await imageHandler.SendImage(mediaPath, user, channel);
        }

        private static async Task SendVocaroo(string channel)
        {
            var theVocaroo = Directory.GetFiles("/media").First(file => file.Contains(".mp3"));
            var guild = DiscordClient.client.Guilds.Single(g => g.Name == "Obj. Patrish");
            var discordChannel = guild.TextChannels.Single(ch => ch.Name == channel);
            await discordChannel.SendFileAsync(theVocaroo, "Jesus wept");
        }
    }
}
