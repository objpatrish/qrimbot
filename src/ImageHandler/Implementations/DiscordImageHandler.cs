using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using objpatrishbot.ChatClient.Discord;
using objpatrishbot.ImageHandler.Interface;

namespace objpatrishbot.ImageHandler.Implementations
{
    class DiscordImageHandler: IImageHandler
    {
        public async Task SendImage(string mediaPath, string user, string channel)
        {
            var qrimPics = Directory.GetFiles(mediaPath).Where(file => !file.Contains(".mp3")).ToArray();
            var guild = DiscordClient.client.Guilds.Single(g => g.Name == "Obj. Patrish");
            var discordChannel = guild.TextChannels.Single(ch => ch.Name == channel);
            await discordChannel.SendFileAsync(qrimPics[new Random().Next(0, qrimPics.Length - 1)], "Sick nasty");
        }
    }
}
